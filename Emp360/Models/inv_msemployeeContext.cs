using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace Emp360.Models
{
    public partial class inv_msemployeeContext : DbContext
    {
        public inv_msemployeeContext()
        {
        }

        public inv_msemployeeContext(DbContextOptions<inv_msemployeeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AmPune> AmPune { get; set; }
        public virtual DbSet<EmployeeData> EmployeeData { get; set; }
        public virtual DbSet<Gpmmaster> Gpmmaster { get; set; }

        public virtual DbSet<DeskAllocatinoDetails> DeskAllocationDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                
                var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables(); ;
                IConfiguration Configuration = builder.Build();
                var connectionString = Configuration.GetConnectionString("inventoryConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AmPune>().HasKey(p => p.Email);
            modelBuilder.Entity<DeskAllocatinoDetails>().HasKey(p=>p.SrNo);
            modelBuilder.Entity<AmPune>(entity =>
            {
                entity.HasKey(e => e.Email);

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .ValueGeneratedNever();

                entity.Property(e => e.Gpmvid)
                    .HasColumnName("GPMVId")
                    .HasMaxLength(50);

                entity.Property(e => e.Id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Location)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<EmployeeData>(entity =>
            {
                entity.ToTable("EmployeeData", "Emp360");

                entity.Property(e => e.Category).HasMaxLength(1000);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.EmpId)
                    .HasColumnName("EmpID")
                    .HasMaxLength(1000);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Gpmmaster>(entity =>
            {
                entity.HasKey(e => e.Vid);

                entity.ToTable("GPMMaster");

                entity.Property(e => e.Vid)
                    
                    .HasColumnName("vid")
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.Glname)
                    .IsRequired()
                    .HasColumnName("GLName")
                    .HasMaxLength(50);

                entity.Property(e => e.Gpmname)
                    .IsRequired()
                    .HasColumnName("GPMName")
                    .HasMaxLength(50);

                entity.Property(e => e.IsGpm)
                    .IsRequired()
                    .HasColumnName("IsGPM")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Location)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Pune')");
            });

            modelBuilder.Entity<DeskAllocatinoDetails>(entity =>
            {
                entity.ToTable("DeskAllocation");

                entity.Property(e => e.SeatNo)
                    .HasColumnName("SeatNo")
                    .HasMaxLength(50);
                entity.Property(e => e.MachineNo)
                    .HasColumnName("MachineNo")
                    .HasMaxLength(50);
                entity.Property(e => e.VId)
                    .IsRequired()
                    .HasColumnType("varchar")
                    .HasColumnName("VId")
                    .HasMaxLength(50);
                entity.Property(e => e.GPM)
                    .HasColumnType("varchar")
                    .HasColumnName("GPM")
                    .HasMaxLength(50);
                entity.Property(e => e.AssetType)
                    .HasColumnType("varchar")
                    .HasColumnName("AssetType")
                    .HasMaxLength(50);
                entity.Property(e => e.MsReportingManager)
                    .HasColumnType("varchar")
                    .HasColumnName("MsReportingManager")
                    .HasMaxLength(200);
                entity.Property(e => e.ProjectName)
                    .HasColumnType("varchar")
                    .HasColumnName("ProjectName")
                    .HasMaxLength(200);
                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("ModifiedDate")
                    .HasMaxLength(200);
                entity.Property(e => e.ModifiedBy)
                    .HasColumnType("varchar")
                    .HasColumnName("ModifiedBy")
                    .HasMaxLength(200);
                entity.Property(e => e.isStale)
                    .HasColumnType("bit")
                    .HasColumnName("isStale");
                entity.Property(e => e.SrNo)
                    .IsRequired()
                    .UseSqlServerIdentityColumn()
                    .HasColumnType("int")
                    .HasColumnName("SrNo");
            });
        }
    }
}
