
using DapperAssignment.DataAccess;
using DapperAssignment.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DapperAssignment.Controllers
{
    public class HomeController : Controller
    {
        private readonly CityQuery _cityQuery;
        public HomeController(CityQuery cityQuery)
        {
            _cityQuery = cityQuery;
        }
        public IActionResult Index()
        {
            List<City> citiesWithLifeExpectancy = _cityQuery.GetCitiesWithLifeExpectancy();
            return View(citiesWithLifeExpectancy);
        }
        public IActionResult Privacy()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
    }
}