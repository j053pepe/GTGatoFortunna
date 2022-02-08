using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GTGatoFortunna.Bussines
{
    public class Reporte
    {
        public static (Data.Result<List<Data.Cuenta>>,Data.Result<Data.LogAction>) Get()
        {
            try
            {
                return FileXML.Query();
            }
            catch (Exception error)
            {
                return Result.GetResult(error, true, new List<Data.Cuenta>() { });
            }
        }
    }
}
