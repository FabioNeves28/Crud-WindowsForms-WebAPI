using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication10.Models
{
    public partial class estoque_treinamentoContext : DbContext
    {
        public estoque_treinamentoContext()
        {
        }

        public estoque_treinamentoContext(DbContextOptions<estoque_treinamentoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Produto> Produtos { get; set; } = null!;
        public virtual DbSet<ProdutosCategoria> ProdutosCategorias { get; set; } = null!;
        public virtual DbSet<UnidadesMedida> UnidadesMedidas { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Produto>(entity =>
            {
                entity.ToTable("produtos");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => e.Un, "fk_sigla_un_idx");

                entity.HasIndex(e => e.IdCategoria, "id_categoria_idx");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AlteradoData)
                    .HasColumnType("datetime")
                    .HasColumnName("alterado_data");

                entity.Property(e => e.AlteradoUsuario)
                    .HasColumnName("alterado_usuario")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Ativo)
                    .HasMaxLength(1)
                    .HasColumnName("ativo")
                    .HasDefaultValueSql("'S'")
                    .IsFixedLength();

                entity.Property(e => e.CadastradoData)
                    .HasColumnType("datetime")
                    .HasColumnName("cadastrado_data")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.CadastradoUsuario)
                    .HasColumnName("cadastrado_usuario")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Codigo)
                    .HasMaxLength(12)
                    .HasColumnName("codigo")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(70)
                    .HasColumnName("descricao")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.EstoqueMaximo)
                    .HasColumnName("estoque_maximo")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.EstoqueMinimo)
                    .HasColumnName("estoque_minimo")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.EstoqueSaldoInicial)
                    .HasColumnName("estoque_saldo_inicial")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.EstoqueSaldoInicialData).HasColumnName("estoque_saldo_inicial_data");

                entity.Property(e => e.IdCategoria)
                    .HasColumnName("id_categoria")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.PrecoCusto)
                    .HasPrecision(10, 2)
                    .HasColumnName("preco_custo")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.PrecoVenda)
                    .HasPrecision(10, 2)
                    .HasColumnName("preco_venda")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.Un)
                    .HasMaxLength(2)
                    .HasColumnName("un")
                    .IsFixedLength();

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Produtos)
                    .HasForeignKey(d => d.IdCategoria)
                    .HasConstraintName("fk_id_categoria");

                entity.HasOne(d => d.UnNavigation)
                    .WithMany(p => p.Produtos)
                    .HasForeignKey(d => d.Un)
                    .HasConstraintName("fk_sigla_un");
            });

            modelBuilder.Entity<ProdutosCategoria>(entity =>
            {
                entity.ToTable("produtos_categorias");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.AlteradoData)
                    .HasColumnType("datetime")
                    .HasColumnName("alterado_data")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.AlteradoUsuario)
                    .HasColumnName("alterado_usuario")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Ativa)
                    .HasMaxLength(1)
                    .HasColumnName("ativa")
                    .HasDefaultValueSql("'S'")
                    .IsFixedLength();

                entity.Property(e => e.CadastradoData)
                    .HasColumnType("datetime")
                    .HasColumnName("cadastrado_data")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.CadastradoUsuario)
                    .HasColumnName("cadastrado_usuario")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(50)
                    .HasColumnName("descricao");
            });

            modelBuilder.Entity<UnidadesMedida>(entity =>
            {
                entity.HasKey(e => e.Sigla)
                    .HasName("PRIMARY");

                entity.ToTable("unidades_medidas");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.Sigla)
                    .HasMaxLength(2)
                    .HasColumnName("sigla")
                    .IsFixedLength();

                entity.Property(e => e.AlteradoData)
                    .HasColumnType("datetime")
                    .HasColumnName("alterado_data")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.AlteradoUsuario)
                    .HasColumnName("alterado_usuario")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Ativa)
                    .HasMaxLength(1)
                    .HasColumnName("ativa")
                    .HasDefaultValueSql("'S'")
                    .IsFixedLength();

                entity.Property(e => e.CadastradoData)
                    .HasColumnType("datetime")
                    .HasColumnName("cadastrado_data")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.CadastradoUsuario)
                    .HasColumnName("cadastrado_usuario")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.CasasDecimais)
                    .HasColumnName("casas_decimais")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(50)
                    .HasColumnName("descricao");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("usuarios");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Ativo)
                    .HasMaxLength(1)
                    .HasColumnName("ativo")
                    .HasDefaultValueSql("'S'")
                    .IsFixedLength();

                entity.Property(e => e.DataCadastro)
                    .HasColumnType("datetime")
                    .HasColumnName("data_cadastro")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Email)
                    .HasMaxLength(120)
                    .HasColumnName("email")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.NomeLogin)
                    .HasMaxLength(20)
                    .HasColumnName("nome_login");

                entity.Property(e => e.NomeReal)
                    .HasMaxLength(80)
                    .HasColumnName("nome_real")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Senha)
                    .HasMaxLength(128)
                    .HasColumnName("senha")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Tema)
                    .HasColumnName("tema")
                    .HasDefaultValueSql("'3'");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
