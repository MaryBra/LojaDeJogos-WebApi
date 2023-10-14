using Microsoft.EntityFrameworkCore;
using LojaDeJogos.Controllers;

namespace LojaDeJogos.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        
        public DbSet<Carrinho>? Carrinho { get; set; }
        public DbSet<Classificacao>? Classificacao { get; set; }
        public DbSet<Cliente>? Cliente { get; set; }
        public DbSet<Desenvolvedor>? Desenvolvedor { get; set; }
        public DbSet<Estoque>? Estoque { get; set; }
        public DbSet<Pagamento>? Pagamento { get; set; }
        public DbSet<Pedido>? Pedido { get; set; }
        public DbSet<Produto>? Produto { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("DataSource=loja.db;Cache=Shared");
        }
    }



    
}



