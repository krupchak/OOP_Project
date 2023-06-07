using Microsoft.EntityFrameworkCore;
using Zoo_EF.Models;

namespace Zoo_EF.Data
{
#pragma warning disable CS1591
    public class ZooContext : DbContext
    {
        public ZooContext(DbContextOptions<ZooContext> options)
            : base(options)
        { 
        }

        public DbSet<Animals> Animals { get; set; }
        public DbSet<Owners> Owners { get; set; }
        public DbSet<AnimalTypes> AnimalTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Animals>()
                .HasOne(x => x.OwnerId)
                .WithMany(x => x.Animals);

            builder.Entity<Animals>()
                .HasOne(x => x.AnimalTypeId)
                .WithMany(x => x.Animals);

            //new DbInitializer(builder).Seed();
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);

        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer(DbContextConfig.ConnectionString);
        //    }
        //}
    }
#pragma warning restore CS1591
}
