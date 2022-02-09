using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GTGatoFortunna.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TirosGatoController : ControllerBase
    {
        // GET: api/<TirosGatoController>
        [HttpGet]
        public IActionResult Get()
        {

            var result = Bussines.TirosGato.GetConfig();
            if (result.Item1.Status)
            {
                return Ok(result.Item1);
            }
            else { return BadRequest(result.Item2); }
        }

        [HttpPut]
        public IActionResult NuevoGatoFortuna(Models.Cuenta cuenta)
        {
            cuenta.MesGato.LastOrDefault().FechaCreacion = DateTime.Now;

            Models.Result<Models.LogAction> result = Bussines.TirosGato.Save(cuenta);
            if (result.Status)
            {
                return Ok(new
                {
                    result.Message,
                    Resultado = Bussines.Cuenta.GetById(cuenta.CuentaId).Item1.Resultado
                });
            }
            else { return BadRequest(result); }
        }
    }
}
