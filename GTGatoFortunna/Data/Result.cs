using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GTGatoFortunna.Data
{
    public class Result<T> where T: class
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public string ErrorLine { get; set; }
        public string InnerExeption { get; set; }
        public T Resultado { get; set; }
    }
}
