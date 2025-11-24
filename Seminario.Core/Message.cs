using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminario.Core
{
  public class Message
  {
    public bool FromUser { get; set; } = false;
    public string CampoId { get; set; } = string.Empty;
    public string SentMessage { get; set; } = string.Empty;
    public string MessageCategory {  get; set; } = string.Empty;
    public DateTime SentMessageDatetime { get; set; } = new();
  }
}
