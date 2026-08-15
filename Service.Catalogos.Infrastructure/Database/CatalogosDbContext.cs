using Microsoft.EntityFrameworkCore;
using Service.Catalogos.Domain.Entities;

namespace Service.Catalogos.Infrastructure.Database;

public class CatalogosDbContext : DbContext
{
    public DbSet<Ubigeo> Ubigeo => Set<Ubigeo>();
    public DbSet<Moneda> Moneda => Set<Moneda>();
    public DbSet<TipoCambio> TipoCambio => Set<TipoCambio>();
    public DbSet<TipoRelacion> TipoRelacion => Set<TipoRelacion>();
    public DbSet<EstadoComprobante> EstadoComprobante => Set<EstadoComprobante>();
    public DbSet<TipoDocIdentidad> TipoDocIdentidad => Set<TipoDocIdentidad>();
    public DbSet<TipoDocumentoModif> TipoDocumentoModif => Set<TipoDocumentoModif>();
    public DbSet<TipoCp> TipoCp => Set<TipoCp>();
    public DbSet<TipoNota> TipoNota => Set<TipoNota>();
    public DbSet<TipoOperacion> TipoOperacion => Set<TipoOperacion>();
    public DbSet<ClasifBssSss> ClasifBssSss => Set<ClasifBssSss>();
    public DbSet<UnidadMedida> UnidadMedida => Set<UnidadMedida>();
    public DbSet<ProyectoInversion> ProyectoInversion => Set<ProyectoInversion>();
    public DbSet<DetraccionServicio> DetraccionServicio => Set<DetraccionServicio>();

    public CatalogosDbContext(DbContextOptions<CatalogosDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("catalogo");

        modelBuilder.Entity<Ubigeo>(entity =>
        {
            entity.ToTable("ubigeo");
            entity.HasKey(e => e.CodigoUbigeo);
            entity.Property(e => e.CodigoUbigeo).HasColumnName("codigo_ubigeo").HasMaxLength(6).IsRequired();
            entity.Property(e => e.CodigoDepartamento).HasColumnName("codigo_departamento").HasMaxLength(2).IsRequired();
            entity.Property(e => e.Departamento).HasColumnName("departamento").HasMaxLength(100).IsRequired();
            entity.Property(e => e.CodigoProvincia).HasColumnName("codigo_provincia").HasMaxLength(4);
            entity.Property(e => e.Provincia).HasColumnName("provincia").HasMaxLength(100);
            entity.Property(e => e.CodigoDistrito).HasColumnName("codigo_distrito").HasMaxLength(6);
            entity.Property(e => e.Distrito).HasColumnName("distrito").HasMaxLength(100);
        });

        modelBuilder.Entity<Moneda>(entity =>
        {
            entity.ToTable("moneda");
            entity.HasKey(e => e.CodigoIso);
            entity.Property(e => e.CodigoIso).HasColumnName("codigo_iso").HasMaxLength(3).IsRequired();
            entity.Property(e => e.Nombre).HasColumnName("nombre").HasMaxLength(50).IsRequired();
            entity.Property(e => e.Simbolo).HasColumnName("simbolo").HasMaxLength(5).IsRequired();
            entity.Property(e => e.EsMonedaNacional).HasColumnName("es_moneda_nacional").HasDefaultValue(false);
        });

        modelBuilder.Entity<TipoCambio>(entity =>
        {
            entity.ToTable("tipo_cambio");
            entity.HasKey(e => new { e.CodigoMonedaOrigen, e.CodigoMonedaDestino, e.Fecha });
            entity.Property(e => e.CodigoMonedaOrigen).HasColumnName("codigo_moneda_origen").HasMaxLength(3).IsRequired();
            entity.Property(e => e.CodigoMonedaDestino).HasColumnName("codigo_moneda_destino").HasMaxLength(3).IsRequired();
            entity.Property(t => t.Fecha).HasColumnName("fecha").HasColumnType("date").IsRequired();
            entity.Property(t => t.PrecioCompra).HasColumnName("precio_compra").HasColumnType("numeric(5, 3)").IsRequired();
            entity.Property(t => t.PrecioVenta).HasColumnName("precio_venta").HasColumnType("numeric(5, 3)").IsRequired();
            entity.Property(e => e.CreadoPor).HasColumnName("creado_por").HasMaxLength(150);
            entity.Property(e => e.FechaCreacion).HasColumnName("fecha_creacion");
            entity.Property(e => e.ModificadoPor).HasColumnName("modificado_por").HasMaxLength(150);
            entity.Property(e => e.FechaModificacion).HasColumnName("fecha_modificacion");
            entity.Property(e => e.Activo).HasColumnName("activo").IsRequired().HasDefaultValue(true);
            entity.HasQueryFilter(e => e.Activo);
            entity.HasOne<Moneda>()
                .WithMany()
                .HasForeignKey("CodigoMonedaOrigen")
                .HasConstraintName("fk_tipo_cambio_moneda_origen");
            entity.HasOne<Moneda>()
                .WithMany()
                .HasForeignKey("CodigoMonedaDestino")
                .HasConstraintName("fk_tipo_cambio_moneda_destino");
        });

        modelBuilder.Entity<TipoRelacion>(entity =>
        {
            entity.ToTable("tipo_relacion");
            entity.HasKey(e => e.Codigo);
            entity.Property(e => e.Codigo).HasColumnName("codigo").HasMaxLength(5).IsRequired();
            entity.Property(e => e.Descripcion).HasColumnName("descripcion").HasMaxLength(200).IsRequired();
        });

        modelBuilder.Entity<EstadoComprobante>(entity =>
        {
            entity.ToTable("estado_comprobante");
            entity.HasKey(e => e.Codigo);
            entity.Property(e => e.Codigo).HasColumnName("codigo").HasMaxLength(2).IsRequired();
            entity.Property(e => e.Nombre).HasColumnName("nombre").HasMaxLength(60).IsRequired();
            entity.Property(e => e.Descripcion).HasColumnName("descripcion").HasMaxLength(200);
        });

        modelBuilder.Entity<TipoDocIdentidad>(entity =>
        {
            entity.ToTable("tipo_doc_identidad");
            entity.HasKey(e => e.Codigo);
            entity.Property(e => e.Codigo).HasColumnName("codigo").HasMaxLength(2).IsRequired();
            entity.Property(e => e.Nombre).HasColumnName("nombre").HasMaxLength(60).IsRequired();
            entity.Property(e => e.LongitudMin).HasColumnName("longitud_min").IsRequired();
            entity.Property(e => e.LongitudMax).HasColumnName("longitud_max").IsRequired();
            entity.Property(e => e.EsRuc).HasColumnName("es_ruc").HasDefaultValue(false);
        });

        modelBuilder.Entity<TipoDocumentoModif>(entity =>
        {
            entity.ToTable("tipo_documento_modif");
            entity.HasKey(e => e.Codigo);
            entity.Property(e => e.Codigo).HasColumnName("codigo").HasMaxLength(10).IsRequired();
            entity.Property(e => e.Descripcion).HasColumnName("descripcion").HasMaxLength(100).IsRequired();
        });

        modelBuilder.Entity<TipoCp>(entity =>
        {
            entity.ToTable("tipo_cp");
            entity.HasKey(e => e.Codigo);
            entity.Property(e => e.Codigo).HasColumnName("codigo").HasMaxLength(2).IsRequired();
            entity.Property(e => e.Nombre).HasColumnName("nombre").HasMaxLength(60).IsRequired();
            entity.Property(e => e.Naturaleza).HasColumnName("naturaleza").HasColumnType("char(1)").IsRequired();
            entity.Property(e => e.AplicaA).HasColumnName("aplica_a").HasMaxLength(2);
            entity.Property(e => e.Signo).HasColumnName("signo").HasColumnType("char(1)").HasDefaultValue('+');
        });

        modelBuilder.Entity<TipoNota>(entity =>
        {
            entity.ToTable("tipo_nota");
            entity.HasKey(e => e.Codigo);
            entity.Property(e => e.Codigo).HasColumnName("codigo").HasMaxLength(2).IsRequired();
            entity.Property(e => e.Descripcion).HasColumnName("descripcion").HasMaxLength(200).IsRequired();
            entity.Property(e => e.AplicaA).HasColumnName("aplica_a").HasMaxLength(2).IsRequired();
            entity.Property(e => e.Signo).HasColumnName("signo").HasColumnType("char(1)").HasDefaultValue('-');
        });

        modelBuilder.Entity<TipoOperacion>(entity =>
        {
            entity.ToTable("tipo_operacion");
            entity.HasKey(e => e.Codigo);
            entity.Property(e => e.Codigo).HasColumnName("codigo").HasMaxLength(4).IsRequired();
            entity.Property(e => e.Descripcion).HasColumnName("descripcion").HasMaxLength(200).IsRequired();
            entity.Property(e => e.EsExportacion).HasColumnName("es_exportacion").HasDefaultValue(false);
            entity.Property(e => e.EsDetraccion).HasColumnName("es_detraccion").HasDefaultValue(false);
            entity.Property(e => e.EsPercepcion).HasColumnName("es_percepcion").HasDefaultValue(false);
        });

        modelBuilder.Entity<ClasifBssSss>(entity =>
        {
            entity.ToTable("clasif_bss_sss");
            entity.HasKey(e => e.Codigo);
            entity.Property(e => e.Codigo).HasColumnName("codigo").HasMaxLength(5).IsRequired();
            entity.Property(e => e.Nombre).HasColumnName("nombre").HasMaxLength(100).IsRequired();
            entity.Property(e => e.Descripcion).HasColumnName("descripcion").HasMaxLength(500);
        });

        modelBuilder.Entity<UnidadMedida>(entity =>
        {
            entity.ToTable("unidad_medida");
            entity.HasKey(e => e.Codigo);
            entity.Property(e => e.Codigo).HasColumnName("codigo").HasMaxLength(10).IsRequired();
            entity.Property(e => e.Nombre).HasColumnName("nombre").HasMaxLength(100).IsRequired();
        });

        modelBuilder.Entity<ProyectoInversion>(entity =>
        {
            entity.ToTable("proyecto_inversion");
            entity.HasKey(e => e.Codigo);
            entity.Property(e => e.Codigo).HasColumnName("codigo").HasMaxLength(5).IsRequired();
            entity.Property(e => e.Descripcion).HasColumnName("descripcion").HasMaxLength(200).IsRequired();
            entity.Property(e => e.CreadoPor).HasColumnName("creado_por").HasMaxLength(150);
            entity.Property(e => e.FechaCreacion).HasColumnName("fecha_creacion");
            entity.Property(e => e.ModificadoPor).HasColumnName("modificado_por").HasMaxLength(150);
            entity.Property(e => e.FechaModificacion).HasColumnName("fecha_modificacion");
            entity.Property(e => e.Activo).HasColumnName("activo").IsRequired().HasDefaultValue(true);
            entity.HasQueryFilter(e => e.Activo);
        });

        modelBuilder.Entity<DetraccionServicio>(entity =>
        {
            entity.ToTable("detraccion_servicio");
            entity.HasKey(e => e.Codigo);
            entity.Property(e => e.Codigo).HasColumnName("codigo").HasMaxLength(5).IsRequired();
            entity.Property(e => e.Descripcion).HasColumnName("descripcion").HasMaxLength(200).IsRequired();
            entity.Property(e => e.Porcentaje).HasColumnName("porcentaje").HasColumnType("numeric(5,2)").IsRequired();
            entity.Property(e => e.BienServicio).HasColumnName("bien_servicio").HasColumnType("char(1)").IsRequired();
            entity.Property(e => e.FechaVigencia).HasColumnName("fecha_vigencia").HasColumnType("date").IsRequired();
            entity.Property(e => e.CreadoPor).HasColumnName("creado_por").HasMaxLength(150);
            entity.Property(e => e.FechaCreacion).HasColumnName("fecha_creacion");
            entity.Property(e => e.ModificadoPor).HasColumnName("modificado_por").HasMaxLength(150);
            entity.Property(e => e.FechaModificacion).HasColumnName("fecha_modificacion");
            entity.Property(e => e.Activo).HasColumnName("activo").IsRequired().HasDefaultValue(true);
            entity.HasQueryFilter(e => e.Activo);
        });
    }
}