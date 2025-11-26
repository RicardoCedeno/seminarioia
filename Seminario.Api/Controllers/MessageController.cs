using Microsoft.AspNetCore.Mvc;
using Seminario.Business.Contracts.Services;
using Seminario.Core;

namespace Seminario.Api.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class MessageController(IMessageServices messageServices)
  {
    private readonly IMessageServices _messageServices = messageServices;
    [HttpPost("SendMessageToSigco")]
    public async Task<ResponseDto<Message>> SendMessageFromSigco(Message message)
    {
      ResponseDto<Message> rta = new() { Data = null, IsSuccessful = true, Errors = [] };
      if (message == null) return rta;
      try
      {
        rta.Data = await _messageServices.SendMessage(message);
      }
      catch (Exception ex)
      {
        rta.Data = new() { SentMessage = ["Ocurrió un error al enviar el mensaje"], SentMessageDatetime = DateTime.Now, FromUser= false };
      }
      return rta;
    }
  }
}
