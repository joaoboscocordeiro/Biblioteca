using Biblioteca.Services.Usuario;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers
{
    public class FuncionarioController : Controller
    {
        private readonly IUsuarioInterface _usuarioInterface;

        public FuncionarioController(IUsuarioInterface usuarioInterface)
        {
            _usuarioInterface = usuarioInterface;
        }

        public async Task<ActionResult> Index()
        {
            var funcionarios = await _usuarioInterface.BuscarUsuario(null);
            return View(funcionarios);
        }
    }
}
