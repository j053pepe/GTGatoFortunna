using GTGatoFortunna.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GTGatoFortunna.Bussines
{
    public class Result : TypeResult
    {
        public static Data.Result<Data.LogAction> GetResult(dynamic data, bool IsError, Data.LogAction result)
        {
            if (IsError)
            {
                var dataExp = data as Exception;
                return new Data.Result<Data.LogAction>
                {
                    ErrorLine = dataExp?.StackTrace ?? "",
                    Message = dataExp?.Message ?? "",
                    InnerExeption = dataExp.InnerException?.Message ?? "",
                    Status = false
                };
            }
            else
            {
                return new Data.Result<Data.LogAction>
                {
                    Message = (string)data?.Message ?? "",
                    Status = true,
                    Resultado = result
                };
            }
        }

        internal static (Result<List<Data.ConfigGato>>, Result<LogAction>) GetResult(dynamic data, bool IsError, List<Data.ConfigGato> result)
        {
            if (IsError)
            {
                var dataExp = data as Exception;
                Log = new Data.Result<Data.LogAction>
                {
                    ErrorLine = dataExp?.StackTrace ?? "",
                    Message = dataExp?.Message ?? "",
                    InnerExeption = dataExp.InnerException?.Message ?? "",
                    Status = false
                };
            }
            else
            {
                ConfigGato = new Data.Result<List<Data.ConfigGato>>
                {
                    Message = (string)data?.Message ?? "",
                    Status = true,
                    Resultado = result
                };
            }
            return (ConfigGato, Log).CheckNull();
        }

        /// <summary>
        /// Metodo para regresar la respuesta con lista de datos
        /// </summary>
        /// <param name="data">Error de tipo Exception o mensaje a regresar con .Message</param>
        /// <param name="IsError">Boleano para saber si es error o no</param>
        /// <param name="result">Lista de tipo Cuenta para regresar datos</param>
        /// <returns>
        /// Información de la tupla
        /// <list type="bullet">
        /// <item><see cref="Tuple{T1,T2}.Item1"/>: Lista de resultados.</item>
        /// <item><see cref="Tuple{T1,T2}.Item2"/>: Log de error.</item>
        /// </list>
        /// </returns>
        public static (Data.Result<List<Data.Cuenta>>, Data.Result<Data.LogAction>) GetResult(dynamic data, bool IsError, List<Data.Cuenta> result)
        {
            if (IsError)
            {
                var dataExp = data as Exception;
                Log = new Data.Result<Data.LogAction>
                {
                    ErrorLine = dataExp?.StackTrace ?? "",
                    Message = dataExp?.Message ?? "",
                    InnerExeption = dataExp.InnerException?.Message ?? "",
                    Status = false
                };
            }
            else
            {
                ResCuentas = new Data.Result<List<Data.Cuenta>>
                {
                    Message = (string)data?.Message ?? "",
                    Status = true,
                    Resultado = result
                };
            }

            return (ResCuentas, Log).CheckNull();

        }

        /// <summary>
        /// Metodo para regresar la respuesta con item tipo cuenta
        /// </summary>
        /// <param name="data">Error de tipo Exception o mensaje a regresar con .Message</param>
        /// <param name="IsError">Boleano para saber si es error o no</param>
        /// <param name="result">Item de tipo Cuenta para regresar datos</param>
        /// <returns>
        /// Información de la tupla
        /// <list type="bullet">
        /// <item><see cref="Tuple{T1,T2}.Item1"/>: Item de tipo cuenta a regresar.</item>
        /// <item><see cref="Tuple{T1,T2}.Item2"/>: Log de error.</item>
        /// </list>
        /// </returns>
        public static (Data.Result<Data.Cuenta>, Data.Result<Data.LogAction>) GetResult(dynamic data, bool IsError, Data.Cuenta result)
        {

            if (IsError)
            {
                var dataExp = data as Exception;
                Log = new Data.Result<Data.LogAction>
                {
                    ErrorLine = dataExp?.StackTrace ?? "",
                    Message = dataExp?.Message ?? "",
                    InnerExeption = dataExp.InnerException?.Message ?? "",
                    Status = false
                };
            }
            else
            {
                ResCuenta = new Data.Result<Data.Cuenta>
                {
                    Message = (string)data?.Message ?? "",
                    Status = true,
                    Resultado = result
                };
            }

            return (ResCuenta, Log).CheckNull();
        }

        /// <summary>
        /// Metodo para regresar la respuesta tipo Mes
        /// </summary>
        /// <param name="data">Error de tipo Exception o mensaje a regresar con .Message</param>
        /// <param name="IsError">Boleano para saber si es error o no</param>
        /// <param name="result">Item de tipo Cuenta para regresar datos</param>
        /// <returns>
        /// Información de la tupla
        /// <list type="bullet">
        /// <item><see cref="Tuple{T1,T2}.Item1"/>: Item de tipo mes a regresar.</item>
        /// <item><see cref="Tuple{T1,T2}.Item2"/>: Log de error.</item>
        /// </list>
        /// </returns>
        public static (Data.Result<List<Data.Mes>>, Data.Result<Data.LogAction>) GetResult(dynamic data, bool IsError, List<Data.Mes> result)
        {

            if (IsError)
            {
                var dataExp = data as Exception;
                Log = new Data.Result<Data.LogAction>
                {
                    ErrorLine = dataExp?.StackTrace ?? "",
                    Message = dataExp?.Message ?? "",
                    InnerExeption = dataExp.InnerException?.Message ?? "",
                    Status = false
                };
            }
            else
            {
                Meses = new Data.Result<List<Data.Mes>>
                {
                    Message = (string)data?.Message ?? "",
                    Status = true,
                    Resultado = result
                };
            }

            return (Meses, Log).CheckNull();
        }
    }
}
