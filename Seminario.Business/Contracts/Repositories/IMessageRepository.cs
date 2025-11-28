using Seminario.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminario.Business.Contracts.Repositories
{
    public interface IMessageRepository
    {
        Task<ClasificacionDeterminadaDto> ClasificarMensaje(string message);
        Task<ClasificacionDeterminadaDto> ClasificarSentimiento(string message);
    }
}
