using PerfectPower.Entities;
using System.Data.Entity;

namespace PerfectPower
{
	public class ApplicationDBContext : DbContext
	{
		static ApplicationDBContext()
		{
			Database.SetInitializer<ApplicationDBContext>(new DBInitializer());
		}

		public ApplicationDBContext() : base("DefaultConnection")
		{
		}

		public DbSet<SearchResult> SearchResults { get; set; }
	}
}
