using ConexaoOracle.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConexaoOracle.Domain
{
    public class ProdutoDomain
    {
        public Produto ConsultarProdutoNome(Produto produto)
        {
            using var db = new Data.ApplicationDbContext();

            return db.Produtos.Where(p => p.Nome.Contains(produto.Nome)).FirstOrDefault();
        }

        public List<Produto> ConsultarProdutos()
        {
            using var db = new Data.ApplicationDbContext();

            return db.Produtos.ToList();
        }

        public void AdicionarProduto(Produto produto)
        {
            using var db = new Data.ApplicationDbContext();

            db.Add(produto);
            db.SaveChanges();
        }

        public void AlterarProduto(string nomeAntigo, string nomeNovo)
        {
            using var db = new Data.ApplicationDbContext();

            var produtoAlterar = db.Produtos.Where(p => p.Nome.Contains(nomeAntigo)).FirstOrDefault();

            produtoAlterar.Nome = nomeNovo;
            db.SaveChanges();
        }

        public void ExcluirProduto(Produto produto)
        {
            using var db = new Data.ApplicationDbContext();

            var produtoExcluir = db.Produtos.Find(produto.Id);
            db.Remove(produtoExcluir);
            db.SaveChanges();
        }
    }
}
