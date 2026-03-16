using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Sln_Farmacovigilancia_v2.Models;
using Sln_Farmacovigilancia_v2.Repositorio;

namespace Sln_Farmacovigilancia_v2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepositorioFarmacovigilancia repositorioFarmacovigilancia;

        public HomeController(ILogger<HomeController> logger, IRepositorioFarmacovigilancia repositorioFarmacovigilancia )
        {
            _logger = logger;
            this.repositorioFarmacovigilancia = repositorioFarmacovigilancia;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult productos()
        {
            return View();
        }

        public IActionResult RegistrarFarmacovigilancia()
        {
            return View();
        }

        public IActionResult farmacovigilancia()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Crear(datosFarmacovigilancia model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await repositorioFarmacovigilancia.Crear(model);

            return Ok();
        }



    }
}
