using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminario.Core
{
  public class ClassificationResponse
  {
    public string TextoOriginal { get; set; } = string.Empty;
    public string TextoProcesado { get; set; } = string.Empty;
    public List<ClasePrediccion> Predicciones { get; set; } = new();
    public List<string> FormatosDetectados { get; set; } = new();
    public DateTime? FechaInicio { get; set; }
    public DateTime? FechaFin { get; set; }
    public string Mensaje { get; set; } = string.Empty;
    public List<TerminoDetectado> TerminosDetectados { get; set; } = new();
  }
}
