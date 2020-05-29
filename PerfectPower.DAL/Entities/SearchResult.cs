using PerfectPower.Core.Implementation;

namespace PerfectPower.DAL.Entities
{
	public enum TypeOfPower
	{
		PerfectPower,
		PerfectSquare,
		PerfectCube,
		IsNotPerfectPower
	}

	public class SearchResult : BaseEntity
	{
		public int InputParameter { get; set; }

		public int? Number { get; set; }

		public int? Power { get; set; }

		public TypeOfPower TypeOfPower { get; set; }
	}
}
