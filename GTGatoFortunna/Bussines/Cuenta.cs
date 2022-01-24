using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GTGatoFortunna.Bussines
{
    public class Cuenta
    {
        /// <summary>
        /// Añade un nuevo elemento de tipo Data.Cuenta
        /// </summary>
        /// <param name="cuenta"></param>
        /// <returns>Regresa un tipo Data.Result</returns>
        public static Data.Result<dynamic> Add(Data.Cuenta cuenta)
        {
            try
            {
                return FileXML.NewItem(cuenta);
            }
            catch (Exception error)
            {
                return Bussines.Result.GetResult(error, true, null);
            }
        }

        internal static Data.Result<dynamic> Get()
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

        internal static Data.Result<dynamic> GetById(int CuentaId)
        {
            try
            {
                return FileXML.Query(CuentaId);
            }
            catch (Exception error)
            {
                return Bussines.Result.GetResult(error, true, null);
            }
        }
    }
}
