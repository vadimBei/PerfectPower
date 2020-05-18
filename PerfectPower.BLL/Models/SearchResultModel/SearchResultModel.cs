using System;
using PerfectPower.Core.Interfaces;
using PerfectPower.DAL.Entities;

namespace PerfectPower.BLL.Models.SearchResultModel
{


	public class SearchResultCreateModel : ICreateModel
	{
		public int InputParameter { get; set; }

		public int? Number { get; set; }

		public int? Power { get; set; }

		public TypeOfPower? TypeOfPower { get; set; }

		public DateTime DateCreation { get; set; }
		public DateTime ModifiedDate { get; set; }
	}

	public class SearchResultUpdateModel : SearchResultCreateModel, IUpdateModel<Guid>
	{
		public Guid Id { get; set; }
	}

	public class SearchResultModel : SearchResultUpdateModel, IViewModel<Guid>
	{
	}
}
