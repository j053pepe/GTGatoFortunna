using GTGatoFortunna.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace GTGatoFortunna.Data
{
    public class FileXML
    {
        static XDocument xmldoc;
        static string FilePath = "Data/DB.xml";

        /// <summary>
        /// Agrega un elemento al archivo 
        /// </summary>
        /// <param name="data">Elemento de tipo Data.Cuenta</param>
        /// <returns></returns>
        public static Result<LogAction> NewItem(Models.Cuenta data)
        {
            try
            {
                List<Models.Cuenta> lstDB = Query().Item1.Resultado;
                lstDB = lstDB is null ? new List<Models.Cuenta>() : lstDB;
                lstDB.Add(data);

                XmlSerializer xmlSerializer = new XmlSerializer(lstDB.GetType());

                using (StreamWriter writer = new StreamWriter(FilePath))
                {
                    xmlSerializer.Serialize(writer, lstDB);
                }

                return Bussines.Result.GetResult(new { Message = "Guardado correctamente" }, false, new LogAction { });
            }
            catch (Exception error)
            {
                return Bussines.Result.GetResult(error, true, new LogAction { });
            }
        }

        internal static (Result<Models.Cuenta>, Result<LogAction>) Query(int cuentaId)
        {
            try
            {
                XDocument doc = XDocument.Load(FilePath);
                var serializer = new XmlSerializer(typeof(Models.Cuenta));
                var items = doc.Element("ArrayOfCuenta").Elements("Cuenta");//.Select(x=> x.Value).ToList();
                List<Models.Cuenta> lstResult = new List<Models.Cuenta>();

                items.ToList().ForEach(x =>
                {
                    lstResult.Add((Models.Cuenta)serializer.Deserialize(x.CreateReader()));
                });

                return Bussines.Result.GetResult(new { Message = "Consulta Exitosa" }, false, lstResult.FirstOrDefault(x => x.CuentaId == cuentaId));

            }
            catch (Exception error)
            {
                return Bussines.Result.GetResult(error, true, new Models.Cuenta { });
            }
        }

        public static Result<LogAction> InsertNewCat(Models.Cuenta ItemGato)
        {
            try
            {
                List<Models.Cuenta> lstDB = Query().Item1.Resultado;
                int index = lstDB.FindIndex(x => x.CuentaId == ItemGato.CuentaId);

                if (index != -1)
                {
                    if (!lstDB[index].MesGato.Exists(x => x.MesId == ItemGato.MesGato.FirstOrDefault().MesId && x.Año == ItemGato.MesGato.FirstOrDefault().Año))
                    {
                        ItemGato.MesGato.FirstOrDefault().Id = lstDB[index].MesGato.Count() + 1;
                        lstDB[index].MesGato.Add(ItemGato.MesGato.FirstOrDefault());

                        XmlSerializer xmlSerializer = new XmlSerializer(lstDB.GetType());

                        using (StreamWriter writer = new StreamWriter(FilePath))
                        {
                            xmlSerializer.Serialize(writer, lstDB);
                        }

                        return Bussines.Result.GetResult(new { Message = "Guardado correctamente" }, false, new LogAction { Resultado = $"Registro {ItemGato.CuentaId} - Actualizado", Tabla = "Cuenta - MesGato" });
                    }
                    else
                    {
                        return Bussines.Result.GetResult(new { Message = "El Año y mes ya existen, favor de modificarlos" }, true, new LogAction { });
                    }
                }
                else
                {
                    return Bussines.Result.GetResult(new { Message = "No se encontro el id" }, true, new LogAction { });
                }
            }
            catch (Exception error)
            {
                return Bussines.Result.GetResult(error, true, new LogAction { });
            }
        }
        public static Result<LogAction> UpdateItem(Models.Cuenta cuenta)
        {
            try
            {
                List<Models.Cuenta> lstDB = Query().Item1.Resultado;
                int index = lstDB.FindIndex(x => x.CuentaId == cuenta.CuentaId);

                if (index != -1)
                {
                    lstDB[index] = cuenta;

                    XmlSerializer xmlSerializer = new XmlSerializer(lstDB.GetType());

                    using (StreamWriter writer = new StreamWriter(FilePath))
                    {
                        xmlSerializer.Serialize(writer, lstDB);
                    }

                    return Bussines.Result.GetResult(new { Message = "Guardado correctamente" }, false, new LogAction { Resultado = $"Registro {cuenta.CuentaId} - Actualizado", Tabla = "Cuenta" });
                }
                else
                {
                    return Bussines.Result.GetResult(new { Message = "No se encontro el id" }, true, new LogAction { });
                }
            }
            catch (Exception error)
            {
                return Bussines.Result.GetResult(error, true, new LogAction { });
            }
        }
        public static Result<LogAction> Exist()
        {
            try
            {
                if (File.Exists(FilePath))
                {
                    return Bussines.Result.GetResult(new { Message = "El archivo ya existe" }, false, new LogAction { });
                }
                else
                {
                    File.Create(FilePath);
                    return Bussines.Result.GetResult(new { Message = "El archivo fue creado exitosamente" }, false, new LogAction { });
                }
            }
            catch (Exception error)
            {
                return Bussines.Result.GetResult(error, true, new LogAction { });
            }
        }
        public static (Result<List<Models.Cuenta>>, Result<LogAction>) Query()
        {
            List<Models.Cuenta> lstResult = new List<Models.Cuenta>();
            try
            {
                Exist();

                XDocument doc = XDocument.Load(FilePath);
                var serializer = new XmlSerializer(typeof(Models.Cuenta));
                var items = doc.Element("ArrayOfCuenta").Elements("Cuenta");//.Select(x=> x.Value).ToList();                

                items.ToList().ForEach(x =>
                {
                    lstResult.Add((Models.Cuenta)serializer.Deserialize(x.CreateReader()));
                });

                return Bussines.Result.GetResult(new { Message = "Consulta Exitosa" }, false, lstResult);

            }
            catch (Exception error)
            {
                return Bussines.Result.GetResult(error, true, lstResult);
            }
        }

    }
}
