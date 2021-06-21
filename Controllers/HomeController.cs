using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Inter_KissEspataria.Models;
using Inter_KissEspataria.Data;
using System.Globalization;

namespace Inter_KissEspataria.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            using (var data = new ComandaData())
            {
                var dia = DateTime.Now.Day;
                ViewBag.GetComandasDia = data.GetComandasDia(dia.ToString());
            }

            using (var data = new ComandaData())
            {

                var mes = DateTime.Now.Month;
                ViewBag.GetComandasMes = data.GetComandasMes(mes.ToString());
            }

            using (var data = new ComandaData())
            {
                ViewBag.Comandas = data.ReadComandaStatus();
            }

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
