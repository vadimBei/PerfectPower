using System;
using PerfectPower.BLL.Models.SearchResultModel;
using PerfectPower.Core.Interfaces;
using PerfectPower.DAL.Entities;

namespace PerfectPower.BLL.Services.SearchResultService
{
	public interface ISearchResultService :
		IBaseService<SearchResult, Guid, SearchResultCreateModel, SearchResultUpdateModel, SearchResultModel>
	{
	}
}
