using Microsoft.EntityFrameworkCore;

namespace TeCreemos.Models.DB
{
    public partial class TeCreemosDb : DbContext
    {
        public TeCreemosDb()
        {
        }

        public TeCreemosDb(DbContextOptions<TeCreemosDb> options)
            : base(options)
        {
        }

        public virtual DbSet<CatClientes> Clientes { get; set; }
        public virtual DbSet<ClienteIdentificacion> ClienteIdentificacions { get; set; }
        public virtual DbSet<CuentaCliente> Cuenta { get; set; }
        public virtual DbSet<CatEstatus> Estatuses { get; set; }
        public virtual DbSet<Movimientos> Movimientos { get; set; }
        public virtual DbSet<TipoCuenta> TipoCuenta { get; set; }
        public virtual DbSet<TipoIdentificacion> TipoIdentificacions { get; set; }
        public virtual DbSet<TipoMovimiento> TipoMovimientos { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=JORGE; Database=TeCreemos_DB; uid=sa;pwd=admin;Trusted_Connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<CatClientes>(entity =>
            {
                entity.HasKey(e => e.IdCliente);

                entity.ToTable("Cliente");

                entity.HasIndex(e => e.Clave, "IX_Cliente")
                    .IsUnique();

                entity.Property(e => e.IdCliente).HasColumnName("idCliente");

                entity.Property(e => e.ApellidoMaterno)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ApellidoPaterno)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Clave)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaAlta).HasColumnType("datetime");

                entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.IdEstatus).HasColumnName("idEstatus");

                entity.Property(e => e.IdTipoIdentificacion).HasColumnName("idTipoIdentificacion");

                entity.Property(e => e.IdUsuarioAlta).HasColumnName("idUsuarioAlta");

                entity.Property(e => e.NombreRazonSocial)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Nombre_RazonSocial");

                entity.Property(e => e.Rfc)
                    .IsRequired()
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .HasColumnName("RFC");

                entity.HasOne(d => d.IdEstatusNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.IdEstatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cliente_Estatus");

                entity.HasOne(d => d.IdUsuarioAltaNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.IdUsuarioAlta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cliente_Usuario");

                entity.Property(e => e.TipoPersona)
                    .HasMaxLength(5)
                    .IsUnicode(false);
                
                entity.Property(e => e.NumeroIdentificacion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

            });

            modelBuilder.Entity<ClienteIdentificacion>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Cliente_Identificacion");

                entity.Property(e => e.FechaAlta).HasColumnType("datetime");

                entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.IdCliente).HasColumnName("idCliente");

                entity.Property(e => e.IdEstatus).HasColumnName("idEstatus");

                entity.Property(e => e.IdTipoIdentificacion).HasColumnName("idTipoIdentificacion");

                entity.Property(e => e.IdUsuarioAlta).HasColumnName("idUsuarioAlta");

                entity.Property(e => e.NumeroIdentificacion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Numero_identificacion");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cliente_Identificacion_Cliente");

                entity.HasOne(d => d.IdEstatusNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdEstatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cliente_Identificacion_Estatus");

                entity.HasOne(d => d.IdTipoIdentificacionNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdTipoIdentificacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cliente_Identificacion_Tipo_identificacion");

                entity.HasOne(d => d.IdUsuarioAltaNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdUsuarioAlta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cliente_Identificacion_Usuario");
            });

            modelBuilder.Entity<CuentaCliente>(entity =>
            {
                entity.HasKey(e => e.IdCuenta);

                entity.HasIndex(e => e.Numero, "IX_Cuenta")
                    .IsUnique();

                entity.Property(e => e.IdCuenta).HasColumnName("idCuenta");

                entity.Property(e => e.FechaAlta).HasColumnType("datetime");

                entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.IdCliente).HasColumnName("idCliente");

                entity.Property(e => e.IdEstatus).HasColumnName("idEstatus");

                entity.Property(e => e.IdTipoCuenta).HasColumnName("idTipoCuenta");

                entity.Property(e => e.IdUsuarioAlta).HasColumnName("idUsuarioAlta");

                entity.Property(e => e.Numero)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Saldo).HasColumnType("decimal(18, 5)");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Cuenta)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cuenta_Cliente");

                entity.HasOne(d => d.IdEstatusNavigation)
                    .WithMany(p => p.Cuenta)
                    .HasForeignKey(d => d.IdEstatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cuenta_Estatus");

                entity.HasOne(d => d.IdTipoCuentaNavigation)
                    .WithMany(p => p.Cuenta)
                    .HasForeignKey(d => d.IdTipoCuenta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cuenta_TipoCuenta");
            });

            modelBuilder.Entity<CatEstatus>(entity =>
            {
                entity.HasKey(e => e.IdEstatus);

                entity.ToTable("Estatus");

                entity.HasIndex(e => e.Clave, "IX_Estatus")
                    .IsUnique();

                entity.Property(e => e.IdEstatus).HasColumnName("idEstatus");

                entity.Property(e => e.Clave)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaAlta).HasColumnType("datetime");

                entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.IdUsuarioAlta).HasColumnName("idUsuarioAlta");

                entity.HasOne(d => d.IdUsuarioAltaNavigation)
                    .WithMany(p => p.Estatuses)
                    .HasForeignKey(d => d.IdUsuarioAlta)
                    .HasConstraintName("FK_Estatus_Usuario");
            });

            modelBuilder.Entity<Movimientos>(entity =>
            {
                entity.HasKey(e => e.IdMovimiento);

                entity.ToTable("Movimiento");

                entity.Property(e => e.IdMovimiento).HasColumnName("idMovimiento");

                entity.Property(e => e.Abono).HasColumnType("decimal(18, 5)");

                entity.Property(e => e.Cargo).HasColumnType("decimal(18, 5)");

                entity.Property(e => e.FechaAlta).HasColumnType("datetime");

                entity.Property(e => e.FechaMovimiento).HasColumnType("datetime");

                entity.Property(e => e.IdCuenta).HasColumnName("idCuenta");

                entity.Property(e => e.IdTipoMovimiento).HasColumnName("idTipoMovimiento");

                entity.Property(e => e.IdUsuarioAlta).HasColumnName("idUsuarioAlta");

                entity.Property(e => e.Importe).HasColumnType("decimal(18, 5)");

                entity.Property(e => e.Referencia)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCuentaNavigation)
                    .WithMany(p => p.Movimientos)
                    .HasForeignKey(d => d.IdCuenta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Movimiento_Cuenta");

                entity.HasOne(d => d.IdTipoMovimientoNavigation)
                    .WithMany(p => p.Movimientos)
                    .HasForeignKey(d => d.IdTipoMovimiento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Movimiento_TipoMovimiento");
            });

            modelBuilder.Entity<TipoCuenta>(entity =>
            {
                entity.HasKey(e => e.IdTipoCuenta);

                entity.HasIndex(e => e.Clave, "IX_TipoCuenta")
                    .IsUnique();

                entity.Property(e => e.IdTipoCuenta).HasColumnName("idTipoCuenta");

                entity.Property(e => e.Clave)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.FechaAlta).HasColumnType("datetime");

                entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.IdEstatus).HasColumnName("idEstatus");

                entity.Property(e => e.IdUsuarioAlta).HasColumnName("idUsuarioAlta");

                entity.HasOne(d => d.IdUsuarioAltaNavigation)
                    .WithMany(p => p.TipoCuenta)
                    .HasForeignKey(d => d.IdUsuarioAlta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TipoCuenta_Usuario");
            });


            modelBuilder.Entity<TipoIdentificacion>(entity =>
            {
                entity.HasKey(e => e.IdTipoIdentificacion);

                entity.ToTable("Tipo_identificacion");

                entity.HasIndex(e => e.Clave, "IX_Tipo_identificacion")
                    .IsUnique();

                entity.Property(e => e.IdTipoIdentificacion).HasColumnName("idTipoIdentificacion");

                entity.Property(e => e.Clave)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaAlta).HasColumnType("datetime");

                entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.IdEstatus).HasColumnName("idEstatus");

                entity.Property(e => e.IdUsuarioAlta).HasColumnName("idUsuarioAlta");
            });

            modelBuilder.Entity<TipoMovimiento>(entity =>
            {
                entity.HasKey(e => e.IdTipoMovimiento);

                entity.ToTable("TipoMovimiento");

                entity.HasIndex(e => e.Clave, "IX_TipoMovimiento")
                    .IsUnique();

                entity.Property(e => e.IdTipoMovimiento).HasColumnName("idTipoMovimiento");

                entity.Property(e => e.CargoAbono)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Clave)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaAlta).HasColumnType("datetime");

                entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.IdEstatus).HasColumnName("idEstatus");

                entity.Property(e => e.IdUsuarioAlta).HasColumnName("idUsuarioAlta");

                entity.Property(e => e.Signo)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEstatusNavigation)
                    .WithMany(p => p.TipoMovimientos)
                    .HasForeignKey(d => d.IdEstatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TipoMovimiento_Estatus");

                entity.HasOne(d => d.IdUsuarioAltaNavigation)
                    .WithMany(p => p.TipoMovimientos)
                    .HasForeignKey(d => d.IdUsuarioAlta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TipoMovimiento_Usuario");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.ToTable("Usuario");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ClaveAcceso)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Contrasenia)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.FechaAlta).HasColumnType("datetime");

                entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.IdEstatus).HasColumnName("idEstatus");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEstatusNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdEstatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuario_Estatus");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public DbSet<TeCreemos.Models.cliente> cliente { get; set; }

        public DbSet<TeCreemos.Models.cuenta> cuenta { get; set; }
    }
}
