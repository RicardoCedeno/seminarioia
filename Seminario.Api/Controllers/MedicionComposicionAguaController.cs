using Microsoft.AspNetCore.Mvc;
using Seminario.Business.Contracts.Services;
using Seminario.Core;

namespace Seminario.Api.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class MedicionComposicionAguaController(IMedicionComposicionAguaServices medicionComposicionAguaServices)
  {
    private readonly IMedicionComposicionAguaServices _medicicionComposicionAguaServices = medicionComposicionAguaServices;

    [HttpGet("GetMedicionComposicionAguaByPuntoInformacionIdAndDate/{puntoInformacionId}/{fechaDesde}/{fechaHasta}")]
    public async Task<ResponseDto<List<MedicionComposicionAguaDto>>> GetMedicionComposicionAguaByPuntoInformacionId([FromRoute] string puntoInformacionId, [FromRoute]DateTime fechaDesde, [FromRoute] DateTime fechaHasta)
    {
      ResponseDto<List<MedicionComposicionAguaDto>> response = new() { Data = [], IsSuccessful = true, Errors = [] };
      List<MedicionComposicionAguaDto> data = [];
      try
      {
        data = await _medicicionComposicionAguaServices.GetMedicionComposicionAguaByPuntoInformacionAndFecha(puntoInformacionId, fechaDesde, fechaHasta);
        response.Data = data;
        response.Errors = [];
      }
      catch (Exception ex)
      {
        response.Errors = [$"Ocurrió el siguiente error: {ex.Message.ToString()}"];
        response.IsSuccessful = false;
      }
      return response;
    }
  }
}
