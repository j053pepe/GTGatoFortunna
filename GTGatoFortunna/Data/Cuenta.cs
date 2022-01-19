using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GTGatoFortunna.Data
{
    public class Cuenta
    {
        public int CuentaId { get; set; }
        public string Nick { get; set; }
        public string Servidor { get; set; }
        public string ImgProfile { get; set; }

        public virtual List<GatoFortuna> MesGato { get; set; }
    }
}
