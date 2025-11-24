using Seminario.Business.Contracts.Repositories;
using Seminario.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminario.Business.Repositories
{
  public class MessageRepository : IMessageRepository
  {
    public Task<List<Message>> SentMessageFromSigco(string messageCategory)
    {
      throw new NotImplementedException();
    }

    public Task<Message> SentMessageFromUser(string campoId, DateTime date)
    {
      throw new NotImplementedException();
    }
  }
}
