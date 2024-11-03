using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Plusoft3Sprint.Models;

namespace Plusoft3Sprint.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Email> Emails { get; set; }

        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
    }
}
