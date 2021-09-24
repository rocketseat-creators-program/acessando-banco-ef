using ConexaoOracle.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace ConexaoOracle.Data.Table
{
    public class ProdutoTable : IEntityTypeConfiguration<Produto>
    {
        // Modelagem da Tabela Produto
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            CriarTabelaProduto(builder);
            CargaInicialProduto(builder);
        }

        private void CriarTabelaProduto(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produto");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Nome).HasColumnType("VARCHAR(20)").IsRequired();
            builder.Property(p => p.Valor).IsRequired();
        }

        private void CargaInicialProduto(EntityTypeBuilder<Produto> builder)
        {
            builder.HasData(
                new Produto { Id = Guid.NewGuid(), Nome = "Caneta Bic", Valor = 1 },
                new Produto { Id = Guid.NewGuid(), Nome = "Caneta Azul", Valor = 1.39M },
                new Produto { Id = Guid.NewGuid(), Nome = "Caneta Vermelha", Valor = 1.40M },
                new Produto { Id = Guid.NewGuid(), Nome = "Caneta Preta", Valor = 1.41M },
                new Produto { Id = Guid.NewGuid(), Nome = "Lápis", Valor = 0.37M },
                new Produto { Id = Guid.NewGuid(), Nome = "Borracha", Valor = 0.74M }
                );
        }
    }
}
