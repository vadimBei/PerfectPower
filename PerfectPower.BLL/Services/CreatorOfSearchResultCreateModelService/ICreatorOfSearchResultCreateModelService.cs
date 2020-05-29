using PerfectPower.BLL.Models.SearchResultModel;

namespace PerfectPower.BLL.Services.CreatorOfSearchResultCreateModelService
{
	public interface ICreatorOfSearchResultCreateModelService
	{
		SearchResultCreateModel CreateSearchResultModel(int[] array);

		SearchResultCreateModel CreateSearchResultModel(int number);
	}
}
