using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminario.Core
{
  public class Activo
  {
    #region Propiedades
    [Key]
    public string Id { get; set; } = string.Empty;

    [ForeignKey("TipoActivo")]
    public string TipoActivoId { get; set; } = string.Empty;

    [ForeignKey("Sistema")]
    public string SistemaId { get; set; } = string.Empty;

    [StringLength(100)]
    public string Nombre { get; set; } = string.Empty;

    [StringLength(100)]
    public string? Tag { get; set; } = string.Empty;

    [StringLength(500)]
    public string? Descripcion { get; set; } = string.Empty;

    [StringLength(500)]
    public string? PId { get; set; } = string.Empty;

    [DataType(DataType.DateTime)]
    public DateTime? FechaInstalacion { get; set; }

    //[Required]
    [StringLength(200)]
    public string? Funcion { get; set; } = string.Empty;

    [StringLength(200)]
    public string? DescripcionUbicacion { get; set; } = string.Empty;

    [StringLength(20)]
    public string? Equipment { get; set; } = string.Empty;

    [StringLength(20)]
    public string? Asset { get; set; } = string.Empty;

    public double? Longitud { get; set; }

    public double? LatitudInicio { get; set; }

    public double? LongitudInicio { get; set; }

    public double? LatitudFin { get; set; }

    public double? LongitudFin { get; set; }

    //[Required]
    [StringLength(50)]
    public string? Estado { get; set; } = string.Empty;

    public bool EsMarraneable { get; set; }

    public bool EstaParcialoTotalmenteEnterrada { get; set; }
    public bool EstaParcialoTotalmenteAerea { get; set; }
    #endregion Propiedades
    #region Propiedades de Navegación
    public Sistema Sistema { get; set; } = new();
    public TipoActivo TipoActivo { get; set; } = new();
    public List<PuntoInformacion> PuntosInformacion { get; set; } = [];
    #endregion

    public Activo()
    {
    }

    public Activo(Activo input)
    {
      Id = input.Id;
      TipoActivoId = input.TipoActivoId ?? string.Empty;
      SistemaId = input.SistemaId ?? string.Empty;
      Nombre = input.Nombre ?? string.Empty;
      Tag = input.Tag ?? string.Empty;
      Descripcion = input.Descripcion ?? string.Empty;
      PId = input.PId ?? string.Empty;
      FechaInstalacion = input.FechaInstalacion;
      Funcion = input.Funcion ?? string.Empty;
      DescripcionUbicacion = input.DescripcionUbicacion ?? string.Empty;
      Equipment = input.Equipment ?? string.Empty;
      Asset = input.Asset ?? string.Empty;
      Longitud = input.Longitud;
      LatitudInicio = input.LatitudInicio;
      LongitudInicio = input.LongitudInicio;
      LatitudFin = input.LatitudFin;
      LongitudFin = input.LongitudFin;
      Estado = input.Estado;
      EsMarraneable = input.EsMarraneable;
      EstaParcialoTotalmenteEnterrada = input.EstaParcialoTotalmenteEnterrada;
      EstaParcialoTotalmenteAerea = input.EstaParcialoTotalmenteAerea;
      TipoActivo = input.TipoActivo;
      PuntosInformacion = input.PuntosInformacion;
    }
  }
}
