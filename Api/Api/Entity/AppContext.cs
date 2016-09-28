using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Api.Entity
{
    public class AppContext : DbContext
    {
        public AppContext() : base("DefaultConnection")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<LioOrder> Orders { get; set; }
        public DbSet<LioOrderItem> OrderItens { get; set; }
        public DbSet<Address> Address { get; set; }    
    }
}