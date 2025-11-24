using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminario.Core
{
  public class MedicionComposicionAguaDto
  {
    public string? Id { get; set; }
    public string PuntoInformacionId { get; set; } = string.Empty;
    public string? NombrePuntoInformacion { get; set; }
    public string? NombreActivo { get; set; }
    public string? NombreSistema { get; set; }
    public DateTime Fecha { get; set; }
    public double? Ph { get; set; }
    public double? Conductividad { get; set; }
    public double? HierroSoluble { get; set; }
    public double? Cloruros { get; set; }
    public double? Sulfatos { get; set; }
    public double? Alcalinidad { get; set; }
    public double? DurezaTotal { get; set; }
    public double? DurezaCalcica { get; set; }
    public double? DurezaMagnesica { get; set; }
    public double? AceiteAgua { get; set; }
    public double? Silice { get; set; }
    public double? Amonio { get; set; }
    public double? Nitritos { get; set; }
    public double? Tan { get; set; }
    public double? Acetate { get; set; }
    public double? Aluminum { get; set; }
    public double? Amide { get; set; }
    public double? Arsenate { get; set; }
    public double? Arsenite { get; set; }
    public double? Barium { get; set; }
    public double? Beryllium { get; set; }
    public double? Bicarbonate { get; set; }
    public double? Bisulfide { get; set; }
    public double? Bisulfite { get; set; }
    public double? Bromate { get; set; }
    public double? Bromide { get; set; }
    public double? Cadmium { get; set; }
    public double? Calcium { get; set; }
    public double? Carbonate { get; set; }
    public double? Cesium { get; set; }
    public double? Chlorate { get; set; }
    public double? Chloride { get; set; }
    public double? Chlorite { get; set; }
    public double? Chromate { get; set; }
    public double? ChromiumIII { get; set; }
    public double? Citrate { get; set; }
    public double? CobaltII { get; set; }
    public double? CobaltIII { get; set; }
    public double? CopperI { get; set; }
    public double? CopperII { get; set; }
    public double? Cyanate { get; set; }
    public double? Cyanide { get; set; }
    public double? Dichromate { get; set; }
    public double? Ferricyanide { get; set; }
    public double? Fluoride { get; set; }
    public double? GoldI { get; set; }
    public double? GoldIII { get; set; }
    public double? Hydride { get; set; }
    public double? Hydrogen { get; set; }
    public double? HydrogenCarbonate { get; set; }
    public double? HydrogenSulfate { get; set; }
    public double? Hydroxide { get; set; }
    public double? Hypochlorite { get; set; }
    public double? Iodate { get; set; }
    public double? Iodide { get; set; }
    public double? IronII { get; set; }
    public double? IronIII { get; set; }
    public double? LeadI { get; set; }
    public double? LeadII { get; set; }
    public double? LeadIV { get; set; }
    public double? Lithium { get; set; }
    public double? Magnesium { get; set; }
    public double? ManganeseII { get; set; }
    public double? ManganeseIII { get; set; }
    public double? MercuryI { get; set; }
    public double? MercuryII { get; set; }
    public double? NickelII { get; set; }
    public double? NickelIV { get; set; }
    public double? Nitrate { get; set; }
    public double? Nitride { get; set; }
    public double? Nitrite { get; set; }
    public double? Oxalate { get; set; }
    public double? Oxide { get; set; }
    public double? Perchlorate { get; set; }
    public double? Permanganate { get; set; }
    public double? Phosphate { get; set; }
    public double? Phosphide { get; set; }
    public double? Phosphite { get; set; }
    public double? Potassium { get; set; }
    public double? Silicate { get; set; }
    public double? Silver { get; set; }
    public double? Sodium { get; set; }
    public double? Strontium { get; set; }
    public double? Sulfate { get; set; }
    public double? Sulfide { get; set; }
    public double? Sulfite { get; set; }
    public double? Tartrate { get; set; }
    public double? Tetraborate { get; set; }
    public double? Thiocyanate { get; set; }
    public double? Thiosulfate { get; set; }
    public double? TinII { get; set; }
    public double? TinIV { get; set; }
    public double? Zinc { get; set; }
    public double? O2 { get; set; }
    public double? CO2 { get; set; }
    public double? H2S { get; set; }
    public double? ResidualInhibidorCorrosion { get; set; }
    public double? ResidualInhibidorIncrustacion { get; set; }
    public double? ResidualBiocida { get; set; }
    public double? ResidualEliminox { get; set; }
    public double? ResidualAmina { get; set; }
    public double? AcidoAcetico { get; set; }
    public double? AcidoButirico { get; set; }
    public double? AcidoFormico { get; set; }
    public double? AcidoPropionico { get; set; }
    public double? AcidoValerico { get; set; }
    public double? SolidosDisueltosTotales { get; set; }
    public double? SolidosDisueltosVolatilesTotales { get; set; }
    public double? SolidosSuspendidosTotales { get; set; }
    public double? BacteriasProductorasAcido { get; set; }
    public double? BacteriasSulfatoReductoras { get; set; }
    public double? BacteriasHeterotrofasTotales { get; set; }
    public double? BacteriasAnaerobiasTotales { get; set; }
    public double? BacteriasTotales { get; set; }
    public double? BacteriasProductorasAcidoSesiles { get; set; }
    public double? BacteriasSulfatoReductorasSesiles { get; set; }
    public double? BacteriasHeterotrofasTotalesSesiles { get; set; }
    public double? BacteriasAnaerobiasSesilesTotales { get; set; }
    public string Ferrobacterias { get; set; } = string.Empty;
    public double? Actinium { get; set; }
    public double? Boron { get; set; }
    public double? DensidadDelAgua { get; set; }
    public double? TemperaturaMuestra { get; set; }
    public double? Vanadium { get; set; }
    public double? HierroTotal { get; set; }
    public string Observaciones { get; set; } = string.Empty;
    public bool EsMasivo { get; set; }
  }
}
