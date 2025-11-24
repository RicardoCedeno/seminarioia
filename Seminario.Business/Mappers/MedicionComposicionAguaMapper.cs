using AutoMapper;
using Seminario.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminario.Business.Mappers
{
  public class MedicionComposicionAguaMapper: Profile
  {
    public MedicionComposicionAguaMapper()
    {
      CreateMap<MedicionComposicionAguaDto, MedicionComposicionAgua>();
      CreateMap<MedicionComposicionAgua, MedicionComposicionAguaDto>()
        .ForMember(dest => dest.NombrePuntoInformacion, options => options.MapFrom(src => src.PuntoInformacion.Descripcion))
        .ForMember(dest => dest.NombreActivo, options => options.MapFrom(src => src.PuntoInformacion.Activo.Nombre));
    }
  }
}
