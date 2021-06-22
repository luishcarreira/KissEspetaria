using System.Globalization;
using System;
using System.Collections.Generic;
using Inter_KissEspataria.Data;
using Inter_KissEspataria.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

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
            // Dados do Atendente para a comboBox
            using (var data = new PessoaAtendenteData())
            {
                ViewBag.Atendentes = data.ReadName();
            }

            // Dados do Garçom para a comboBox
            using (var data = new PessoaGarconData())
            {
                ViewBag.Garçon = data.ReadName();
            }

            // Dados do Produto para a comboBox
            using (var data = new ProdutoData())
            {
                ViewBag.Produto = data.Read();
            }

            ViewBag.Data = DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);

            return View();
        }

        [Route("Comanda/Create")]
        [HttpPost]
        public IActionResult Create(Comanda comanda, List<Item> items)
        {
            // using (var data = new ProdutoData())
            // {
            //     Produto produto = data.Read(2);

            //     Item item = new Item();
            //     item.Produto = produto;
            //     item.Quantidade = 1;
            //     item.Valor = produto.Valor;
            //     comanda.valorTotal = item.ValorTotal;
            //     lista.Add(item);
            // }

            // using (var data = new ComandaData())
            //     data.Create(comanda);
            var item = items;
            return RedirectToAction("Index");
        }

        public IActionResult GetJSON()
        {
            return RedirectToAction("Index");
        }
    }
}