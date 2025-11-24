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
  public class MedicionComposicionAguaServices(IMedicionCompoiscionAguaRepository medicionCompoiscionAguaRepository) : IMedicionComposicionAguaServices
  {
    private readonly IMedicionCompoiscionAguaRepository _medicionComposicionAguaRepository = medicionCompoiscionAguaRepository;

    public async Task<List<MedicionComposicionAguaDto>> GetMedicionComposicionAguaByPuntoInformacionAndFecha(string puntoInformacionId, DateTime fechaDesde, DateTime fechaHasta)
    {
      List<MedicionComposicionAguaDto> rta = await _medicionComposicionAguaRepository.GetMedicionComposicionAguaByPuntoInformacionAndFecha(puntoInformacionId, fechaDesde, fechaHasta);
      return rta;
    }
  }
}
