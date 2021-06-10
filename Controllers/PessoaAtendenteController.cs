using System;
using System.Text.Json;
using Inter_KissEspataria.Data;
using Inter_KissEspataria.Models;
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
            bool admin = Convert.ToBoolean(atendente["Admin"]);

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
            novoAtendente.Admin = atendente["Admin"];


            using (var data = new PessoaAtendenteData())
                data.Create(novoAtendente);

            return RedirectToAction("Index", novoAtendente);
        }

        // [HttpPost]
        // public IActionResult Read(IFormCollection atendente)
        // {
        //     string nome = atendente["Nome"];
        //     string telefone = atendente["Telefone"];
        //     string cpf = atendente["CPF"];
        //     string login = atendente["Login"];
        //     string senha = atendente["Senha"];

        //     if(!login.Equals(" "))
        //     {
        //         var atend = new PessoaAtendente();

        //         atend.Nome = atendente["Nome"];
        //         atend.Login = atendente["Login"];
                

        //         PessoaAtendente a = new PessoaAtendente();

        //         using (var data = new PessoaAtendenteData())
        //             a = data.Read(atend.Login);

        //         if(a.Senha == atend.Senha)
        //         {
        //             ViewBag.Mensagem = "Olá";
        //             return View("Index", c);
        //         }
        //         else
        //         {
        //             ViewBag.Mensagem = "Usuário ou senha inválidos";
        //             return View("Index", null);
        //         }

        //     }

        //     return View("Create");
        // }

        public IActionResult Delete(int id)
        {
            using (var data = new PessoaAtendenteData())
                data.Delete(id);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            using (var data = new PessoaAtendenteData())
                return View(data.Read(id));
        }

        [HttpPost]
        public IActionResult Update(int id, PessoaAtendente atendente)
        {
            atendente.PessoaId = id;

            if (!ModelState.IsValid)
                return View(atendente);

            using (var data = new PessoaAtendenteData())
                data.Update(atendente);

            return RedirectToAction("Index");
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
                    ViewBag.Message = "Login e/ou senha incorretos!";
                    return View(model);
                }

                HttpContext.Session.SetString("user", JsonSerializer.Serialize<PessoaAtendente>(user));

                return RedirectToAction("Index", "PessoaAtendente");
            }
        }
    }
}