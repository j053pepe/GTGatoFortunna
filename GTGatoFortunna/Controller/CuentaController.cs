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
            Models.Cuenta Cuenta = JsonSerializer.Deserialize<Models.Cuenta>(ItemCuenta);

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
            (Models.Result<List<Models.Cuenta>>, Models.Result<Models.LogAction>) result = Bussines.Cuenta.Get();

            if (result.Item1.Status)
            {
                var resultCuenta = result.Item1.Resultado.Select(item =>
                new
                {
                    item.CuentaId,
                    item.ImgProfile,
                    item.MesGato,
                    item.Nick,
                    item.Servidor,
                    Combo = Bussines.TirosGato.GetCombo(item.MesGato)
                });

                return Ok(new { Resultado = resultCuenta });
            }
            else { return BadRequest(result.Item2); }
        }
    }
}
