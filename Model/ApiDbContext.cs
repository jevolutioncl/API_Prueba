using Microsoft.EntityFrameworkCore;
namespace API_Prueba.Model
{
    public class ApiDbContext : DbContext
    {
        public DbSet<Productos> Productos { get; set; }
        public DbSet<categorias> Categorias { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EVA4;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
    }
}
