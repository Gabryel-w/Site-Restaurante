
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Http;
    using Atividade_3_Projeto_Integrador.Models;

    public class ReservaController:Controller
    {
        public IActionResult CadastroReserva()
        {
             if(HttpContext.Session.GetInt32("idUsuario") == null)
            return RedirectToAction("NaoLogado");
             return View();
        }

          [HttpPost]
        public IActionResult CadastroReserva(Reserva p)
        {
            ReservaRepository pr = new ReservaRepository();
            pr.insert(p);
            ViewBag.Mensagem = "Reserva Feita com sucesso";
            return View();
        }

        public IActionResult ListaReserva()
    {
        if(HttpContext.Session.GetInt32("idUsuario") == null)
        return RedirectToAction("NaoLogado");
        ReservaRepository pr = new ReservaRepository();
        List<Reserva> reservas = pr.Query();
        return View(reservas);
    }


    public IActionResult NaoLogado()
    {
        return View();
    }

    public IActionResult ReservaDeleteTodos()
        {
            ReservaRepository pr = new ReservaRepository();
            pr.deleteTodos();
            return RedirectToAction("ListaReserva");
        }







    }
