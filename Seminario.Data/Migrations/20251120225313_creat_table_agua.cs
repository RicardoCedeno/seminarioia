using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Seminario.Data.Migrations
{
    /// <inheritdoc />
    public partial class creat_table_agua : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Campos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LatitudReferencia = table.Column<double>(type: "float", nullable: true),
                    LongitudReferencia = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposActivo",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposActivo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sistemas",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CampoId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sistemas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sistemas_Campos_CampoId",
                        column: x => x.CampoId,
                        principalTable: "Campos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Activos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TipoActivoId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SistemaId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Tag = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PId = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    FechaInstalacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Funcion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DescripcionUbicacion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Equipment = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Asset = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Longitud = table.Column<double>(type: "float", nullable: true),
                    LatitudInicio = table.Column<double>(type: "float", nullable: true),
                    LongitudInicio = table.Column<double>(type: "float", nullable: true),
                    LatitudFin = table.Column<double>(type: "float", nullable: true),
                    LongitudFin = table.Column<double>(type: "float", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EsMarraneable = table.Column<bool>(type: "bit", nullable: false),
                    EstaParcialoTotalmenteEnterrada = table.Column<bool>(type: "bit", nullable: false),
                    EstaParcialoTotalmenteAerea = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Activos_Sistemas_SistemaId",
                        column: x => x.SistemaId,
                        principalTable: "Sistemas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Activos_TiposActivo_TipoActivoId",
                        column: x => x.TipoActivoId,
                        principalTable: "TiposActivo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PuntosInformacion",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ActivoId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PuntosInformacion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PuntosInformacion_Activos_ActivoId",
                        column: x => x.ActivoId,
                        principalTable: "Activos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicionesComposicionAgua",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PuntoInformacionId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PH = table.Column<double>(type: "float", nullable: true),
                    DensidadDelAgua = table.Column<double>(type: "float", nullable: true),
                    Conductividad = table.Column<double>(type: "float", nullable: true),
                    HierroTotal = table.Column<double>(type: "float", nullable: true),
                    HierroSoluble = table.Column<double>(type: "float", nullable: true),
                    Cloruros = table.Column<double>(type: "float", nullable: true),
                    Sulfatos = table.Column<double>(type: "float", nullable: true),
                    Alcalinidad = table.Column<double>(type: "float", nullable: true),
                    DurezaTotal = table.Column<double>(type: "float", nullable: true),
                    DurezaCalcica = table.Column<double>(type: "float", nullable: true),
                    DurezaMagnesica = table.Column<double>(type: "float", nullable: true),
                    AceiteAgua = table.Column<double>(type: "float", nullable: true),
                    Silice = table.Column<double>(type: "float", nullable: true),
                    Amonio = table.Column<double>(type: "float", nullable: true),
                    Nitritos = table.Column<double>(type: "float", nullable: true),
                    Tan = table.Column<double>(type: "float", nullable: true),
                    TemperaturaMuestra = table.Column<double>(type: "float", nullable: true),
                    Acetate = table.Column<double>(type: "float", nullable: true),
                    Actinium = table.Column<double>(type: "float", nullable: true),
                    Aluminum = table.Column<double>(type: "float", nullable: true),
                    Amide = table.Column<double>(type: "float", nullable: true),
                    Arsenate = table.Column<double>(type: "float", nullable: true),
                    Arsenite = table.Column<double>(type: "float", nullable: true),
                    Barium = table.Column<double>(type: "float", nullable: true),
                    Beryllium = table.Column<double>(type: "float", nullable: true),
                    Bicarbonate = table.Column<double>(type: "float", nullable: true),
                    Bisulfide = table.Column<double>(type: "float", nullable: true),
                    Bisulfite = table.Column<double>(type: "float", nullable: true),
                    Boron = table.Column<double>(type: "float", nullable: true),
                    Bromate = table.Column<double>(type: "float", nullable: true),
                    Bromide = table.Column<double>(type: "float", nullable: true),
                    Cadmium = table.Column<double>(type: "float", nullable: true),
                    Calcium = table.Column<double>(type: "float", nullable: true),
                    Carbonate = table.Column<double>(type: "float", nullable: true),
                    Cesium = table.Column<double>(type: "float", nullable: true),
                    Chlorate = table.Column<double>(type: "float", nullable: true),
                    Chloride = table.Column<double>(type: "float", nullable: true),
                    Chlorite = table.Column<double>(type: "float", nullable: true),
                    Chromate = table.Column<double>(type: "float", nullable: true),
                    ChromiumIII = table.Column<double>(type: "float", nullable: true),
                    Citrate = table.Column<double>(type: "float", nullable: true),
                    CobaltII = table.Column<double>(type: "float", nullable: true),
                    CobaltIII = table.Column<double>(type: "float", nullable: true),
                    CopperI = table.Column<double>(type: "float", nullable: true),
                    CopperII = table.Column<double>(type: "float", nullable: true),
                    Cyanate = table.Column<double>(type: "float", nullable: true),
                    Cyanide = table.Column<double>(type: "float", nullable: true),
                    Dichromate = table.Column<double>(type: "float", nullable: true),
                    Ferricyanide = table.Column<double>(type: "float", nullable: true),
                    Fluoride = table.Column<double>(type: "float", nullable: true),
                    GoldI = table.Column<double>(type: "float", nullable: true),
                    GoldIII = table.Column<double>(type: "float", nullable: true),
                    Hydride = table.Column<double>(type: "float", nullable: true),
                    Hydrogen = table.Column<double>(type: "float", nullable: true),
                    HydrogenCarbonate = table.Column<double>(type: "float", nullable: true),
                    HydrogenSulfate = table.Column<double>(type: "float", nullable: true),
                    Hydroxide = table.Column<double>(type: "float", nullable: true),
                    Hypochlorite = table.Column<double>(type: "float", nullable: true),
                    Iodate = table.Column<double>(type: "float", nullable: true),
                    Iodide = table.Column<double>(type: "float", nullable: true),
                    IronII = table.Column<double>(type: "float", nullable: true),
                    IronIII = table.Column<double>(type: "float", nullable: true),
                    LeadI = table.Column<double>(type: "float", nullable: true),
                    LeadII = table.Column<double>(type: "float", nullable: true),
                    LeadIV = table.Column<double>(type: "float", nullable: true),
                    Lithium = table.Column<double>(type: "float", nullable: true),
                    Magnesium = table.Column<double>(type: "float", nullable: true),
                    ManganeseII = table.Column<double>(type: "float", nullable: true),
                    ManganeseIII = table.Column<double>(type: "float", nullable: true),
                    MercuryI = table.Column<double>(type: "float", nullable: true),
                    MercuryII = table.Column<double>(type: "float", nullable: true),
                    NickelII = table.Column<double>(type: "float", nullable: true),
                    NickelIV = table.Column<double>(type: "float", nullable: true),
                    Nitrate = table.Column<double>(type: "float", nullable: true),
                    Nitride = table.Column<double>(type: "float", nullable: true),
                    Nitrite = table.Column<double>(type: "float", nullable: true),
                    Oxalate = table.Column<double>(type: "float", nullable: true),
                    Oxide = table.Column<double>(type: "float", nullable: true),
                    Perchlorate = table.Column<double>(type: "float", nullable: true),
                    Permanganate = table.Column<double>(type: "float", nullable: true),
                    Phosphate = table.Column<double>(type: "float", nullable: true),
                    Phosphide = table.Column<double>(type: "float", nullable: true),
                    Phosphite = table.Column<double>(type: "float", nullable: true),
                    Potassium = table.Column<double>(type: "float", nullable: true),
                    Silicate = table.Column<double>(type: "float", nullable: true),
                    Silver = table.Column<double>(type: "float", nullable: true),
                    Sodium = table.Column<double>(type: "float", nullable: true),
                    Strontium = table.Column<double>(type: "float", nullable: true),
                    Sulfate = table.Column<double>(type: "float", nullable: true),
                    Sulfide = table.Column<double>(type: "float", nullable: true),
                    Sulfite = table.Column<double>(type: "float", nullable: true),
                    Tartrate = table.Column<double>(type: "float", nullable: true),
                    Tetraborate = table.Column<double>(type: "float", nullable: true),
                    Thiocyanate = table.Column<double>(type: "float", nullable: true),
                    Thiosulfate = table.Column<double>(type: "float", nullable: true),
                    TinII = table.Column<double>(type: "float", nullable: true),
                    TinIV = table.Column<double>(type: "float", nullable: true),
                    Vanadium = table.Column<double>(type: "float", nullable: true),
                    Zinc = table.Column<double>(type: "float", nullable: true),
                    O2 = table.Column<double>(type: "float", nullable: true),
                    CO2 = table.Column<double>(type: "float", nullable: true),
                    H2S = table.Column<double>(type: "float", nullable: true),
                    ResidualInhibidorCorrosion = table.Column<double>(type: "float", nullable: true),
                    ResidualInhibidorIncrustacion = table.Column<double>(type: "float", nullable: true),
                    ResidualBiocida = table.Column<double>(type: "float", nullable: true),
                    ResidualEliminox = table.Column<double>(type: "float", nullable: true),
                    ResidualAmina = table.Column<double>(type: "float", nullable: true),
                    AcidoAcetico = table.Column<double>(type: "float", nullable: true),
                    AcidoButirico = table.Column<double>(type: "float", nullable: true),
                    AcidoFormico = table.Column<double>(type: "float", nullable: true),
                    AcidoPropionico = table.Column<double>(type: "float", nullable: true),
                    AcidoValerico = table.Column<double>(type: "float", nullable: true),
                    SolidosDisueltosTotales = table.Column<double>(type: "float", nullable: true),
                    SolidosDisueltosVolatilesTotales = table.Column<double>(type: "float", nullable: true),
                    SolidosSuspendidosTotales = table.Column<double>(type: "float", nullable: true),
                    BacteriasProductorasAcido = table.Column<double>(type: "float", nullable: true),
                    BacteriasSulfatoReductoras = table.Column<double>(type: "float", nullable: true),
                    BacteriasHeterotrofasTotales = table.Column<double>(type: "float", nullable: true),
                    BacteriasAnaerobiasTotales = table.Column<double>(type: "float", nullable: true),
                    BacteriasTotales = table.Column<double>(type: "float", nullable: true),
                    BacteriasProductorasAcidoSesiles = table.Column<double>(type: "float", nullable: true),
                    BacteriasSulfatoReductorasSesiles = table.Column<double>(type: "float", nullable: true),
                    BacteriasHeterotrofasTotalesSesiles = table.Column<double>(type: "float", nullable: true),
                    BacteriasAnaerobiasSesilesTotales = table.Column<double>(type: "float", nullable: true),
                    Ferrobacterias = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicionesComposicionAgua", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicionesComposicionAgua_PuntosInformacion_PuntoInformacionId",
                        column: x => x.PuntoInformacionId,
                        principalTable: "PuntosInformacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activos_SistemaId",
                table: "Activos",
                column: "SistemaId");

            migrationBuilder.CreateIndex(
                name: "IX_Activos_TipoActivoId",
                table: "Activos",
                column: "TipoActivoId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicionesComposicionAgua_PuntoInformacionId",
                table: "MedicionesComposicionAgua",
                column: "PuntoInformacionId");

            migrationBuilder.CreateIndex(
                name: "IX_PuntosInformacion_ActivoId",
                table: "PuntosInformacion",
                column: "ActivoId");

            migrationBuilder.CreateIndex(
                name: "IX_Sistemas_CampoId",
                table: "Sistemas",
                column: "CampoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicionesComposicionAgua");

            migrationBuilder.DropTable(
                name: "PuntosInformacion");

            migrationBuilder.DropTable(
                name: "Activos");

            migrationBuilder.DropTable(
                name: "Sistemas");

            migrationBuilder.DropTable(
                name: "TiposActivo");

            migrationBuilder.DropTable(
                name: "Campos");
        }
    }
}
