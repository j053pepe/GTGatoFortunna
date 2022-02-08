using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GTGatoFortunna.Data
{
    public class GatoFortuna
    {
        public int Id { get; set; }
        public int Año { get; set; }
        public int MesId { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int InvocacionesBase { get; set; }
        public int InvocacionesResultado { get; set; }
        public virtual List<TirosGato> TirosGato { get; set; }
    }
}
