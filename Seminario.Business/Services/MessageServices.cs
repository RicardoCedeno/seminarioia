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
            Message rta = new();
            if (message == null || message.SentMessage == null || message.SentMessage.Count == 0) return rta;
            ClasificacionDeterminadaDto mensajeClasificado = await _messageRepository.ClasificarMensaje(message.SentMessage.First());
            ClasificacionDeterminadaDto sentimientoClasificado = await _messageRepository.ClasificarSentimiento(message.SentMessage.First());
            if (sentimientoClasificado.Formatos.Contains("solicitud"))
            {
                if (mensajeClasificado.Formatos.Count > 0 && mensajeClasificado.FechaInicio != null && mensajeClasificado.FechaFin != null) rta.SentMessage.Add($"Entiendo, necesitas los datos de los formatos de {string.Join(",", mensajeClasificado.Formatos)} desde el {mensajeClasificado.FechaInicio.Value.ToString("dd/MM/yyyy")} hasta el {mensajeClasificado.FechaFin.Value.ToString("dd/MM/yyyy")}");
                else if (mensajeClasificado.Formatos.Count > 0 && (mensajeClasificado.FechaInicio == null || mensajeClasificado.FechaFin == null)) rta.SentMessage.Add($"Entiendo, necesitas los datos de los formatos {string.Join(",", mensajeClasificado.Formatos)}, sin embargo necesitas especificar la fecha de inicio y la fecha de fin. Por favor vuelve a intentarlo");
                else if (mensajeClasificado.Formatos.Count == 0 && mensajeClasificado.FechaInicio != null && mensajeClasificado.FechaFin != null) rta.SentMessage.Add($"Además de la fecha, es necesario especificar un formato, ya sea agua, aminas o sólidos, por favor vuelve a intentarlo");
                else if (mensajeClasificado.Formatos.Count == 0 && (mensajeClasificado.FechaInicio != null || mensajeClasificado.FechaFin != null)) rta.SentMessage.Add("Por favor vuelve a escribir el mensaje especificando los formato y las fechas que necesitas consultar");
                else if (mensajeClasificado.Formatos.Count == 0 && mensajeClasificado.FechaInicio == null && mensajeClasificado.FechaFin == null) rta.SentMessage.AddRange(["Por favor, escribe un mensaje que contenga el formato y el rango de fachas a consultar", "Por ejemplo formato de agua, y fechas desde el 20 de octubre de 2015 hasta el 10 de enero de 2020"]);
            }
            if (sentimientoClasificado.Formatos.Count == 1 && sentimientoClasificado.Formatos.First() =="saludo")
            {
                rta.SentMessage.Insert(0, "Hola, En que puedo ayudarte?");
            }

            if (sentimientoClasificado.Formatos.Count == 1 && sentimientoClasificado.Formatos.First() == "agradecimiento")
            {
                rta.SentMessage.Add("De nada, si necesitas algo más hazmelo saber");
            }

            if (sentimientoClasificado.Formatos.Count == 1 && sentimientoClasificado.Formatos.First() == "enojo")
            {
                rta.SentMessage.Add("Por favor, vuelve a realizar la pregunta. Si no recibes la información requeria comunícate con la línea");
            }

            if (sentimientoClasificado.Formatos.Contains("despedida"))
            {
                rta.SentMessage.Add("Hasta luego, espero haber resuelto tus dudas");
            }

            return rta;
        }
    }
}
