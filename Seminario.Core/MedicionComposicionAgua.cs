using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminario.Core
{
  [Table("MedicionComposicionAgua")]
  public class MedicionComposicionAgua
  {
    [Key]
    public string Id { get; set; } = string.Empty;
    //public int? USUARIO_CAMPO_ID { get; set; }
    [ForeignKey("PuntoInformacion")]
    public string PuntoInformacionId { get; set; } = string.Empty;
    public DateTime Fecha { get; set; }
    public double? PH { get; set; }
    public double? DensidadDelAgua { get; set; }
    public double? Conductividad { get; set; }
    public double? HierroTotal { get; set; }
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
    public double? TemperaturaMuestra { get; set; }

    #region Analisis elemental

    public double? Acetate { get; set; }
    public double? Actinium { get; set; }
    public double? Aluminum { get; set; }
    public double? Amide { get; set; }
    //public double? Ammonium { get; set; }
    public double? Arsenate { get; set; }
    public double? Arsenite { get; set; }
    public double? Barium { get; set; }
    public double? Beryllium { get; set; }
    public double? Bicarbonate { get; set; }
    public double? Bisulfide { get; set; }
    public double? Bisulfite { get; set; }
    public double? Boron { get; set; }
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
    public double? Vanadium { get; set; }
    public double? Zinc { get; set; }


    #endregion

    #region Gases Disueltos

    /// <summary>
    /// O2 Disuelto
    /// </summary>
    public double? O2 { get; set; }

    /// <summary>
    /// Co2 Disuelto
    /// </summary>
    public double? CO2 { get; set; }

    /// <summary>
    /// H2S Disuelto
    /// </summary>
    public double? H2S { get; set; }

    #endregion

    #region Residuales Quimicos

    /// <summary>
    /// 
    /// </summary>
    public double? ResidualInhibidorCorrosion { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public double? ResidualInhibidorIncrustacion { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public double? ResidualBiocida { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public double? ResidualEliminox { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public double? ResidualAmina { get; set; }

    #endregion

    #region Acidos Organicos

    /// <summary>
    /// CH3COOH
    /// </summary>
    public double? AcidoAcetico { get; set; }

    /// <summary>
    /// C4H8O2
    /// </summary>
    public double? AcidoButirico { get; set; }

    /// <summary>
    /// CH2O2
    /// </summary>
    public double? AcidoFormico { get; set; }

    /// <summary>
    /// CH3CH2COOH
    /// </summary>
    public double? AcidoPropionico { get; set; }

    /// <summary>
    /// C5H10O2
    /// </summary>
    public double? AcidoValerico { get; set; }

    #endregion

    #region Sólidos

    public double? SolidosDisueltosTotales { get; set; }

    public double? SolidosDisueltosVolatilesTotales { get; set; }

    public double? SolidosSuspendidosTotales { get; set; }

    #endregion

    #region Bacterias plantonicas

    /// <summary>
    /// bpa/ml
    /// </summary>
    public double? BacteriasProductorasAcido { get; set; }

    /// <summary>
    /// bsr/ml
    /// </summary>
    public double? BacteriasSulfatoReductoras { get; set; }

    /// <summary>
    /// bht/ml
    /// </summary>
    public double? BacteriasHeterotrofasTotales { get; set; }

    /// <summary>
    /// bAnT/ml
    /// </summary>
    public double? BacteriasAnaerobiasTotales { get; set; }


    /// <summary>
    /// Bacterias Totales
    /// </summary>
    public double? BacteriasTotales { get; set; }

    #endregion

    #region Bacterias plantonicas Sésiles

    /// <summary>
    /// bpa/ml
    /// </summary>
    public double? BacteriasProductorasAcidoSesiles { get; set; }

    /// <summary>
    /// bsr/ml
    /// </summary>
    public double? BacteriasSulfatoReductorasSesiles { get; set; }

    /// <summary>
    /// bht/ml
    /// </summary>
    public double? BacteriasHeterotrofasTotalesSesiles { get; set; }

    /// <summary>
    /// bAnT/ml
    /// </summary>
    public double? BacteriasAnaerobiasSesilesTotales { get; set; }


    /// <summary>
    /// Ferrobacterias
    /// </summary>
    public string Ferrobacterias { get; set; } = string.Empty;

    #endregion

    public string Observaciones { get; set; } = string.Empty;
    public PuntoInformacion PuntoInformacion { get; set; } = new();

    public MedicionComposicionAgua()
    {
    }
    public MedicionComposicionAgua(MedicionComposicionAgua input)
    {
      Id = input.Id;
      //USUARIO_CAMPO_ID
      PuntoInformacionId = input.PuntoInformacionId;
      Fecha = input.Fecha;
      PH = input.PH;
      DensidadDelAgua = input.DensidadDelAgua;
      Conductividad = input.Conductividad;
      HierroTotal = input.HierroTotal;
      HierroSoluble = input.HierroSoluble;
      Cloruros = input.Cloruros;
      Sulfatos = input.Sulfatos;
      Alcalinidad = input.Alcalinidad;
      DurezaTotal = input.DurezaTotal;
      DurezaCalcica = input.DurezaCalcica;
      DurezaMagnesica = input.DurezaMagnesica;
      AceiteAgua = input.AceiteAgua;
      Silice = input.Silice;
      Amonio = input.Amonio;
      Nitritos = input.Nitritos;
      Tan = input.Tan;
      TemperaturaMuestra = input.TemperaturaMuestra;
      Acetate = input.Acetate;
      Actinium = input.Actinium;
      Aluminum = input.Aluminum;
      Amide = input.Amide;
      //Ammonium { get; set; }
      Arsenate = input.Arsenate;
      Arsenite = input.Arsenite;
      Barium = input.Barium;
      Beryllium = input.Beryllium;
      Bicarbonate = input.Bicarbonate;
      Bisulfide = input.Bisulfide;
      Bisulfite = input.Bisulfite;
      Boron = input.Boron;
      Bromate = input.Bromate;
      Bromide = input.Bromide;
      Cadmium = input.Cadmium;
      Calcium = input.Calcium;
      Carbonate = input.Carbonate;
      Cesium = input.Cesium;
      Chlorate = input.Chlorate;
      Chloride = input.Chloride;
      Chlorite = input.Chlorite;
      Chromate = input.Chromate;
      ChromiumIII = input.ChromiumIII;
      Citrate = input.Citrate;
      CobaltII = input.CobaltII;
      CobaltIII = input.CobaltIII;
      CopperI = input.CopperI;
      CopperII = input.CopperII;
      Cyanate = input.Cyanate;
      Cyanide = input.Cyanide;
      Dichromate = input.Dichromate;
      Ferricyanide = input.Ferricyanide;
      Fluoride = input.Fluoride;
      GoldI = input.GoldI;
      GoldIII = input.GoldIII;
      Hydride = input.Hydride;
      Hydrogen = input.Hydrogen;
      HydrogenCarbonate = input.HydrogenCarbonate;
      HydrogenSulfate = input.HydrogenSulfate;
      Hydroxide = input.Hydroxide;
      Hypochlorite = input.Hypochlorite;
      Iodate = input.Iodate;
      Iodide = input.Iodide;
      IronII = input.IronII;
      IronIII = input.IronIII;
      LeadI = input.LeadI;
      LeadII = input.LeadII;
      LeadIV = input.LeadIV;
      Lithium = input.Lithium;
      Magnesium = input.Magnesium;
      ManganeseII = input.ManganeseII;
      ManganeseIII = input.ManganeseIII;
      MercuryI = input.MercuryI;
      MercuryII = input.MercuryII;
      NickelII = input.NickelII;
      NickelIV = input.NickelIV;
      Nitrate = input.Nitrate;
      Nitride = input.Nitride;
      Nitrite = input.Nitrite;
      Oxalate = input.Oxalate;
      Oxide = input.Oxide;
      Perchlorate = input.Perchlorate;
      Permanganate = input.Permanganate;
      Phosphate = input.Phosphate;
      Phosphide = input.Phosphide;
      Phosphite = input.Phosphite;
      Potassium = input.Potassium;
      Silicate = input.Silicate;
      Silver = input.Silver;
      Sodium = input.Sodium;
      Strontium = input.Strontium;
      Sulfate = input.Sulfate;
      Sulfide = input.Sulfide;
      Sulfite = input.Sulfite;
      Tartrate = input.Tartrate;
      Tetraborate = input.Tetraborate;
      Thiocyanate = input.Thiocyanate;
      Thiosulfate = input.Thiosulfate;
      TinII = input.TinII;
      TinIV = input.TinIV;
      Vanadium = input.Vanadium;
      Zinc = input.Zinc;
      O2 = input.O2;
      CO2 = input.CO2;
      H2S = input.H2S;
      ResidualInhibidorCorrosion = input.ResidualInhibidorCorrosion;
      ResidualInhibidorIncrustacion = input.ResidualInhibidorIncrustacion;
      ResidualBiocida = input.ResidualBiocida;
      ResidualEliminox = input.ResidualEliminox;
      ResidualAmina = input.ResidualAmina;
      AcidoAcetico = input.AcidoAcetico;
      AcidoButirico = input.AcidoButirico;
      AcidoFormico = input.AcidoFormico;
      AcidoPropionico = input.AcidoPropionico;
      AcidoValerico = input.AcidoValerico;
      SolidosDisueltosTotales = input.SolidosDisueltosTotales;
      SolidosDisueltosVolatilesTotales = input.SolidosDisueltosVolatilesTotales;
      SolidosSuspendidosTotales = input.SolidosSuspendidosTotales;
      BacteriasProductorasAcido = input.BacteriasProductorasAcido;
      BacteriasSulfatoReductoras = input.BacteriasSulfatoReductoras;
      BacteriasHeterotrofasTotales = input.BacteriasHeterotrofasTotales;
      BacteriasAnaerobiasTotales = input.BacteriasAnaerobiasTotales;
      BacteriasTotales = input.BacteriasTotales;
      BacteriasProductorasAcidoSesiles = input.BacteriasProductorasAcidoSesiles;
      BacteriasSulfatoReductorasSesiles = input.BacteriasSulfatoReductorasSesiles;
      BacteriasHeterotrofasTotalesSesiles = input.BacteriasHeterotrofasTotalesSesiles;
      BacteriasAnaerobiasSesilesTotales = input.BacteriasAnaerobiasSesilesTotales;
      Ferrobacterias = input.Ferrobacterias;
      Observaciones = input.Observaciones;
      PuntoInformacion = input.PuntoInformacion;
    }
  }

}
