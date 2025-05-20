using Biblioteca.Services.Usuario;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IUsuarioInterface _usuarioInterface;

        public ClienteController(IUsuarioInterface usuarioInterface)
        {
            _usuarioInterface = usuarioInterface;
        }

        public async Task<ActionResult> Index(int? id)
        {
            var clientes = await _usuarioInterface.BuscarUsuario(id);
            return View(clientes);
        }
    }
}
