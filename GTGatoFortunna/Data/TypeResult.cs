using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GTGatoFortunna.Data
{
    public class TypeResult 
    {
        public static Data.Result<Data.LogAction> Log { get; set; }
        public static Data.Result<List<Data.Cuenta>> ResCuentas { get; set; }
        public static Data.Result<Data.Cuenta> ResCuenta { get; set; }
        public static Data.Result<List<Data.Mes>> Meses { get; set; }
        public static Data.Result<List<Data.ConfigGato>> ConfigGato { get; set; }
    }

    public static class TupleExtensions
    {
        public static (Data.Result<List<Data.Mes>>, Data.Result<Data.LogAction>) CheckNull(this (Data.Result<List<Data.Mes>>, Data.Result<Data.LogAction>) Data)
        {
            Data.Item1 = Data.Item1 ?? new Result<List<Mes>> { ErrorLine = "0", InnerExeption = "No data", Message = "Sin datos", Resultado = new List<Mes>() { }, Status = false };
            Data.Item2 = Data.Item2 ?? new Result<LogAction> { ErrorLine = "0", InnerExeption = "No data", Message = "Sin datos", Status = false, Resultado = new LogAction { Resultado = "Fallo", Tabla = "Ninguna" } };

            return Data;
        }

        public static (Data.Result<Data.Cuenta>, Data.Result<Data.LogAction>) CheckNull(this (Data.Result<Data.Cuenta>, Data.Result<Data.LogAction>) Data)
        {
            Data.Item1 = Data.Item1 ?? new Result<Cuenta>{ ErrorLine = "0", InnerExeption = "No data", Message = "Sin datos", Resultado = new Cuenta { }, Status = false };
            Data.Item2 = Data.Item2 ?? new Result<LogAction> { ErrorLine = "0", InnerExeption = "No data", Message = "Sin datos", Status = false, Resultado = new LogAction { Resultado = "Fallo", Tabla = "Ninguna" } };

            return Data;
        }

        public static (Data.Result<List<Data.Cuenta>>, Data.Result<Data.LogAction>) CheckNull(this (Data.Result<List<Data.Cuenta>>, Data.Result<Data.LogAction>) Data)
        {
            Data.Item1 = Data.Item1 ?? new Result<List<Data.Cuenta>> { ErrorLine = "0", InnerExeption = "No data", Message = "Sin datos", Resultado = new List<Data.Cuenta>() { }, Status = false };
            Data.Item2 = Data.Item2 ?? new Result<LogAction> { ErrorLine = "0", InnerExeption = "No data", Message = "Sin datos", Status = false, Resultado = new LogAction { Resultado = "Fallo", Tabla = "Ninguna" } };

            return Data;
        }

        public static (Result<List<Data.ConfigGato>>, Result<LogAction>) CheckNull(this (Result<List<Data.ConfigGato>>, Result<LogAction>) Data)
        {
            Data.Item1 = Data.Item1 ?? new Result<List<Data.ConfigGato>> { ErrorLine = "0", InnerExeption = "No data", Message = "Sin datos", Resultado = new List<Data.ConfigGato>() { }, Status = false };
            Data.Item2 = Data.Item2 ?? new Result<LogAction> { ErrorLine = "0", InnerExeption = "No data", Message = "Sin datos", Status = false, Resultado = new LogAction { Resultado = "Fallo", Tabla = "Ninguna" } };

            return Data;
        }
    }
}
