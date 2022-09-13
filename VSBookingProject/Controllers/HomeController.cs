using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VSBookingProject.Models;
using BLL;

namespace VSBookingProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        IHotelManager HotelManager { get; }

        public HomeController(ILogger<HomeController> logger, IHotelManager hotelManager)
        {
            _logger = logger;
            HotelManager = hotelManager;
        }

        public IActionResult Index()
        {
            

            return View();
        }

        public IActionResult Details(int id)
        {
            

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
