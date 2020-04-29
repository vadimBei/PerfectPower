using PerfectPower.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectPower
{
	public class DBInitializer : CreateDatabaseIfNotExists<ApplicationDBContext>
	{
		protected override void Seed(ApplicationDBContext context)
		{
			SearchResult result1 = new SearchResult()
			{
				InputParameter = 81,
				Number = 3,
				Power = 4
			};

			SearchResult result2 = new SearchResult()
			{
				InputParameter = 81,
				Number = 9,
				Power = 2
			};

			SearchResult result3 = new SearchResult()
			{
				InputParameter = 25,
				Number = 5,
				Power = 2
			};

			context.SearchResults.Add(result1);
			context.SearchResults.Add(result2);
			context.SearchResults.Add(result3);

			context.SaveChanges();
		}
	}
}
