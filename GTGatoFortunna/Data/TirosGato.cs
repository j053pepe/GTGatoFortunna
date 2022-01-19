using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GTGatoFortunna.Data
{
    public class TirosGato
    {
        public int Requerido { get; set; }
        public int Obtenido { get; set; }
        public int SubTotal { get; set; }
    }

    public enum ConfigGato
    {
        PrimerTiro = 20,
        SegundoTiro = 30,
        TercerTiro = 65,
        CuartoTiro = 150,
        QuitoTiro = 240,
        SextoTiro = 330,
        SeptimoTiro = 500,
        OctavoTiro = 660
    }
}
