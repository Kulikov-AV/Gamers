using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Games.DB
{
    public partial class GamersDBModel : DbContext
    {
        public GamersDBModel()
            : base("name=GamersDBModel")
        {
        }

        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Gamer> Gamer { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customers>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Customers>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<Customers>()
                .HasMany(e => e.Orders)
                .WithOptional(e => e.Customers)
                .HasForeignKey(e => e.customer_id);

            modelBuilder.Entity<Gamer>()
                .Property(e => e.title)
                .IsUnicode(false);

            modelBuilder.Entity<Gamer>()
                .Property(e => e.genre)
                .IsUnicode(false);

            modelBuilder.Entity<Gamer>()
                .Property(e => e.price)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Gamer>()
                .HasMany(e => e.Orders)
                .WithOptional(e => e.Gamer)
                .HasForeignKey(e => e.game_id);
        }
    }
}
