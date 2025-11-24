using Seminario.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminario.Business.Contracts.Services
{
  public interface IMedicionComposicionAguaServices
  {
    Task<List<MedicionComposicionAguaDto>> GetMedicionComposicionAguaByPuntoInformacionAndFecha(string puntoInformacionId, DateTime fechaDesde, DateTime fechaHasta);
  }
}
