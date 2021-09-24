using ConexaoMySql.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace ConexaoMySql.Data
{
    public class ApplicationDbContext : DbContext
    {
        #region Tabelas
        public DbSet<Produto> Produtos { get; set; }
        #endregion

        #region Configuração
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("Server=localhost;DataBase=VariosBancos;Uid=root;Pwd=Senh@1234",
                new MySqlServerVersion(new Version(8, 0, 26)));
        }

        // Modelagem do Banco de Dados separado por Tabelas
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
        #endregion
    }
}
