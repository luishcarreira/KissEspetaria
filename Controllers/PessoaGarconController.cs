using Inter_KissEspataria.Data;
using Inter_KissEspataria.Models;
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
                data.Delete(id);

            return RedirectToAction("Index", "");
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

            return RedirectToAction("Index");
        }
    }
}