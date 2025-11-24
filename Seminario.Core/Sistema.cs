using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminario.Core
{
  public class Sistema
  {
    #region Columnas
    [Key]
    public string Id { get; set; } = string.Empty;
    [ForeignKey("Campo")]
    public string CampoId { get; set; } = string.Empty;
    public string Nombre { get; set; } = string.Empty;
    public string Descripcion { get; set; } = string.Empty;
    #endregion Columnas
    #region Propiedades de Navegación
    public ICollection<Activo> Activos { get; set; } = [];
    public Campo? Campo { get; set; }
    #endregion Propiedades de Navegación
    #region Constructores
    public Sistema() { }
    public Sistema(Sistema input)
    {
      Id = input.Id;
      CampoId = input.CampoId;
      Nombre = input.Nombre;
      Descripcion = input.Descripcion;
      Activos = [];
    }
    #endregion Constructores
  }
}
