using System;
using PerfectPower.DAL.Entities;

namespace PerfectPower.ConsoleApp.ViewModels
{
	public class SearchResultViewModel
	{
		public Guid Id { get; set; }

		public int InputParameter { get; set; }

		public int? Number { get; set; }

		public int? Power { get; set; }

		public TypeOfPower TypeOfPower { get; set; }
	}
}
