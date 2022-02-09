using GTGatoFortunna.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GTGatoFortunna.Bussines.Extensions
{
    public class TypeResult 
    {
        public static Result<LogAction> Log { get; set; }
        public static Result<List<Models.Cuenta>> ResCuentas { get; set; }
        public static Result<Models.Cuenta> ResCuenta { get; set; }
        public static Result<List<Models.Mes>> Meses { get; set; }
        public static Result<List<ConfigGato>> ConfigGato { get; set; }
    }

    public static class TupleExtensions
    {
        public static (Result<List<Models.Mes>>, Result<LogAction>) CheckNull(this (Result<List<Models.Mes>>, Result<LogAction>) Data)
        {
            Data.Item1 = Data.Item1 ?? new Result<List<Models.Mes>> { ErrorLine = "0", InnerExeption = "No data", Message = "Sin datos", Resultado = new List<Models.Mes>() { }, Status = false };
            Data.Item2 = Data.Item2 ?? new Result<LogAction> { ErrorLine = "0", InnerExeption = "No data", Message = "Sin datos", Status = false, Resultado = new LogAction { Resultado = "Fallo", Tabla = "Ninguna" } };

            return Data;
        }

        public static (Result<Models.Cuenta>, Result<LogAction>) CheckNull(this (Result<Models.Cuenta>, Result<LogAction>) Data)
        {
            Data.Item1 = Data.Item1 ?? new Result<Models.Cuenta>{ ErrorLine = "0", InnerExeption = "No data", Message = "Sin datos", Resultado = new Models.Cuenta { }, Status = false };
            Data.Item2 = Data.Item2 ?? new Result<LogAction> { ErrorLine = "0", InnerExeption = "No data", Message = "Sin datos", Status = false, Resultado = new LogAction { Resultado = "Fallo", Tabla = "Ninguna" } };

            return Data;
        }

        public static (Result<List<Models.Cuenta>>, Result<LogAction>) CheckNull(this (Result<List<Models.Cuenta>>, Result<LogAction>) Data)
        {
            Data.Item1 = Data.Item1 ?? new Result<List<Models.Cuenta>> { ErrorLine = "0", InnerExeption = "No data", Message = "Sin datos", Resultado = new List<Models.Cuenta>() { }, Status = false };
            Data.Item2 = Data.Item2 ?? new Result<LogAction> { ErrorLine = "0", InnerExeption = "No data", Message = "Sin datos", Status = false, Resultado = new LogAction { Resultado = "Fallo", Tabla = "Ninguna" } };

            return Data;
        }

        public static (Result<List<ConfigGato>>, Result<LogAction>) CheckNull(this (Result<List<ConfigGato>>, Result<LogAction>) Data)
        {
            Data.Item1 = Data.Item1 ?? new Result<List<ConfigGato>> { ErrorLine = "0", InnerExeption = "No data", Message = "Sin datos", Resultado = new List<ConfigGato>() { }, Status = false };
            Data.Item2 = Data.Item2 ?? new Result<LogAction> { ErrorLine = "0", InnerExeption = "No data", Message = "Sin datos", Status = false, Resultado = new LogAction { Resultado = "Fallo", Tabla = "Ninguna" } };

            return Data;
        }
    }
}
