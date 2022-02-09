using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace GTGatoFortunna.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuentaController : ControllerBase
    {
        [HttpPut]
        public IActionResult New([FromForm] IFormFile file, [FromForm] string ItemCuenta)
        {
            Data.Cuenta Cuenta = JsonSerializer.Deserialize<Data.Cuenta>(ItemCuenta);

            if (file.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    var fileBytes = ms.ToArray();
                    Cuenta.ImgProfile = Convert.ToBase64String(fileBytes);
                    // act on the Base64 data
                }
            }

            var result = Bussines.Cuenta.Add(Cuenta);
            if (result.Status)
            {
                return Ok(result);
            }
            else { return BadRequest(result); }
        }

        [HttpGet]
        public IActionResult Get()
        {
            (Data.Result<List<Data.Cuenta>>, Data.Result<Data.LogAction>) result = Bussines.Cuenta.Get();

            if (result.Item1.Status)
            {
                return Ok(result.Item1);
            }
            else { return BadRequest(result.Item2); }
        }
    }
}
