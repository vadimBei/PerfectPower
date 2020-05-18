using System;

namespace PerfectPower.ConsoleApp.Service.CreatorOfSearchResultService
{
	public interface ICreatorOfSearchResultService
	{
		Guid CreateSearchResultElement(int number);
	}
}
