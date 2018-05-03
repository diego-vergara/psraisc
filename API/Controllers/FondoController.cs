using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.ApplicationInsights.Extensibility.Implementation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.Domain;
using Service;

namespace API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class FondoController : Controller
    {
        private FondoService FondoService { get; set; }

        public FondoController(FondoService fondoService)
        {
            FondoService = fondoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await FondoService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var fondo = await FondoService.GetAsync(id);
            if(fondo == null)
            {
                return NotFound(new
                {
                    Code = 1,
                    Error = "No se encontro el fondo solicitado"
                });
            }

            return Ok(fondo);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]Fondo fondo)
        {
            if(!ModelState.IsValid)
            {
                return NotFound(new
                {
                    Code = 0,
                    Error = "Los datos ingresados son incorrectos"
                });
            }

            FondoService.AddAsync(fondo);
            var result = await FondoService.CommitAsync();

            if(result == false)
            {
                return NotFound(new
                {
                    Code = 0,
                    Error = "Ocurrio un error al grabar los datos ingresados"
                });
            }

            return Ok(fondo);

        }

        //[HttpGet("codigo/{codigo}")]
        //public async Task<IActionResult> GetByCodigo(string codigo)
        //{
        //    var fondo = await FondoService.FindByCodigoAsync(codigo);
        //    if (fondo == null)
        //    {
        //        return NotFound(new
        //        {
        //            Code = 1203,
        //            Error = "No se encontro el fondo solicitado"
        //        });
        //    }

        //    return Ok(fondo);
        //}
    }
}