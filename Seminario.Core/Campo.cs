using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminario.Core
{
  public class Campo
  {
    [Key]
    public string Id { get; set; } = string.Empty;
    [Required]
    public string Nombre { get; set; } = string.Empty;

    public string Descripcion { get; set; } = string.Empty;

    public double? LatitudReferencia { get; set; }

    public double? LongitudReferencia { get; set; }
    public List<Sistema> Sistemas { get; set; } = [];

    public Campo()
    {
    }

    public Campo(Campo input)
    {
      Id = input.Id;
      Nombre = input.Nombre;
      Descripcion = input.Descripcion;
      LatitudReferencia = input.LatitudReferencia;
      LongitudReferencia = input.LongitudReferencia;
      Sistemas = [];
    }
  }
}
