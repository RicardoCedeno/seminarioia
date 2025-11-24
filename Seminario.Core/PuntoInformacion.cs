using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminario.Core
{
  public class PuntoInformacion
  {
    [Key]
    public string Id { get; set; } = string.Empty;
    [ForeignKey("Activo")]
    public string ActivoId { get; set; } = string.Empty;
    [Required]
    [StringLength(100)]
    public string Nombre { get; set; } = string.Empty;
    [StringLength(200)]
    public string Descripcion { get; set; } = string.Empty;
    public bool Estado { get; set; }
    #region Propiedades de navegación
    public Activo Activo { get; set; } = new();
    public List<MedicionComposicionAgua> MedicionesComposicionAgua { get; set; } = [];
    #endregion Propiedades de navegación

    public PuntoInformacion() { }
    public PuntoInformacion(PuntoInformacion input)
    {
      Id = input.Id;
      ActivoId = input.ActivoId;
      Nombre = input.Nombre;
      Descripcion = input.Descripcion;
      Estado = input.Estado;
    }
  }
}
