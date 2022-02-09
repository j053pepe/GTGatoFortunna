using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GTGatoFortunna.Bussines
{
    public class Mes
    {
        public static (Models.Result<List<Models.Mes>>, Models.Result<Models.LogAction>) Get()
        {
            try
            {
                var Meses = Enum.GetValues(typeof(Models.Enum.Mes))
                    .Cast<Models.Enum.Mes>()
                    .Select(M => new Models.Mes { Nombre = M.ToString(), MesId = (int)M })
                    .ToList();

                return Result.GetResult(new { Message = "ConsultaExitosa" }, false,Meses);
            }
            catch (Exception error)
            {
                return Result.GetResult(error, true, new List<Models.Mes>() { });
            }
        }
    }
}
