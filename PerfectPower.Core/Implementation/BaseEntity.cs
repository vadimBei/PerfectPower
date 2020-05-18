using System;
using PerfectPower.Core.Interfaces;

namespace PerfectPower.Core.Implementation
{
	public class BaseEntity : IBaseEntity<Guid>
	{
		public Guid Id { get; set; }

		public DateTime DateCreation { get; set; }

		public DateTime ModifiedDate { get; set; }
	}
}
