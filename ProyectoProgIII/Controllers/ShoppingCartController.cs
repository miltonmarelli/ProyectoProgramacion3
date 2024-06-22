using Microsoft.AspNetCore.Mvc;

namespace ProyectoProgIII.Controllers
{
    public class ShoppingCartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}