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
    public async Task<Message> SendMessage(Message message)
    {
      Message rta= new();
      if (message == null || message.SentMessage == null || message.SentMessage.Count == 0) return rta;
      ClasificacionDeterminadaDto mensajeClasificado = await _messageRepository.ClasificarMensaje(message.SentMessage.First());
      rta.SentMessage = [$"Entiendo, necesitas los datos de los formatos de {string.Join(",", mensajeClasificado.Formatos)} desde el {mensajeClasificado.FechaInicio.Value.ToString("dd/MM/yyyy")} hasta el {mensajeClasificado.FechaFin.Value.ToString("dd/MM/yyyy")}"];
      return rta;
    }
  }
}
