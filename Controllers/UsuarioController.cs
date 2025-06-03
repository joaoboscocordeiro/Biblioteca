using Biblioteca.Dtos.Usuario;
using Biblioteca.Enums;
using Biblioteca.Services.Usuario;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioInterface _usuarioInterface;

        public UsuarioController(IUsuarioInterface usuarioInterface)
        {
            _usuarioInterface = usuarioInterface;
        }

        public async Task<IActionResult> Index(int? id)
        {
            var usuarios = await _usuarioInterface.BuscarUsuario(id);
            return View(usuarios);
        }

        [HttpGet]
        public ActionResult Cadastrar(int? id)
        {
            ViewBag.Perfil = PerfilEnum.Administrador;

            if (id != null)
            {
                ViewBag.Perfil = PerfilEnum.Cliente;
            }

            return View();
        }

        [HttpGet]
        public async Task<ActionResult> Detalhes(int? id)
        {
            if (id != null)
            {
                var usuario = await _usuarioInterface.BuscarUsuarioPorId(id);
                return View(usuario);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<ActionResult> Cadastrar(UsuarioCriacaoDto usuarioCriacaoDto)
        {
            if (ModelState.IsValid)
            {
                var usuario = await _usuarioInterface.VerificaSeExisteUsuarioEEmail(usuarioCriacaoDto);
                if (!usuario)
                {
                    TempData["MensagemErro"] = "Já existe email/usuário cadastrado!";
                    return View(usuarioCriacaoDto);
                }

                // Cadastrar Usuário
                var user = await _usuarioInterface.Cadastrar(usuarioCriacaoDto);

                TempData["MensagemSucesso"] = "Cadastro realizado com sucesso!";

                if (user.Perfil != PerfilEnum.Cliente)
                {
                    return RedirectToAction("Index", "Funcionario");
                }

                return RedirectToAction("Index", "Cliente", new { id = "0" });
            }
            else
            {
                TempData["MensagemErro"] = "Verifique os dados informados!";
                return View(usuarioCriacaoDto);
            }
        }
    }
}
