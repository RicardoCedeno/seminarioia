using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminario.Core
{
    public class ModeloRecursos
    {
        public Dictionary<string, int> Vocabulario { get; set; } = new();
        public float[] IdfWeights { get; set; } = [];
        public List<string> Clases { get; set; } = [];
        public dynamic Session { get; set; }
        public int VocabSize { get; set; } = 0;
    }
}
