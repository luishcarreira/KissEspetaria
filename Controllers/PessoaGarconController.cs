using System.Text.Json;
using Inter_KissEspataria.Data;
using Inter_KissEspataria.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inter_KissEspataria.Controllers
{
    public class PessoaGarconController : Controller
    {
        public IActionResult Index()
        {
            using (var data = new PessoaGarconData())
                return View(data.Read());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(PessoaGarcon garcon)
        {
            if (!ModelState.IsValid)
            {
                return View(garcon);
            }

            using (var data = new PessoaGarconData())
                data.Create(garcon);

            return RedirectToAction("Index", garcon);
        }

        public IActionResult Delete(int id)
        {
            using (var data = new PessoaGarconData())
            {
                bool exclusao = data.Delete(id);

                if (exclusao == true)
                {
                    TempData["deleteSucesso"] = "A Exclusão foi realizada com sucesso";
                }
                else
                {
                    TempData["deleteErro"] = "A Exclusão falhou, pode haver alguma comanda atrelada com o ID deste garçom";
                }
            }

            using (var data = new PessoaGarconData())
                data.Delete(id);

            return RedirectToAction("Index", "PessoaGarcon");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            using (var data = new PessoaGarconData())
                return View(data.Read(id));
        }

        [HttpPost]
        public IActionResult Update(int id, PessoaGarcon garcon)
        {
            garcon.PessoaId = id;

            if (!ModelState.IsValid)
                return View(garcon);

            using (var data = new PessoaGarconData())
                data.Update(garcon);

            return RedirectToAction("Index", "PessoaGarcon");
        }
    }
}