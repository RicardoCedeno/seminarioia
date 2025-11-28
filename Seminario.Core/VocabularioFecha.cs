using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminario.Core
{
    public class VocabularioFecha
    {
        public Dictionary<string, int>? vocabulary { get; set; }
        public List<double>? idf_values { get; set; }
        public List<string>? feature_names { get; set; }
        public List<string>? componentes_posibles { get; set; }
        public int input_dim { get; set; }
    }
}
