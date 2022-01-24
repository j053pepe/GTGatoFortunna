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
            if (result.Status)
            {
                return Ok(result);
            }
            else { return BadRequest(result); }
        }

        [HttpPut]
        public IActionResult NuevoGatoFortuna(Data.Cuenta cuenta)
        {
            cuenta.MesGato.LastOrDefault().FechaCreacion = DateTime.Now;
            
            Data.Result<null> result = Bussines.TirosGato.Save(cuenta);
            if (result.Status)
            {
                result.Resultado = Bussines.Cuenta.GetById(cuenta.CuentaId).Resultado;
                return Ok(result);
            }
            else { return BadRequest(result); }
        }
    }
}
