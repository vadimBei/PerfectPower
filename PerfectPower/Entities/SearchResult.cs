using System;

namespace PerfectPower.Entities
{
	public class SearchResult
	{
		public SearchResult()
		{
			Id = Guid.NewGuid();
			CreationDate = DateTime.Now;
		}

		public Guid Id { get; set; }

		public int InputParameter { get; set; }

		public int? Number { get; set; }

		public int? Power { get; set; }

		public DateTime CreationDate { get; set; }
	}
}
