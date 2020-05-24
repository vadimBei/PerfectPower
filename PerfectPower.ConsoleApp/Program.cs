using System;
using System.Linq;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using PerfectPower.BLL.Services.LastElementsService;
using PerfectPower.BLL.Services.PerfectPowerService;
using PerfectPower.BLL.Services.SearchResultService;
using PerfectPower.BLL.Services.TypeOfPowerService;
using PerfectPower.ConsoleApp.Service.CreatorOfSearchResultService;
using PerfectPower.ConsoleApp.Service.OutputValueService;
using PerfectPower.DAL.Common;

namespace PerfectPower.ConsoleApp
{
	class Program
	{
		public static ServiceProvider ConfigureServicesProvider()
		{
			IServiceCollection services = new ServiceCollection();

			services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
			services.AddDbContext<ApplicationDbContext>();
			services.AddScoped<ISearchResultService, SearchResultService>();
			services.AddScoped<ILastElementsService, LastElementsService>();
			services.AddScoped<IOutputValueService, OutputValueService>();
			services.AddScoped<ITypeOfPowerService, TypeOfPowerService>();
			services.AddScoped<IPerfectPowerService, PerfectPowerService>();
			services.AddScoped<ICreatorOfSearchResultService, CreatorOfSearchResultService>();

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

			Console.WriteLine();
			Console.WriteLine("Previous results:");

			// Output elements to console
			serviceProvider.GetService<IOutputValueService>().OutputListOfSearchResultToConsole(searchResults);

			Console.WriteLine();
			Console.WriteLine("Please enter the a positive integer and press Enter: ");

			int number = int.Parse(Console.ReadLine());

			if (number < 0)
			{
				Console.WriteLine("Input element must be positive!!!!");
			}

			// Check if number is perfect power
			var perfectPower = serviceProvider.GetService<IPerfectPowerService>().SearchingPerfectPower(number);

			if (perfectPower == null)
			{
				var newSearchResultId = serviceProvider.GetService<ICreatorOfSearchResultService>()
					.CreateSearchResultElement(number);

				Console.WriteLine();
				serviceProvider.GetService<IOutputValueService>().OutputElementOfSearchResultToConsoleById(newSearchResultId);
			}
			else
			{
				Console.WriteLine();
				serviceProvider.GetService<IOutputValueService>().OutputElementOfSearchResultToConsole(perfectPower);
			}

			Console.ReadKey();
		}
	}
}
