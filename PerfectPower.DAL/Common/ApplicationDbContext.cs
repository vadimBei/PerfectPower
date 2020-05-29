using System;
using Microsoft.EntityFrameworkCore;
using PerfectPower.DAL.Entities;

namespace PerfectPower.DAL.Common
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
			Database.EnsureCreated();
		}

		public DbSet<SearchResult> SearchResults { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<SearchResult>().HasData(
				new SearchResult[]
				{
					new SearchResult
					{
						Id = Guid.NewGuid(),
						InputParameter = 81,
						Number = 3,
						Power = 4,
						DateCreation = DateTime.Now,
						ModifiedDate = DateTime.Now,
						TypeOfPower = TypeOfPower.PerfectPower
					},
					new SearchResult
					{
						Id = Guid.NewGuid(),
						InputParameter = 81,
						Number = 9,
						Power = 2,
						DateCreation = DateTime.Now,
						ModifiedDate = DateTime.Now,
						TypeOfPower = TypeOfPower.PerfectSquare
					},
					new SearchResult
					{
						Id = Guid.NewGuid(),
						InputParameter = 25,
						Number = 5,
						Power = 2,
						DateCreation = DateTime.Now,
						ModifiedDate = DateTime.Now,
						TypeOfPower = TypeOfPower.PerfectSquare
					}
				});
		}
	}
}
