using System;
using AutoMapper;
using PerfectPower.BLL.Models.SearchResultModel;
using PerfectPower.Core.Implementation;
using PerfectPower.DAL.Common;
using PerfectPower.DAL.Entities;

namespace PerfectPower.BLL.Services.SearchResultService
{
	public class SearchResultService :
		BaseService<SearchResult, Guid, SearchResultCreateModel, SearchResultUpdateModel, SearchResultModel>, ISearchResultService
	{
		public SearchResultService(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
		{
		}
	}
}
