using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GTGatoFortunna.Bussines
{
    public class Mes
    {
        public static Data.Result<dynamic> Get()
        {
            try
            {
                var Meses = Enum.GetValues(typeof(Data.Mes))
                    .Cast<Data.Mes>()
                    .Select(M => new { Nombre = M.ToString(), MesId = (int)M })
                    .ToList();

                return Result.GetResult(new { Message = "ConsultaExitosa" }, false, Meses);
            }
            catch (Exception error)
            {
                return Bussines.Result.GetResult(error, true, null);
            }
        }
    }
}
