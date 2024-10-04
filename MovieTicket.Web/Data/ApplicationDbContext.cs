using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieTicket.Web.Models;

namespace MovieTicket.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
    {
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieActor> MoviesActors { get; set; }
        public DbSet<MovieProducer> MoviesProducers { get; set; }
        public DbSet<MovieCategory> MoviesCategories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<Country> Countries { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MovieActor>()
                .HasOne(a => a.Actor)
                .WithMany(ma => ma.MoviesActors)
                .HasForeignKey(fk => fk.ActorId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<MovieActor>()
                .HasOne(m => m.Movie)
                .WithMany(ma => ma.MoviesActors)
                .HasForeignKey(fk => fk.MovieId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<MovieCategory>()
                .HasOne(m => m.Movie)
                .WithMany(mc => mc.MoviesCategories)
                .HasForeignKey(fk => fk.MovieId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<MovieCategory>()
                .HasOne(c => c.Category)
                .WithMany(mc => mc.MoviesCategories)
                .HasForeignKey(fk => fk.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Cinema>()
                .HasMany(m => m.Movies)
                .WithOne(c => c.Cinema)
                .HasForeignKey(fk => fk.CinemaId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<MovieProducer>()
                .HasOne(m => m.Movie)
                .WithMany(mp => mp.MoviesProducers)
                .HasForeignKey(fk => fk.MovieId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<MovieProducer>()
                .HasOne(p => p.Producer)
                .WithMany(mp => mp.MoviesProducers)
                .HasForeignKey(fk => fk.ProducerId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<OrderDetails>()
                .HasOne(m => m.Movie)
                .WithMany(od => od.OrderDetails)
                .HasForeignKey(fk => fk.MovieId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<OrderDetails>()
                .HasOne(o => o.Order)
                .WithMany(od => od.OrderDetails)
                .HasForeignKey(fk => fk.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Country>()
                .HasMany(p => p.Producers)
                .WithOne(c => c.Country)
                .HasForeignKey(fk => fk.CountryId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Country>()
                .HasMany(a => a.Actors)
                .WithOne(c => c.Country)
                .HasForeignKey(fk => fk.CountryId)
                .OnDelete(DeleteBehavior.Cascade);


        }
    }
}
