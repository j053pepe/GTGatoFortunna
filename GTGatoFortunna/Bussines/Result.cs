using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GTGatoFortunna.Bussines
{
    public class Result
    {
        public static Data.Result GetResult(dynamic data, bool IsError, dynamic result)
        {
            if (IsError)
            {
                var dataExp = (Exception)data;
                return new Data.Result
                {
                    ErrorLine = dataExp?.StackTrace??"",
                    Message = dataExp?.Message??"",
                    InnerExeption = dataExp.InnerException?.Message ?? "",
                    Status = false
                };
            }
            else
            {
                return new Data.Result
                {
                    Message = (string)data?.Message ?? "",
                    Status = true,
                    Resultado = result
                };
            }
        }
    }
}
