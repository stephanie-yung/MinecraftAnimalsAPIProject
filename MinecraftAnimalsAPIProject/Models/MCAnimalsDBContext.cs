using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using MCAnimalsAPI.Models;
using System.Diagnostics;

namespace MCAnimalsAPI.Models
{
	public class MCAnimalsDBContext : DbContext
	{
		protected readonly IConfiguration Configuration;

		public MCAnimalsDBContext(DbContextOptions<MCAnimalsDBContext> options, IConfiguration configuration) : base(options)
		{
			Configuration = configuration;

		}

		protected override void OnConfiguring(DbContextOptionsBuilder options)
		{
			var connectionString = Configuration.GetConnectionString("MinecraftAnimalsDataService");
			options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			//modelBuilder.Entity<BreedableAnimal>().HasOne(ba => ba.AnimalCategories).WithOne().HasForeignKey<BreedableAnimal>(ba => ba.BreedableAnimalId);

		}

		public DbSet<AnimalCategories> AnimalCategories { get; set; } = null!;
		public DbSet<BreedableAnimal> BreedableAnimal { get; set; } = null!;
	}
}

