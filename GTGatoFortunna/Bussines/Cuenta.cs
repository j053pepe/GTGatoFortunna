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
        public static Data.Result<Data.LogAction> Add(Data.Cuenta cuenta)
        {
            try
            {
                return FileXML.NewItem(cuenta);
            }
            catch (Exception error)
            {
                return Bussines.Result.GetResult(error, true, new Data.LogAction
                {
                    Resultado=$"Error al agregar el nuevo elemento",
                    Tabla="Cuenta"
                });
            }
        }

        internal static (Data.Result<List<Data.Cuenta>>, Data.Result<Data.LogAction>) Get()
        {
            try
            {
                return FileXML.Query();
            }
            catch (Exception error)
            {
                return Bussines.Result.GetResult(error, true, new List<Data.Cuenta>() { });
            }
        }

        internal static (Data.Result<Data.Cuenta>, Data.Result<Data.LogAction>) GetById(int CuentaId)
        {
            try
            {
                return FileXML.Query(CuentaId);
            }
            catch (Exception error)
            {
                return Bussines.Result.GetResult(error, true, new Data.Cuenta { });
            }
        }
    }
}
