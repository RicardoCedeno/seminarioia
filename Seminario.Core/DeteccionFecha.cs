using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminario.Core
{
    public class DeteccionFecha
    {
        public bool TieneFechas { get; set; }
        public float ConfianzaPresencia { get; set; }
        public List<ComponenteFecha> ComponentesDetectados { get; set; } = new();
        public List<string> ComponentesFaltantes { get; set; } = new();
        public bool FechaCompleta { get; set; }
        public string MensajeFaltante { get; set; } = string.Empty;
        public string CategoriaDetectada { get; set; } = string.Empty;
    }
}
