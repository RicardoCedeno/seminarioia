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
    Task<Message> SentMessageFromUser(string campoId, DateTime date);
    Task<List<Message>> SentMessageFromSigco(string messageCategory);
  }
}
