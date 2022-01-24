using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GTGatoFortunna.Bussines
{
    public class TirosGato
    {
        public static Data.Result<dynamic> GetConfig()
        {
            try
            {
                var ConfigGato = Enum.GetValues(typeof(Data.ConfigGato))
                    .Cast<Data.ConfigGato>()
                    .Select(M => new
                    {
                        Nombre = (int)M == 20 ? "Primer Tiro" :
                                (int)M == 30 ? "Segundo Tiro" :
                                (int)M == 65 ? "Tercer Tiro" :
                                (int)M == 150 ? "Cuarto Tiro" :
                                (int)M == 240 ? "Quinto Tiro" :
                                (int)M == 330 ? "Sexto Tiro" :
                                (int)M == 500 ? "Septimo Tiro" : "Octavo Tiro",
                        Numero = (int)M == 20 ? 1 :
                                (int)M == 30 ? 2 :
                                (int)M == 65 ? 3 :
                                (int)M == 150 ? 4 :
                                (int)M == 240 ? 5 :
                                (int)M == 330 ? 6 :
                                (int)M == 500 ? 7 : 8,
                        BaseTiro = (int)M
                    })
                    .ToList();

                return Result.GetResult(new { Message = "ConsultaExitosa" }, false, ConfigGato);
            }
            catch (Exception error)
            {
                return Bussines.Result.GetResult(error, true, null);
            }
        }

        internal static Data.Result<dynamic> Save(Data.Cuenta cuenta)
        {
            try
            {
                return Bussines.FileXML.UpdateItem(cuenta);
            }
            catch (Exception error)
            {
                return Bussines.Result.GetResult(error, true, null);
            }
        }
    }
}
