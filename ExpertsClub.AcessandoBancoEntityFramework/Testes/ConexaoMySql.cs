
using ConexaoMySql.Domain;
using ConexaoMySql.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace Testes
{
    public class ConexaoMySql
    {
        [Fact(DisplayName = "Consultar Produto"), Trait("MySql", "Cadastro")]
        public void ConsultarProduto()
        {
            // Act
            Produto produto = new ProdutoDomain().ConsultarProdutoNome(new Produto { Nome = "Caneta Azul" });

            // Assert
            Assert.Equal("Caneta Azul", produto.Nome);
        }

        [Fact(DisplayName = "Consultar Produtos"), Trait("MySql", "Cadastro")]
        public void ConsultarProdutos()
        {
            // Act
            List<Produto> produtos = new ProdutoDomain().ConsultarProdutos();

            // Assert
            Assert.True(produtos.Count >= 6);
        }

        [Fact(DisplayName = "Adicionar Produto"), Trait("MySql", "Cadastro")]
        public void AdicionarProduto()
        {
            // Arrange
            Produto produto = new Produto();
            produto.Id = Guid.Parse("F97221A6-7DC9-4420-9408-82B13A77C6EE");
            produto.Nome = "Papel A4";
            produto.Valor = 24.90M;

            // Act
            Produto produtoBanco = new ProdutoDomain().ConsultarProdutoNome(produto);
            if (produtoBanco == null)
                new ProdutoDomain().AdicionarProduto(produto);

            // Assert
            var produtoAdicionado = new ProdutoDomain().ConsultarProdutoNome(produto);
            Assert.True(produto.Id == produtoAdicionado.Id);
        }

        [Fact(DisplayName = "Alterar Produto"), Trait("MySql", "Cadastro")]
        public void AlterarProduto()
        {
            // Arrange
            Produto produto = new Produto();
            produto.Id = Guid.NewGuid();
            produto.Nome = "Papel Carta";
            produto.Valor = 23.60M;

            // Act
            Produto produtoBanco = new ProdutoDomain().ConsultarProdutoNome(produto);
            if (produtoBanco == null)
            {
                new ProdutoDomain().AdicionarProduto(produto);
                produtoBanco = produto;
            }

            new ProdutoDomain().AlterarProduto(produtoBanco.Nome, "Papel Carta 1");

            // Assert
            Produto produtoAlterado = new ProdutoDomain().ConsultarProdutoNome(produto);
            Assert.NotEqual(produto.Nome, produtoAlterado.Nome);
        }

        [Fact(DisplayName = "Excluir Produto"), Trait("MySql", "Cadastro")]
        public void ExcluirProduto()
        {
            // Arrange
            Produto produto = new Produto();
            produto.Id = Guid.NewGuid();
            produto.Nome = "Calculadora";
            produto.Valor = 35.90M;

            // Act
            Produto produtoBanco = new ProdutoDomain().ConsultarProdutoNome(produto);
            if (produtoBanco == null)
                new ProdutoDomain().AdicionarProduto(produto);

            new ProdutoDomain().ExcluirProduto(produto);

            // Assert
            var produtoExcluir = new ProdutoDomain().ConsultarProdutoNome(produto);
            Assert.True(produtoExcluir == null);
        }
    }
}
