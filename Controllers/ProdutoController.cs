using Inter_KissEspataria.Data;
using Inter_KissEspataria.Models;
using Microsoft.AspNetCore.Mvc;

namespace Inter_KissEspataria.Controllers
{
    public class ProdutoController : Controller
    {
        public IActionResult Index()
        {
            using (var data = new ProdutoData())
                return View(data.Read());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Produto produto)
        {
            if (!ModelState.IsValid)
            {
                return View(produto);
            }

            using (var data = new ProdutoData())
                data.Create(produto);

            return RedirectToAction("Index", produto);
        }

        public IActionResult Delete(int id)
        {
            using (var data = new ProdutoData())
                data.Delete(id);

            return RedirectToAction("Index", "Produto");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            using (var data = new ProdutoData())
                return View(data.Read(id));
        }

        [HttpPost]
        public IActionResult Update(int id, Produto produto)
        {
            produto.ProdutoId = id;

            if (!ModelState.IsValid)
                return View(produto);

            using (var data = new ProdutoData())
                data.Update(produto);

            return RedirectToAction("Index", "Produto");
        }
    }
}