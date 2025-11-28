using Seminario.Business.Contracts.Repositories;
using Seminario.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

using Microsoft.ML.OnnxRuntime;
using Microsoft.ML.OnnxRuntime.Tensors;
using System.Text.RegularExpressions;
using Seminario.Business.Helpers;
using Microsoft.SqlServer.Server;

namespace Seminario.Business.Repositories
{
  public class MessageRepository : IMessageRepository
  {

    static Dictionary<string, int>? vocabulario = new();
    static List<string>? clases = [];
    static List<double>? idfValues = [];

    private static readonly HashSet<string> stopwords = new()
    {
        "el", "la", "los", "las", "de", "del", "al", "y", "en", "con", "por", "para", "que",
        "a", "un", "una", "favor", "puedes", "pasarme", "darme", "pasar", "necesitar",
        "dar", "dame", "pasar", "pasame", "mostrar", "muestrame", "obtener", "decir",
        "dime", "traer", "conseguir", "damar", "dato", "datos"
    };

    private static readonly HashSet<string> stopwordsSentimientos = new()
    {
        
    };

    private static readonly Dictionary<string, string> lemas = new()
    {
        {"datos", "datos"}, {"dato", "datos"}, {"agua", "agua"}, {"aguas", "agua"},
        {"amina", "amina"}, {"aminas", "amina"}, {"sólido", "sólido"}, {"sólidos", "sólido"},
        {"solido", "sólido"}, {"solidos", "sólido"}, {"información", "información"},
        {"informacion", "información"}, {"necesito", "necesitar"}, {"necesita", "necesitar"},
        {"necesitar", "necesitar"}, {"dar", "dar"}, {"dame", "dar"}, {"muestra", "mostrar"},
        {"muestrame", "mostrar"}, {"mostrar", "mostrar"}, {"obtener", "obtar"},
        {"obten", "obtar"}, {"valores", "valores"}, {"valor", "valores"},
        {"formato", "formato"}, {"formatos", "formato"}, {"tabla", "tabla"},
        {"tablas", "tabla"}, {"pasame", "pasar"}, {"pasa", "pasar"}, {"pasar", "pasar"}
    };

    public async Task<ClasificacionDeterminadaDto> ClasificarSentimiento(string message)
    {
      ClasificacionDeterminadaDto rta = new();
      if (string.IsNullOrEmpty(message))
        return new();

      try
      {
        // === 1️⃣ Cargar vocabulario ===
        var vocabData = JsonSerializer.Deserialize<VocabularioData>(
            await File.ReadAllTextAsync("vocabulario_sentimientos.json")
        );

        vocabulario = vocabData?.vocabulario ?? new();
        idfValues = vocabData?.idf_values ?? new();

        // === 2️⃣ Cargar clases ===
        clases = JsonSerializer.Deserialize<List<string>>(
            await File.ReadAllTextAsync("classes_sentimientos.json")
        ) ?? new();

        // === 3️⃣ Cargar modelo ONNX ===
        using var session = new InferenceSession("classifier_sentimientos.onnx");

        // === 4️⃣ Preprocesar y vectorizar ===
        string textoProcesado = PreprocesarTexto(message, "sentimientos");
        float[] vector = VectorizarTexto(textoProcesado, "vocabulario_sentimientos.json");

        // === 5️⃣ Crear tensor de entrada ===
        var inputTensor = new DenseTensor<float>(vector, new[] { 1, vector.Length });
        var inputs = new List<NamedOnnxValue>
        {
            NamedOnnxValue.CreateFromTensor("input", inputTensor)
        };

        // === 6️⃣ Ejecutar inferencia ===
        using var results = session.Run(inputs);
        var output = results.First().AsEnumerable<float>().ToArray();

        // === 7️⃣ Aplicar sigmoide ===
        float Sigmoid(float x) => 1f / (1f + MathF.Exp(-x));
        var probs = output.Select(Sigmoid).ToArray();

        // === 8️⃣ Obtener formatos detectados ===
        List<string> formatos = new();
        for (int i = 0; i < probs.Length; i++)
        {
          if (probs[i] > 0.70)
          {
            formatos.Add(clases[i]);
          }
        }
        // === 9️⃣ Extraer fechas ===


        rta = new() { Formatos = formatos, FechaInicio = null, FechaFin = null, Sistemas = [] };

      }
      catch (Exception ex)
      {
        rta = new() { Formatos = [], FechaInicio = null, FechaFin = null, Sistemas = [] };
        // Log del error si tienes un logger configurado
        // _logger.LogError(ex, "Error al clasificar mensaje");
      }
      return rta;
    }
    public async Task<ClasificacionDeterminadaDto> ClasificarMensaje(string message)
    {
      ClasificacionDeterminadaDto rta = new();
      if (string.IsNullOrEmpty(message))
        return new();

      try
      {
        // === 1️⃣ Cargar vocabulario ===
        var vocabData = JsonSerializer.Deserialize<VocabularioData>(
            await File.ReadAllTextAsync("vocabulario.json")
        );

        vocabulario = vocabData?.vocabulario ?? new();
        idfValues = vocabData?.idf_values ?? new();

        // === 2️⃣ Cargar clases ===
        clases = JsonSerializer.Deserialize<List<string>>(
            await File.ReadAllTextAsync("classes.json")
        ) ?? new();

        // === 3️⃣ Cargar modelo ONNX ===
        using var session = new InferenceSession("classifier_tonos.onnx");

        // === 4️⃣ Preprocesar y vectorizar ===
        string textoProcesado = PreprocesarTexto(message, "formatos");
        float[] vector = VectorizarTexto(textoProcesado, "vocabulario.json");

        // === 5️⃣ Crear tensor de entrada ===
        var inputTensor = new DenseTensor<float>(vector, new[] { 1, vector.Length });
        var inputs = new List<NamedOnnxValue>
        {
            NamedOnnxValue.CreateFromTensor("input", inputTensor)
        };

        // === 6️⃣ Ejecutar inferencia ===
        using var results = session.Run(inputs);
        var output = results.First().AsEnumerable<float>().ToArray();

        // === 7️⃣ Aplicar sigmoide ===
        float Sigmoid(float x) => 1f / (1f + MathF.Exp(-x));
        var probs = output.Select(Sigmoid).ToArray();

        // === 8️⃣ Obtener formatos detectados ===
        List<string> formatos = new();
        for (int i = 0; i < probs.Length; i++)
        {
          if (probs[i] > 0.85)
          {
            formatos.Add(clases[i]);
          }
        }
        // === 9️⃣ Extraer fechas ===
        ExtractDates extractDates = new();
        var (fechaInicio, fechaFin) = extractDates.ExtraerFechas(message);

        rta = new() { Formatos = formatos, FechaInicio = fechaInicio, FechaFin = fechaFin, Sistemas = [] };
        // === 🔟 Generar respuesta ===
        //if (formatos.Count > 0 && fechaInicio != null && fechaInicio.HasValue && fechaFin != null && fechaFin.HasValue)
        //    rta = new() { Formatos = formatos, FechaInicio = fechaInicio!.Value, FechaFin = fechaFin!.Value, Sistemas = [] };

        //else if (formatos.Count == 0 && fechaInicio != null && fechaFin != null) return new() { Formatos = [], FechaInicio = fechaInicio, FechaFin = fechaFin, Sistemas = [] };

        //else if (formatos.Count == 0 && (fechaInicio == null || fechaFin == null)) return new() { Formatos = [], FechaInicio = null, FechaFin = null, Sistemas = [] };
      }
      catch (Exception ex)
      {
        rta = new() { Formatos = [], FechaInicio = null, FechaFin = null, Sistemas = [] };
        // Log del error si tienes un logger configurado
        // _logger.LogError(ex, "Error al clasificar mensaje");
      }
      return rta;
    }

    static string PreprocesarTexto(string texto, string categorias)
    {
      // 1. Lowercase
      texto = texto.ToLower();

      // 2. Remover puntuación (excepto espacios)
      texto = Regex.Replace(texto, @"[^\w\s]", " ");

      // 3. Normalizar espacios
      texto = Regex.Replace(texto, @"\s+", " ").Trim();

      // 4. Tokenizar
      var tokens = texto.Split(' ', StringSplitOptions.RemoveEmptyEntries);

      // 5. Lematizar y filtrar stopwords
      var tokensLimpios = new List<string>();
      foreach (var token in tokens)
      {
        // Buscar lema
        string lema = lemas.GetValueOrDefault(token, token);

        // Filtrar stopwords
        if (categorias == "formatos" && !stopwords.Contains(lema))
        {
          tokensLimpios.Add(lema);
        }
        else if (categorias == "sentimientos" && !stopwordsSentimientos.Contains(lema))
        {
          tokensLimpios.Add(lema);
        }
      }

      return string.Join(" ", tokensLimpios);
    }

    static float[] VectorizarTexto(string textoProcesado, string vocabularioJson)
    {
      var vocabData = JsonSerializer.Deserialize<VocabularioData>(
    File.ReadAllText(vocabularioJson)
);
      vocabulario = vocabData?.vocabulario;
      idfValues = vocabData?.idf_values;
      if (vocabulario == null)
        throw new InvalidOperationException("Vocabulario no cargado");

      float[] vector = new float[vocabulario.Count];

      var tokens = textoProcesado.Split(' ', StringSplitOptions.RemoveEmptyEntries);

      // Contar frecuencias
      var termFreq = new Dictionary<string, int>();

      // Unigramas
      foreach (var token in tokens)
      {
        if (vocabulario.ContainsKey(token))
        {
          termFreq[token] = termFreq.GetValueOrDefault(token, 0) + 1;
        }
      }

      // Bigramas
      for (int i = 0; i < tokens.Length - 1; i++)
      {
        string bigram = $"{tokens[i]} {tokens[i + 1]}";
        if (vocabulario.ContainsKey(bigram))
        {
          termFreq[bigram] = termFreq.GetValueOrDefault(bigram, 0) + 1;
        }
      }

      // Aplicar TF-IDF
      foreach (var (term, freq) in termFreq)
      {
        if (vocabulario.TryGetValue(term, out int index))
        {
          float tf = (float)freq;  // ⚠️ sklearn usa freq raw, no normalizado
          float idf = idfValues != null && index < idfValues.Count
              ? (float)idfValues[index]
              : 1.0f;

          vector[index] = tf * idf;
        }
      }

      // ⭐ NORMALIZACIÓN L2 (igual que sklearn)
      float norm = MathF.Sqrt(vector.Sum(x => x * x));
      if (norm > 0)
      {
        for (int i = 0; i < vector.Length; i++)
        {
          vector[i] /= norm;
        }
      }

      return vector;
    }
  }
}
