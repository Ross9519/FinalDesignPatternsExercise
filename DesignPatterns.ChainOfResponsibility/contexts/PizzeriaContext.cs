using DesignPatterns.ChainOfResponsibility.models;
using DesignPatterns.ChainOfResponsibility.seeds;
using Microsoft.EntityFrameworkCore;

namespace DesignPatterns.ChainOfResponsibility.contexts
{
    internal class PizzeriaContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Ingredient> Ingredients { get; set;}

        public DbSet<OrderIngredient> OrderIngredients { get; set; }
        public DbSet<Receipt> Receipts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer(@"Data Source=ROSS\SQLEXPRESS;Initial Catalog=Pizzeria;Integrated Security=True;Encrypt=False");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>(order => 
            {
                order.HasOne(o => o.Receipt)
                     .WithOne(r => r.Order);
            });

            modelBuilder.Entity<Receipt>(receipt => 
            {
                receipt.HasOne(r => r.Order)
                       .WithOne(o => o.Receipt)
                       .HasForeignKey<Receipt>(r => r.OrderId);
            });

            modelBuilder.Entity<Ingredient>(ingredient => 
            {
                ingredient.HasData(IngredientSeeder.Ingredients);
            });

            modelBuilder.Entity<OrderIngredient>(orderIngredient => 
            {
                orderIngredient.HasKey(oi => new {oi.OrderId, oi.IngredientId});
            });
        }
    }
}
