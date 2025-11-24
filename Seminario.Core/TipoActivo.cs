using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminario.Core
{
  public class TipoActivo
  {
    [Key]
    public string Id { get; set; }
    [Required]
    public string Nombre { get; set; }
    public string? Descripcion { get; set; }

    #region Propiedades de Navegación
    public List<Activo> Activos { get; set; }
    #endregion

    #region Constructores
    public TipoActivo()
    {
      Activos = new List<Activo>();
    }
    public TipoActivo(TipoActivo input)
    {
      Id = input.Id;
      Nombre = input.Nombre;
      Descripcion = input.Descripcion;
      Activos = [];
    }
    #endregion Constructores
  }
}
