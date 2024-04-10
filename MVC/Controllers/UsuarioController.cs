using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using Repositorio.Repositorios;
using Repositorio.Entidades;

namespace MVC.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly UsuarioRepository _repository;

        public UsuarioController(UsuarioRepository repository)
        {
            _repository = repository; // Inicializa o repositório de usuários
        }

        // Método para exibir a lista de usuários
        [HttpGet]
        public IActionResult Index()
        {
            // Busca todos os usuários do repositório e converte para uma lista de UsuarioModel
            var list = _repository.FindAll()
                .Select(u => new UsuarioModel
                {
                    Id = u.Id,
                    Nome = u.Nome,
                    Email = u.Email,
                    Senha = u.Senha,
                    UrlImagem = u.UrlImagem,
                    Cnpj = u.Cnpj,
                    IsFornecedor = u.IsFornecedor
                })
                .ToList();

            return View(list);
        }

        // Método para exibir os detalhes de um usuário específico
        [HttpGet]
        public IActionResult Details(long id)
        {
            var usuario = _repository.FindById(id);

            // Converte o usuário encontrado para um modelo de usuário e retorna a view Details com esse modelo
            var usuarioModel = new UsuarioModel
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                Senha = usuario.Senha,
                UrlImagem = usuario.UrlImagem,
                Cnpj = usuario.Cnpj,
                IsFornecedor = usuario.IsFornecedor
            };

            return View(usuarioModel);
        }

        // Método para exibir o formulário de criação de usuário
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Método para criar o usuário
        [HttpPost]
        public IActionResult Create(UsuarioModel usuario)
        {
            if (ModelState.IsValid)
            {
                var usuarioEntity = new Usuario
                {
                    Id = usuario.Id,
                    Nome = usuario.Nome,
                    Email = usuario.Email,
                    Senha = usuario.Senha,
                    UrlImagem = usuario.UrlImagem,
                    Cnpj = usuario.Cnpj,
                    IsFornecedor = usuario.IsFornecedor
                };

                _repository.Create(usuarioEntity);
                return RedirectToAction("Index"); // Redireciona para a página Index após a criação
            }

            return View(usuario);
        }

        // Método para exibir o formulário de edição de usuário
        [HttpGet]
        public IActionResult Update(long id)
        {
            var usuario = _repository.FindById(id);
            var usuarioModel = new UsuarioModel
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                Senha = usuario.Senha,
                UrlImagem = usuario.UrlImagem,
                Cnpj = usuario.Cnpj,
                IsFornecedor = usuario.IsFornecedor
            };

            return View(usuarioModel);
        }

        // Método para editar o usuário
        [HttpPost]
        public IActionResult Update(UsuarioModel usuario)
        {
            if (ModelState.IsValid)
            {
                var usuarioEntity = new Usuario
                {
                    Id = usuario.Id,
                    Nome = usuario.Nome,
                    Email = usuario.Email,
                    Senha = usuario.Senha,
                    UrlImagem = usuario.UrlImagem,
                    Cnpj = usuario.Cnpj,
                    IsFornecedor = usuario.IsFornecedor
                };

                _repository.Update(usuarioEntity);
                return RedirectToAction("Details", new { id = usuario.Id });
            }

            return View(usuario);
        }

        // Método para lidar com a exclusão de um usuário
        [HttpPost]
        public IActionResult Delete(long id)
        {
            _repository.Delete(id); 
            return RedirectToAction("Index"); 
        }
    }
}