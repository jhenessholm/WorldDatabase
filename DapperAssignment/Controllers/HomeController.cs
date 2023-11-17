
using DapperAssignment.DataAccess;
using DapperAssignment.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;

namespace DapperAssignment.Controllers
{
    public class HomeController : Controller
    {
        private readonly CityQuery _cityQuery;
        public HomeController(CityQuery cityQuery)
        {
            _cityQuery = cityQuery;
        }
        public IActionResult Index(string continent, string orderBy)
        {
            List<City> citiesWithLifeExpectancy;
            if (!string.IsNullOrEmpty(continent))
            {
                citiesWithLifeExpectancy = _cityQuery.GetCitiesWithLifeExpectancy(continent, orderBy);
            }
            else
            {
                citiesWithLifeExpectancy = _cityQuery.GetCitiesWithLifeExpectancy(orderBy, orderBy);
            }
            List<Country> allCountries = _cityQuery.GetAllCountries();
            List<string> continents = allCountries.Select(c =>c.Continent).Distinct().ToList();

            ViewData["Cities"] = citiesWithLifeExpectancy;
            ViewData["Countries"] = allCountries;
            ViewData["Continents"] = continents;
            ViewData["SelectedOrderBy"] = orderBy;
            ViewData["SelectedContinent"] = continent;

            return View(citiesWithLifeExpectancy);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}