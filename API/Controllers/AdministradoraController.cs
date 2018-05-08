using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class AdministradoraController : Controller
    {
        private AdministradoraService AdministradoraService { get; set; }

        public AdministradoraController(AdministradoraService administradoraService)
        {
            AdministradoraService = administradoraService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await AdministradoraService.GetAllAsync( e => e.Fondos ));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var administradora = AdministradoraService.Get(id);
            if (administradora == null)
            {
                return NotFound(new
                {
                    Code = 1,
                    Error = "No se encontro la administradora solicitada"
                });
            }

            return Ok(administradora);
        }
    }
}