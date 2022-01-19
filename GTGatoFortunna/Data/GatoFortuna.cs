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

    public enum Mes
    {
        Enero = 1,
        Febrero = 2,
        Marzo = 3,
        Abril = 4,
        Mayo = 5,
        Junio = 6,
        Julio = 7,
        Agosto = 8,
        Septiembre = 9,
        Octubre = 10,
        Noviembre = 11,
        Diciembre = 12
    }
}
