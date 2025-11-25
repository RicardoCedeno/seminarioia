using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminario.Core
{
  public class VocabularioData
  {
    public Dictionary<string, int> vocabulario { get; set; } = new();
    public List<string> features { get; set; } = new();
    public int n_features { get; set; }
    public List<int> ngram_range { get; set; } = new();
    public int? max_features { get; set; }
    public int min_df { get; set; }
    public List<double> idf_values { get; set; } = new();
  }
}
