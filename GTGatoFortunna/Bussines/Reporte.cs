using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GTGatoFortunna.Bussines
{
    public class Reporte
    {
        public static Data.Result<dynamic> Get()
        {
            try
            {
                return FileXML.Query();
            }
            catch (Exception error)
            {
                return Bussines.Result.GetResult(error, true, null);
            }
        }
    }
}
