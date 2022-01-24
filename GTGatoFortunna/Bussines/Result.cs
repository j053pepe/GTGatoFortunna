using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GTGatoFortunna.Bussines
{
    public class Result
    {
        public static Data.Result<dynamic> GetResult(dynamic data, bool IsError, dynamic result)
        {
            if (IsError)
            {
                var dataExp = data as Exception;
                return new Data.Result<dynamic>
                {
                    ErrorLine = dataExp?.StackTrace??"",
                    Message = dataExp?.Message??"",
                    InnerExeption = dataExp.InnerException?.Message ?? "",
                    Status = false
                };
            }
            else
            {
                return new Data.Result<dynamic>
                {
                    Message = (string)data?.Message ?? "",
                    Status = true,
                    Resultado = result
                };
            }
        }
    }
}
