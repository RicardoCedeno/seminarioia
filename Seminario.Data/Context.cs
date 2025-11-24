using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Server;
using Seminario.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Seminario.Data
{
  public class Context: DbContext
  {
    public Context(DbContextOptions<Context> options): base(options) { }

    public DbSet<Campo> Campos { get; set; }
    public DbSet<Sistema> Sistemas { get; set; }
    public DbSet<Activo> Activos { get; set; }
    public DbSet<TipoActivo> TiposActivo { get; set; }
    public DbSet<PuntoInformacion> PuntosInformacion { get; set; }
    public DbSet<MedicionComposicionAgua> MedicionComposicionAgua { get; set; }



    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);
      foreach (var entityType in builder.Model.GetEntityTypes())
      {
        string? table = entityType.GetTableName();
        if (table != null && table.StartsWith("AspNet"))
          entityType.SetTableName(table[6..]);
      };
      #region Borrados en cascada core
      
      builder.Entity<Activo>().HasMany(x => x.PuntosInformacion).WithOne(y => y.Activo).OnDelete(DeleteBehavior.Cascade);
      builder.Entity<Campo>().HasMany(x => x.Sistemas).WithOne(y => y.Campo).OnDelete(DeleteBehavior.Cascade);
      builder.Entity<Sistema>().HasMany(x => x.Activos).WithOne(y => y.Sistema).OnDelete(DeleteBehavior.Cascade);
      builder.Entity<TipoActivo>().HasMany(x => x.Activos).WithOne(y => y.TipoActivo).OnDelete(DeleteBehavior.Cascade);
      builder.Entity<PuntoInformacion>().HasMany(x => x.MedicionesComposicionAgua).WithOne(y => y.PuntoInformacion).OnDelete(DeleteBehavior.Cascade);
      #endregion Borrados en cascada core
      //builder.Entity<RelacionActivo>().HasMany(x => x.ConfiguracionesRelacionActivo).WithOne(y => y.RelacionActivo).OnDelete(DeleteBehavior.NoAction);
    }
  }
}
