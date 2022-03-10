using GTGatoFortunna.Data;
using GTGatoFortunna.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GTGatoFortunna.Bussines
{
    public class TirosGato
    {
        public static (Models.Result<List<Models.ConfigGato>>, Models.Result<Models.LogAction>) GetConfig()
        {
            try
            {
                var ConfigGato = Enum.GetValues(typeof(Models.Enum.ConfigGato))
                    .Cast<Models.Enum.ConfigGato>()
                    .Select(M => new Models.ConfigGato
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
                return Bussines.Result.GetResult(error, true, new List<Models.ConfigGato>() { });
            }
        }

        internal static List<Models.Combo> GetCombo(List<GatoFortuna> mesGato)
        {
            List<Models.Combo> lstCombo = new List<Combo>();
            lstCombo.Add(new Combo { value = 0, text = "Selecciona un año" });
            lstCombo.Add(new Combo { value = -1, text = "Todos los años" });

            lstCombo.AddRange(
            mesGato.Select(x => x.Año)
                .Distinct()
                .Select(x => new Combo
                {
                    text = $"Año {x}",
                    value = x
                })
                .ToList());

            return lstCombo;
        }

        internal static Models.Result<Models.LogAction> Save(Models.Cuenta cuenta)
        {
            try
            {
                return FileXML.InsertNewCat(cuenta);
            }
            catch (Exception error)
            {
                return Bussines.Result.GetResult(error, true, new Models.LogAction { });
            }
        }
    }
}
