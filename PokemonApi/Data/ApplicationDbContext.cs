using Microsoft.EntityFrameworkCore;
using PokemonApi.Models;

namespace PokemonApi.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
		}


		public DbSet<Pokemon> Pokemons { get; set; }
		public DbSet<Owner> Owners { get; set; }
		public DbSet<Country> Countries { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Review> Reviews { get; set; }
		public DbSet<PokemonOwner> PokemonOwners { get; set; }
		public DbSet<PokemonCategory> PokemonCategories { get; set; }
		public DbSet<Reviewer> Reviewers { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<PokemonCategory>()
				.HasKey(pc => new { pc.PokemonId, pc.CategoryId });
			modelBuilder.Entity<PokemonCategory>()
				.HasOne(pc => pc.Pokemon)
				.WithMany(p => p.PokemonCategories)
				.HasForeignKey(c => c.PokemonId);
			modelBuilder.Entity<PokemonCategory>()
				.HasOne(pc => pc.Category)
				.WithMany(p => p.PokemonCategories)
				.HasForeignKey(c => c.CategoryId);

			modelBuilder.Entity<PokemonOwner>()
				.HasKey(po => new { po.PokemonId, po.OwnerId });
			modelBuilder.Entity<PokemonOwner>()
				.HasOne(po => po.Pokemon)
				.WithMany(p => p.PokemonOwners)
				.HasForeignKey(c => c.PokemonId);
			modelBuilder.Entity<PokemonOwner>()
				.HasOne(po => po.Owner)
				.WithMany(p => p.PokemonOwners)
				.HasForeignKey(c => c.OwnerId);

				

			
		}
	}
}
