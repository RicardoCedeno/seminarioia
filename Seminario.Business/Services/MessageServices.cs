using Seminario.Business.Contracts.Repositories;
using Seminario.Business.Contracts.Services;
using Seminario.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminario.Business.Services
{
  public class MessageServices(IMessageRepository messageRepository) : IMessageServices
  {
    private readonly IMessageRepository _messageRepository = messageRepository;
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
