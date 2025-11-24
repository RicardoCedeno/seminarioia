using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Seminario.Business.Contracts.Repositories;
using Seminario.Core;
using Seminario.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminario.Business.Repositories
{
  public class MedicionComposicionAguaRepository(Context context, IMapper mapper) : IMedicionCompoiscionAguaRepository
  {
    private readonly Context _context = context;
    private readonly IMapper _mapper = mapper;

    public async Task<List<MedicionComposicionAguaDto>> GetMedicionComposicionAguaByPuntoInformacionAndFecha(string puntoInformacionId, DateTime fechaDesde, DateTime fechaHasta)
    {
      List<MedicionComposicionAgua> medicionAgua = await _context.MedicionComposicionAgua.ToListAsync();
      List<MedicionComposicionAgua> medicionAguaFiltrado = [.. medicionAgua.Where(x => x.PuntoInformacionId.ToUpper().Trim() == puntoInformacionId.ToUpper().Trim() && x.Fecha.Date >= fechaDesde.Date && x.Fecha.Date <= fechaHasta.Date)];
      List<MedicionComposicionAguaDto> rta = _mapper.Map<List<MedicionComposicionAguaDto>>(medicionAguaFiltrado);
      return rta;
    }
  }
}
