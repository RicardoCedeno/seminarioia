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
            if (mensajeClasificado.Formatos.Count > 0 && mensajeClasificado.FechaInicio != null && mensajeClasificado.FechaFin != null) rta.SentMessage = [$"Entiendo, necesitas los datos de los formatos de {string.Join(",", mensajeClasificado.Formatos)} desde el {mensajeClasificado.FechaInicio.Value.ToString("dd/MM/yyyy")} hasta el {mensajeClasificado.FechaFin.Value.ToString("dd/MM/yyyy")}"];
            else if (mensajeClasificado.Formatos.Count > 0 && (mensajeClasificado.FechaInicio == null || mensajeClasificado.FechaFin == null)) rta.SentMessage = [$"Entiendo, necesitas los datos de los formatos {string.Join(",", mensajeClasificado.Formatos)}, sin embargo necesitas especificar la fecha de inicio y la fecha de fin. Por favor vuelve a intentarlo"];
            else if (mensajeClasificado.Formatos.Count == 0 && mensajeClasificado.FechaInicio != null && mensajeClasificado.FechaFin != null) rta.SentMessage = [$"Además de la fecha, es necesario especificar un formato, ya sea agua, aminas o sólidos, por favor vuelve a intentarlo"];
            else if (mensajeClasificado.Formatos.Count == 0 && (mensajeClasificado.FechaInicio != null || mensajeClasificado.FechaFin != null)) rta.SentMessage = ["Por favor vuelve a escribir el mensaje especificando los formato y las fechas que necesitas consultar"];
            else if (mensajeClasificado.Formatos.Count == 0 && mensajeClasificado.FechaInicio == null && mensajeClasificado.FechaFin == null) rta.SentMessage=["Por favor, escribe un mensaje que contenga el formato y el rango de fachas a consultar", "Por ejemplo formato de agua, y fechas desde el 20 de octubre de 2015 hasta el 10 de enero de 2020"];
      return rta;
    }
  }
}
