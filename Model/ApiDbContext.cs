using Microsoft.EntityFrameworkCore;
namespace API_Prueba.Model
{
    public class ApiDbContext : DbContext
    {
        public DbSet<Album> Albums { get; set; }
        public DbSet<Artista> Artistas { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=API_PRUEBA;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
    }
}
