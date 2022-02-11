using GTGatoFortunna.Bussines.Extensions;
using GTGatoFortunna.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GTGatoFortunna.Bussines
{
    public class Result : TypeResult
    {
        public static Result<LogAction> GetResult(dynamic data, bool IsError, LogAction result)
        {
            if (IsError)
            {
                var dataExp = data as Exception;
                return new Result<LogAction>
                {
                    ErrorLine = dataExp?.StackTrace ?? "",
                    Message = dataExp is null ? data.Message: dataExp?.Message ?? "" ,
                    InnerExeption = dataExp?.InnerException?.Message ?? "" ,
                    Status = false
                };
            }
            else
            {
                return new Result<LogAction>
                {
                    Message = (string)data?.Message ?? "",
                    Status = true,
                    Resultado = result
                };
            }
        }

        internal static (Result<List<ConfigGato>>, Result<LogAction>) GetResult(dynamic data, bool IsError, List<ConfigGato> result)
        {
            if (IsError)
            {
                var dataExp = data as Exception;
                Log = new Result<LogAction>
                {
                    ErrorLine = dataExp?.StackTrace ?? "",
                    Message = dataExp is null ? data.Message : dataExp?.Message ?? "",
                    InnerExeption = dataExp?.InnerException?.Message ?? "",
                    Status = false
                };
            }
            else
            {
                ConfigGato = new Result<List<ConfigGato>>
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
        public static (Result<List<Models.Cuenta>>, Result<LogAction>) GetResult(dynamic data, bool IsError, List<Models.Cuenta> result)
        {
            if (IsError)
            {
                var dataExp = data as Exception;
                Log = new Result<LogAction>
                {
                    ErrorLine = dataExp?.StackTrace ?? "",
                    Message = dataExp is null ? data.Message : dataExp?.Message ?? "",
                    InnerExeption = dataExp.InnerException?.Message ?? "",
                    Status = false
                };
            }
            else
            {
                ResCuentas = new Result<List<Models.Cuenta>>
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
        public static (Result<Models.Cuenta>, Result<LogAction>) GetResult(dynamic data, bool IsError, Models.Cuenta result)
        {

            if (IsError)
            {
                var dataExp = data as Exception;
                Log = new Result<LogAction>
                {
                    ErrorLine = dataExp?.StackTrace ?? "",
                    Message = dataExp is null ? data.Message : dataExp?.Message ?? "",
                    InnerExeption = dataExp.InnerException?.Message ?? "",
                    Status = false
                };
            }
            else
            {
                ResCuenta = new Result<Models.Cuenta>
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
        public static (Result<List<Models.Mes>>, Result<LogAction>) GetResult(dynamic data, bool IsError, List<Models.Mes> result)
        {

            if (IsError)
            {
                var dataExp = data as Exception;
                Log = new Result<LogAction>
                {
                    ErrorLine = dataExp?.StackTrace ?? "",
                    Message = dataExp is null ? data.Message : dataExp?.Message ?? "",
                    InnerExeption = dataExp.InnerException?.Message ?? "",
                    Status = false
                };
            }
            else
            {
                Meses = new Result<List<Models.Mes>>
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
