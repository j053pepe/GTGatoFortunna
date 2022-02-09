using GTGatoFortunna.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GTGatoFortunna.Bussines
{
    public class Reporte
    {
        public static (Models.Result<List<Models.Cuenta>>,Models.Result<Models.LogAction>) Get()
        {
            try
            {
                return FileXML.Query();
            }
            catch (Exception error)
            {
                return Result.GetResult(error, true, new List<Models.Cuenta>() { });
            }
        }
    }
}
