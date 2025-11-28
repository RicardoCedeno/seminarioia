using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Recognizers.Text;
using Microsoft.Recognizers.Text.DateTime;

namespace Seminario.Business.Helpers
{
    public class ExtractDates
    {
        private readonly string culture = Culture.Spanish;

        public (DateTime? fechaInicio, DateTime? fechaFin) ExtraerFechas(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
                return (null, null);

            var textoLower = texto.ToLower();

            // Detectar indicadores de rango
            bool tieneDesde = textoLower.Contains("desde") ||
                             textoLower.Contains("a partir") ||
                             textoLower.Contains("del");
            bool tieneHasta = textoLower.Contains("hasta") ||
                             textoLower.Contains("al");
            bool esRango = textoLower.Contains("entre") ||
                          (tieneDesde && tieneHasta);

            // Usar Microsoft Recognizers para extraer fechas
            var resultados = DateTimeRecognizer.RecognizeDateTime(texto, culture);

            var fechasExtraidas = new List<DateTime>();
            bool rangoCompleto = false;

            foreach (var resultado in resultados)
            {
                if (resultado.Resolution == null) continue;

                foreach (var resolucion in resultado.Resolution.Values)
                {
                    if (resolucion is not List<Dictionary<string, string>> valores)
                        continue;

                    foreach (var valor in valores)
                    {
                        // Manejar rangos de fechas (start + end)
                        if (valor.ContainsKey("start") && valor.ContainsKey("end"))
                        {
                            if (DateTime.TryParse(valor["start"], out DateTime inicio))
                                fechasExtraidas.Add(inicio);

                            if (DateTime.TryParse(valor["end"], out DateTime fin))
                                fechasExtraidas.Add(fin);

                            rangoCompleto = true;
                        }
                        // Intentar extraer del timex si no hay end pero sí start
                        else if (valor.ContainsKey("start") && !valor.ContainsKey("end") && valor.ContainsKey("timex"))
                        {
                            var timex = valor["timex"];

                            // Formato: (YYYY-MM-DD,YYYY-MM-DD,PXXX)
                            var match = System.Text.RegularExpressions.Regex.Match(
                                timex,
                                @"\((\d{4}-\d{2}-\d{2}),(\d{4}-\d{2}-\d{2})"
                            );

                            if (match.Success)
                            {
                                if (DateTime.TryParse(match.Groups[1].Value, out DateTime inicio))
                                    fechasExtraidas.Add(inicio);

                                if (DateTime.TryParse(match.Groups[2].Value, out DateTime fin))
                                    fechasExtraidas.Add(fin);

                                rangoCompleto = true;
                            }
                            else
                            {
                                // Si no se puede parsear timex, usar solo start
                                if (DateTime.TryParse(valor["start"], out DateTime inicio))
                                    fechasExtraidas.Add(inicio);
                            }
                        }
                        // Manejar solo start sin timex de rango
                        else if (valor.ContainsKey("start"))
                        {
                            if (DateTime.TryParse(valor["start"], out DateTime inicio))
                                fechasExtraidas.Add(inicio);
                        }
                        // Manejar fechas individuales con "value"
                        else if (valor.ContainsKey("value"))
                        {
                            if (DateTime.TryParse(valor["value"], out DateTime fecha))
                                fechasExtraidas.Add(fecha);
                        }
                    }
                }
            }

            // Si no se encontraron fechas
            if (fechasExtraidas.Count == 0)
                return (null, null);

            // Ordenar las fechas
            var fechasOrdenadas = fechasExtraidas.OrderBy(f => f).Distinct().ToList();

            // Lógica de asignación según contexto

            // Si encontramos un rango completo en el recognizer, usar primera y última
            if (rangoCompleto || fechasOrdenadas.Count >= 2)
            {
                return (fechasOrdenadas.First(), fechasOrdenadas.Last());
            }
            // Si solo hay una fecha, usar contexto del texto
            else if (fechasOrdenadas.Count == 1)
            {
                var fecha = fechasOrdenadas[0];

                if (tieneDesde && !tieneHasta)
                    return (fecha, null);
                else if (tieneHasta && !tieneDesde)
                    return (null, fecha);
                else
                    return (fecha, fecha);
            }

            return (null, null);
        }

        public string LimpiarFechasDelTexto(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
                return texto;

            var resultados = DateTimeRecognizer.RecognizeDateTime(texto, culture);

            string textoLimpio = texto;

            // Remover las fechas detectadas (en orden inverso para no afectar índices)
            foreach (var resultado in resultados.OrderByDescending(r => r.Start))
            {
                int inicio = resultado.Start;
                int longitud = resultado.End - resultado.Start + 1;

                if (inicio >= 0 && inicio + longitud <= textoLimpio.Length)
                {
                    textoLimpio = textoLimpio.Remove(inicio, longitud);
                }
            }

            // Remover palabras temporales comunes
            var palabrasTemporales = new[]
            {
                "a partir de", "apartir", "desde", "hasta", "entre",
                "inicio", "fin", "durante", "periodo", "rango", "del", "al"
            };

            foreach (var palabra in palabrasTemporales.OrderByDescending(p => p.Length))
            {
                textoLimpio = System.Text.RegularExpressions.Regex.Replace(
                    textoLimpio,
                    $@"\b{System.Text.RegularExpressions.Regex.Escape(palabra)}\b",
                    "",
                    System.Text.RegularExpressions.RegexOptions.IgnoreCase
                );
            }

            // Normalizar espacios
            textoLimpio = System.Text.RegularExpressions.Regex.Replace(
                textoLimpio,
                @"\s+",
                " "
            ).Trim();

            return textoLimpio;
        }
    }
}