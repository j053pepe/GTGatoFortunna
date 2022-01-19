using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GTGatoFortunna.Data
{
    public class Result
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public string ErrorLine { get; set; }
        public string InnerExeption { get; set; }
        public object Resultado { get; set; }
    }
}
