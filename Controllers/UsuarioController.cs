
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Http;
    using Atividade_3_Projeto_Integrador.Models;

    namespace  Atividade_3_Projeto_Integrador.Controllers
{
    public class UsuarioController: Controller
    {
        public IActionResult Cadastro()
        {
             
        return View();
        }

         [HttpPost]
        public IActionResult Cadastro(Usuario u)
        {
            UsuarioRepository ur = new UsuarioRepository();
        ur.insert(u);
        ViewBag.Mensagem = "Usuario Cadastrado com sucesso";
        return View();
        }
        
    public IActionResult Listar()
    {
    if(HttpContext.Session.GetInt32("idUsuario") == null)
    return RedirectToAction("Login");
    UsuarioRepository ur = new UsuarioRepository();
    List<Usuario> usuarios = ur.Query();
    return View(usuarios);
    }

    public IActionResult Login()
{
    return View();
}
[HttpPost]
public IActionResult Login(Usuario u)
{
    UsuarioRepository ur = new UsuarioRepository();
    Usuario usuario = ur.QueryLogin(u);
    if(usuario != null)
    {
        ViewBag.Mensagem = "Você está logado";
        HttpContext.Session.SetInt32("idUsuario", usuario.Id);
        HttpContext.Session.SetString("nomeUsuario", usuario.Nome);
        return View("Cadastro");
    }
    else
    {
        ViewBag.Mensagem = "Falha no Login";
        return View();
    }
}
   public IActionResult Logout()
{
    HttpContext.Session.Clear();
    return View("Login");    
}

    }
}