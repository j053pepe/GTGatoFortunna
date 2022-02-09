using System;
using System.Collections.Generic;

namespace GTGatoFortunna.Models
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
