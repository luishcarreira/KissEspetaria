using System;
using System.Text.Json;
using Inter_KissEspataria.Data;
using Inter_KissEspataria.Models;
using Inter_KissEspataria.Models.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inter_KissEspataria.Controllers
{
    public class PessoaAtendenteController : Controller
    {
        public IActionResult Index()
        {
            using (var data = new PessoaAtendenteData())
                return View(data.Read());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(IFormCollection atendente)
        {
            string nome = atendente["Nome"];
            string cpf = atendente["CPF"];
            string telefone = atendente["Telefone"];
            string login = atendente["Login"];
            string senha = atendente["Senha"];
            double salario = Convert.ToDouble(atendente["Salario"]);

            if (nome.Length < 6)
            {
                ViewBag.Mensagem = "Nome deve conter 6 ou mais carecteres";
            }
            if (senha.Length < 6)
            {
                ViewBag.Mensagem = "Senha deve conter 6 caracteres ou mais";
                return View();
            }

            var novoAtendente = new PessoaAtendente();
            novoAtendente.Nome = atendente["Nome"];
            novoAtendente.CPF = atendente["CPF"];
            novoAtendente.Telefone = atendente["Telefone"];
            novoAtendente.Login = atendente["Login"];
            novoAtendente.Senha = atendente["Senha"];
            novoAtendente.Salario = Convert.ToDecimal(atendente["Salario"]);


            using (var data = new PessoaAtendenteData())
                data.Create(novoAtendente);

            return RedirectToAction("Index", novoAtendente);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View(new PessoaAtendenteViewModel());
        }

        [HttpPost]
        public IActionResult Login(PessoaAtendenteViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            using (var data = new PessoaAtendenteData())
            {
                var user = data.Read(model);

                if (user == null)
                {
                    ViewBag.Message = "Email e/ou senha incorretos!";
                    return View(model);
                }

                HttpContext.Session.SetString("user", JsonSerializer.Serialize<PessoaAtendente>(user));

                return RedirectToAction("Index", "Produto");
            }
        }
    }
}