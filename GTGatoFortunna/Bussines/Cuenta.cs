using GTGatoFortunna.Data;
using GTGatoFortunna.Models;
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
        /// <param name="NewCuenta"></param>
        /// <returns>Regresa un tipo Result</returns>
        public static Result<LogAction> Add(Models.Cuenta NewCuenta)
        {
            try
            {
                return FileXML.NewItem(NewCuenta);
            }
            catch (Exception error)
            {
                return Bussines.Result.GetResult(error, true, new LogAction
                {
                    Resultado=$"Error al agregar el nuevo elemento",
                    Tabla="Cuenta"
                });
            }
        }

        internal static (Result<List<Models.Cuenta>>, Result<LogAction>) Get()
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

        internal static (Result<Models.Cuenta>, Result<LogAction>) GetById(int CuentaId)
        {
            try
            {
                return FileXML.Query(CuentaId);
            }
            catch (Exception error)
            {
                return Result.GetResult(error, true, new Models.Cuenta { });
            }
        }
    }
}
