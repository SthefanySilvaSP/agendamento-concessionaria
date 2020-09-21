using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace backend.Models
{
    public partial class db_concessionariaContext : DbContext
    {
        public db_concessionariaContext()
        {
        }

        public db_concessionariaContext(DbContextOptions<db_concessionariaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbAgendamento> TbAgendamento { get; set; }
        public virtual DbSet<TbCarro> TbCarro { get; set; }
        public virtual DbSet<TbCliente> TbCliente { get; set; }
        public virtual DbSet<TbFuncionario> TbFuncionario { get; set; }
        public virtual DbSet<TbLogin> TbLogin { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=localhost;user id=root;password=1234;database=db_concessionaria", x => x.ServerVersion("8.0.18-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TbAgendamento>(entity =>
            {
                entity.HasKey(e => e.IdAgendamento)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.IdCarro)
                    .HasName("fk_tb_agendamento_tb_carro1_idx");

                entity.HasIndex(e => e.IdCliente)
                    .HasName("fk_tb_agendamento_tb_cliente_idx");

                entity.HasIndex(e => e.IdFuncionario)
                    .HasName("fk_tb_agendamento_tb_funcionario1_idx");

                entity.Property(e => e.DsFeedback)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.DsSituacao)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.IdCarroNavigation)
                    .WithMany(p => p.TbAgendamento)
                    .HasForeignKey(d => d.IdCarro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tb_agendamento_tb_carro1");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.TbAgendamento)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tb_agendamento_tb_cliente");

                entity.HasOne(d => d.IdFuncionarioNavigation)
                    .WithMany(p => p.TbAgendamento)
                    .HasForeignKey(d => d.IdFuncionario)
                    .HasConstraintName("fk_tb_agendamento_tb_funcionario1");
            });

            modelBuilder.Entity<TbCarro>(entity =>
            {
                entity.HasKey(e => e.IdCarro)
                    .HasName("PRIMARY");

                entity.Property(e => e.DsCor)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.DsPlaca)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.DsRenavan)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.NmModelo)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<TbCliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.IdLogin)
                    .HasName("fk_tb_cliente_tb_login1_idx");

                entity.Property(e => e.DsCnh)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.DsCpf)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.DsGenero)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.NmCliente)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.IdLoginNavigation)
                    .WithMany(p => p.TbCliente)
                    .HasForeignKey(d => d.IdLogin)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tb_cliente_tb_login1");
            });

            modelBuilder.Entity<TbFuncionario>(entity =>
            {
                entity.HasKey(e => e.IdFuncionario)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.IdLogin)
                    .HasName("fk_tb_funcionario_tb_login1_idx");

                entity.Property(e => e.DsCargo)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.DsCpf)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.DsDpto)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.DsGenero)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.NmFuncionario)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.IdLoginNavigation)
                    .WithMany(p => p.TbFuncionario)
                    .HasForeignKey(d => d.IdLogin)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tb_funcionario_tb_login1");
            });

            modelBuilder.Entity<TbLogin>(entity =>
            {
                entity.HasKey(e => e.IdLogin)
                    .HasName("PRIMARY");

                entity.Property(e => e.DsEmail)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.DsPerfil)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.DsSenha)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
