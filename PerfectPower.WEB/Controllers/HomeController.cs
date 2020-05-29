using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PerfectPower.BLL.Services.CreatorOfSearchResultCreateModelService;
using PerfectPower.BLL.Services.LastElementsService;
using PerfectPower.BLL.Services.PerfectPowerService;
using PerfectPower.BLL.Services.SearchResultService;
using PerfectPower.WEB.Models;
using PerfectPower.WEB.ViewModels.SearchResult;

namespace PerfectPower.WEB.Controllers
{
	public class HomeController : Controller
	{
		private readonly ICreatorOfSearchResultCreateModelService _creatorOfSearchResult;
		private readonly ISearchResultService _searchResultService;
		private readonly IPerfectPowerService _perfectPowerService;
		private readonly ILastElementsService _lastElementsService;
		private readonly IMapper _mapper;

		public HomeController(
			ICreatorOfSearchResultCreateModelService creatorOfSearchResult,
			ISearchResultService searchResultService,
			IPerfectPowerService perfectPowerService,
			ILastElementsService lastElementsService,
			IMapper mapper)
		{
			_creatorOfSearchResult = creatorOfSearchResult;
			_searchResultService = searchResultService;
			_perfectPowerService = perfectPowerService;
			_lastElementsService = lastElementsService;
			_mapper = mapper;
		}

		public IActionResult Index()
		{
			var searchResults = _searchResultService.GetAll().ToList();

			var fiveElements = _lastElementsService.LastFiveElements(searchResults);

			var resultsToView = _mapper.Map<List<SearchResultViewModel>>(fiveElements);

			return View(resultsToView);
		}

		[HttpPost]
		public IActionResult CheckNumber(int number)
		{
			if (number < 0)
			{
				return Content("Integer must be positive!");
			}

			var checkedNumber = _perfectPowerService.SearchingPerfectPower(number);

			if (checkedNumber == null)
			{
				_creatorOfSearchResult.CreateSearchResultModel(number);
			}
			else if (checkedNumber is int[])
			{
				_creatorOfSearchResult.CreateSearchResultModel(checkedNumber);
			}

			return RedirectToAction("Index", "Home");
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
