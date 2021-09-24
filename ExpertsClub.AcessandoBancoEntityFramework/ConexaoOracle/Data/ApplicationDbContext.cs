using ConexaoOracle.Models;
using Microsoft.EntityFrameworkCore;

namespace ConexaoOracle.Data
{
    public class ApplicationDbContext : DbContext
    {
        #region Tabelas
        public DbSet<Produto> Produtos { get; set; }
        #endregion

        #region Configuração
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseOracle("User Id=variosbancos;Password=1234;Data Source=VM.mshome.net:1521/xe;");
        }

        // Modelagem do Banco de Dados separado por Tabelas
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
        #endregion
    }
}
