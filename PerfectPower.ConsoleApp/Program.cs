﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PerfectPower.BLL.Services.CreatorOfSearchResultCreateModelService;
using PerfectPower.BLL.Services.LastElementsService;
using PerfectPower.BLL.Services.PerfectPowerService;
using PerfectPower.BLL.Services.SearchResultService;
using PerfectPower.BLL.Services.TypeOfPowerService;
using PerfectPower.ConsoleApp.Service.OutputValueService;
using PerfectPower.ConsoleApp.ViewModels;
using PerfectPower.DAL.Common;

namespace PerfectPower.ConsoleApp
{
	class Program
	{
		public static ServiceProvider ConfigureServicesProvider()
		{
			IServiceCollection services = new ServiceCollection();

			var builder = new ConfigurationBuilder();
			builder.SetBasePath(Directory.GetCurrentDirectory());

			// Get configuration form file 
			builder.AddJsonFile("appsettings.json");

			// Create configuration
			var config = builder.Build();

			services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
			services.AddDbContext<ApplicationDbContext>(optionsAction=> 
			optionsAction.UseSqlServer(config.GetConnectionString("DefaultConnection")));

			services.AddScoped<ISearchResultService, SearchResultService>();
			services.AddScoped<ILastElementsService, LastElementsService>();
			services.AddScoped<IOutputValueService, OutputValueService>();
			services.AddScoped<ITypeOfPowerService, TypeOfPowerService>();
			services.AddScoped<IPerfectPowerService, PerfectPowerService>();
			services.AddScoped<ICreatorOfSearchResultCreateModelService, CreatorOfSearchResultCreateModelService>();

			return services.BuildServiceProvider();
		}

		static void Main(string[] args)
		{

			var serviceProvider = ConfigureServicesProvider();

			Console.WriteLine("Please wait...!!!");

			// Get all SearchElements elements from database
			var allElements = serviceProvider.GetService<ISearchResultService>().GetAll().ToList();

			// Get last five SearchResult elements
			var searchResults = serviceProvider.GetService<ILastElementsService>().LastFiveElements(allElements);

			var searchResultViewModel = serviceProvider.GetService<IMapper>()
				.Map<List<SearchResultViewModel>>(searchResults);

			Console.WriteLine();
			Console.WriteLine("Previous results:");

			// Output elements to console
			serviceProvider.GetService<IOutputValueService>()
				.OutputListOfSearchResultToConsole(searchResultViewModel);

			Console.WriteLine();
			Console.WriteLine("Please enter the a positive integer and press Enter: ");

			int number = int.Parse(Console.ReadLine());

			if (number < 0)
			{
				Console.WriteLine();
				Console.WriteLine("Input element must be positive!!!!");
			}
			else
			{
				// Check if number is perfect power
				var perfectPower = serviceProvider.GetService<IPerfectPowerService>().SearchingPerfectPower(number);

				if (perfectPower == null)
				{
					var newSearchResultModel = serviceProvider.GetService<ICreatorOfSearchResultCreateModelService>()
						.CreateSearchResultModel(number);

					var newSearchResultViewModel = serviceProvider.GetService<IMapper>()
						.Map<SearchResultViewModel>(newSearchResultModel);

					Console.WriteLine();
					serviceProvider.GetService<IOutputValueService>().OutputElementOfSearchResultToConsole(newSearchResultViewModel);
				}
				else if (perfectPower is int[])
				{
					var newSearchResultModel = serviceProvider.GetService<ICreatorOfSearchResultCreateModelService>()
						.CreateSearchResultModel(perfectPower);

					var newSearchResultViewModel = serviceProvider.GetService<IMapper>()
						.Map<SearchResultViewModel>(newSearchResultModel);

					Console.WriteLine();
					serviceProvider.GetService<IOutputValueService>().OutputElementOfSearchResultToConsole(newSearchResultViewModel);
				}
			}

			Console.ReadKey();
		}
	}
}
