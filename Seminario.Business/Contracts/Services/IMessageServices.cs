using Seminario.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminario.Business.Contracts.Services
{
  public interface IMessageServices
  {
    Task<Message> SendMessage(Message message);
  }
}
