using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminario.Core
{
  public class ClasePrediccion
  {
    public string Clase { get; set; } = string.Empty;
    public float Probabilidad { get; set; }
    public string Estado { get; set; } = string.Empty; // "alta", "media", "baja"
  }
}
