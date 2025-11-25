using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminario.Core
{
  public class ClasificacionDeterminadaDto
  {
    public List<string> Formatos { get; set; } = [];
    public List<string> Sistemas { get; set; } = [];
    public DateTime? FechaInicio { get; set; } = new();
    public DateTime? FechaFin {  get; set; } = new();
  }
}
