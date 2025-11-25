using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Seminario.Business.Helpers
{
  public class ExtractDates
  {
    private readonly Dictionary<string, int> mesesEsp;
    private readonly List<string> patrones;
    private readonly Regex patronCompleto;
    public ExtractDates()
    {
      mesesEsp = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
        {
            { "enero", 1 }, { "febrero", 2 }, { "marzo", 3 }, { "abril", 4 },
            { "mayo", 5 }, { "junio", 6 }, { "julio", 7 }, { "agosto", 8 },
            { "septiembre", 9 }, { "octubre", 10 }, { "noviembre", 11 }, { "diciembre", 12 },
            { "ene", 1 }, { "feb", 2 }, { "mar", 3 }, { "abr", 4 },
            { "may", 5 }, { "jun", 6 }, { "jul", 7 }, { "ago", 8 },
            { "sep", 9 }, { "oct", 10 }, { "nov", 11 }, { "dic", 12 }
        };

      patrones = new List<string>
        {
            @"\d{1,2}\s+de\s+\w+\s+de\s+\d{4}",
            @"\w+\s+de\s+\d{4}",
            @"\d{1,2}[/-]\d{1,2}[/-]\d{4}",
            @"\d{4}[/-]\d{1,2}[/-]\d{1,2}",
            @"\d{1,2}\s+\w+\s+\d{4}",
            @"\w+\s+\d{4}"
        };

      string patronUnido = string.Join("|", patrones.Select(p => $"({p})"));
      patronCompleto = new Regex(patronUnido, RegexOptions.IgnoreCase);
    }

    public string LimpiarFechasDelTexto(string texto)
    {
      // Remover coincidencias de patrones de fechas
      string textoLimpio = patronCompleto.Replace(texto, "");

      // Palabras temporales
      var palabrasTemporales = new List<string>
        {
            "a partir de", "apartir", "desde", "hasta", "entre",
            "inicio", "fin", "durante", "periodo", "rango", "del", "al"
        }.OrderByDescending(p => p.Length);

      foreach (var palabra in palabrasTemporales)
      {
        textoLimpio = Regex.Replace(textoLimpio, $@"\b{Regex.Escape(palabra)}\b", "", RegexOptions.IgnoreCase);
      }

      // Remover números sueltos
      textoLimpio = Regex.Replace(textoLimpio, @"\b\d{1,4}\b", "");

      // Espacios extra
      textoLimpio = Regex.Replace(textoLimpio, @"\s+", " ").Trim();

      return textoLimpio;
    }

    private int? NormalizarMes(string mesTexto)
    {
      if (mesesEsp.TryGetValue(mesTexto.ToLower(), out int mes))
        return mes;
      return null;
    }

    public (DateTime? fechaInicio, DateTime? fechaFin) ExtraerFechas(string texto)
    {
      var resultado = (fechaInicio: (DateTime?)null, fechaFin: (DateTime?)null);
      var textoLower = texto.ToLower();

      bool tieneDesde = textoLower.Contains("desde") || textoLower.Contains("a partir") || textoLower.Contains("del");
      bool tieneHasta = textoLower.Contains("hasta") || textoLower.Contains("al");

      var fechasEncontradas = new List<DateTime>();

      // Buscar patrones directos
      foreach (var patron in patrones)
      {
        foreach (Match match in Regex.Matches(texto, patron, RegexOptions.IgnoreCase))
        {
          DateTime? fecha = ParsearMatch(match.Value);
          if (fecha.HasValue)
            fechasEncontradas.Add(fecha.Value);
        }
      }

      // Ordenar y asignar según contexto
      if (fechasEncontradas.Count >= 2)
      {
        var ordenadas = fechasEncontradas.OrderBy(f => f).ToList();
        resultado.fechaInicio = ordenadas[(fechasEncontradas.Count / 2) - 1];
        resultado.fechaFin = ordenadas.Last();
      }
      else if (fechasEncontradas.Count == 1)
      {
        if (tieneDesde && !tieneHasta)
          resultado.fechaInicio = fechasEncontradas[0];
        else if (tieneHasta && !tieneDesde)
          resultado.fechaFin = fechasEncontradas[0];
        else
          resultado = (fechasEncontradas[0], fechasEncontradas[0]);
      }

      return resultado;
    }

    private DateTime? ParsearMatch(string texto)
    {
      try
      {
        string[] partes = texto.Split(new[] { " ", "/", "-", "de" }, StringSplitOptions.RemoveEmptyEntries);

        // Ejemplo: "12 de marzo de 2024"
        if (texto.Contains("de") && partes.Length >= 3)
        {
          if (int.TryParse(partes[0], out int dia) &&
              int.TryParse(partes[^1], out int año))
          {
            int? mes = NormalizarMes(partes[1]);
            if (mes.HasValue)
              return new DateTime(año, mes.Value, dia);
          }
        }

        // Ejemplo: "marzo 2024"
        if (partes.Length == 2 && !int.TryParse(partes[0], out _))
        {
          int? mes = NormalizarMes(partes[0]);
          if (mes.HasValue && int.TryParse(partes[1], out int año))
            return new DateTime(año, mes.Value, 1);
        }

        // Ejemplo: "12/03/2024" o "2024-03-12"
        if (Regex.IsMatch(texto, @"\d{1,2}[/-]\d{1,2}[/-]\d{4}") ||
            Regex.IsMatch(texto, @"\d{4}[/-]\d{1,2}[/-]\d{1,2}"))
        {
          if (DateTime.TryParseExact(texto, new[] { "dd/MM/yyyy", "d/M/yyyy", "yyyy-MM-dd" },
              CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime fecha))
            return fecha;
        }
      }
      catch { }

      return null;
    }
  }
}
