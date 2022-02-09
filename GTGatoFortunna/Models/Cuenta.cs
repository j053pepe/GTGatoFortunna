using System.Collections.Generic;

namespace GTGatoFortunna.Models
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
