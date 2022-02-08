using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GTGatoFortunna.Bussines
{
    public class Mes
    {
        public static (Data.Result<List<Data.Mes>>, Data.Result<Data.LogAction>) Get()
        {
            try
            {
                var Meses = Enum.GetValues(typeof(Data.EnumMes))
                    .Cast<Data.EnumMes>()
                    .Select(M => new Data.Mes { Nombre = M.ToString(), MesId = (int)M })
                    .ToList();

                return Result.GetResult(new { Message = "ConsultaExitosa" }, false, Meses);
            }
            catch (Exception error)
            {
                return Result.GetResult(error, true, new List<Data.Mes>() { });
            }
        }
    }
}
