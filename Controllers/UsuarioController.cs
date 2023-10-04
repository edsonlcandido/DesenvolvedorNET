﻿using DesenvolvedorNET.Models;
using DesenvolvedorNET.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DesenvolvedorNET.Controllers
{
    public class UsuarioController : Controller
    {
        public ViewResult Index()
        {
            ViewData["Title"] = "Usuários";
            //get all Usuarios from database
            var list = UsuarioRepository.GetAll();
            //convert ienumerable to list
            List<Usuario> usuarios = list.Result.ToList();
            ViewData["Usuarios"] = usuarios;
            return View();
        }
        // GET: /Usuario/Details/5
        public ViewResult Details(string id)
        {
            ViewData["Title"] = "Usuário - detalhes";
            //get usuario from database by id
            var resul = UsuarioRepository.GetById(id);
            Usuario usuario = resul.Result;
            ViewData["Usuario"] = usuario;
            return View("Details");
        }
    }
}
