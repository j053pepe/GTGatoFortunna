using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GTGatoFortunna.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class MesController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var result = Bussines.Mes.Get();
            if (result.Status)
            {
                return Ok(result);
            }
            else { return BadRequest(result); }
        }
    }
}
