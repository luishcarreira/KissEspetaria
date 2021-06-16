using System.Collections.Generic;
using Inter_KissEspataria.Data;
using Inter_KissEspataria.Models;
using Microsoft.AspNetCore.Mvc;

namespace Inter_KissEspataria.Controllers
{
    public class ComandaController : Controller
    {
        public IActionResult Index()
        {
            using (var data = new ComandaData())
            {
                return View(data.Read());
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            using (var data = new PessoaAtendenteData())
            {
                ViewBag.Atendentes = data.ReadName();
            }

            using (var data = new PessoaGarconData())
            {
                ViewBag.Garçon = data.ReadName();
            }

            using (var data = new ProdutoData())
            {
                ViewBag.Produto = data.Read();
            }

            return View();
        }

        [HttpPost]
        public IActionResult Create(Comanda comanda)
        {
            using (var data = new ComandaData())
                data.Create(comanda);

            return RedirectToAction("Index");
        }
    }
}