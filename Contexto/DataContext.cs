
using tp_final.Modelo;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
namespace tp_final.Contexto
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Categories> Categories { get; set; }
    
        public DbSet<Products> Products { get; set; }
        

    }
}
