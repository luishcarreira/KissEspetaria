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
            List<Item> lista = new List<Item>();

            using (var data = new ProdutoData())
            {
                Produto produto = data.Read(2);

                Item item = new Item();
                item.Produto = produto;
                item.Quantidade = 1;
                item.Valor = item.Produto.Valor;
                lista.Add(item);
            }

            using (var data = new ComandaData())
                data.Create(comanda);

            return RedirectToAction("Index");
        }
    }
}