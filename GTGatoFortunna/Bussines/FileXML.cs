using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace GTGatoFortunna.Bussines
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
        public static Data.Result<Data.LogAction> NewItem(Data.Cuenta data)
        {
            try
            {
                List<Data.Cuenta> lstDB = Query().Item1.Resultado;
                lstDB = lstDB is null ? new List<Data.Cuenta>() : lstDB;
                lstDB.Add(data);

                XmlSerializer xmlSerializer = new XmlSerializer(lstDB.GetType());

                using (StreamWriter writer = new StreamWriter(FilePath))
                {
                    xmlSerializer.Serialize(writer, lstDB);
                }

                return Result.GetResult(new { Message = "Guardado correctamente" }, false, new Data.LogAction { });
            }
            catch (Exception error)
            {
                return Result.GetResult(error, true, new Data.LogAction { });
            }
        }

        internal static (Data.Result<Data.Cuenta>, Data.Result<Data.LogAction>) Query(int cuentaId)
        {
            try
            {
                XDocument doc = XDocument.Load(FilePath);
                var serializer = new XmlSerializer(typeof(Data.Cuenta));
                var items = doc.Element("ArrayOfCuenta").Elements("Cuenta");//.Select(x=> x.Value).ToList();
                List<Data.Cuenta> lstResult = new List<Data.Cuenta>();

                items.ToList().ForEach(x =>
                {
                    lstResult.Add((Data.Cuenta)serializer.Deserialize(x.CreateReader()));
                });

                return Result.GetResult(new { Message = "Consulta Exitosa" },false, lstResult.FirstOrDefault(x=> x.CuentaId==cuentaId));

            }
            catch (Exception error)
            {
                return Result.GetResult(error, true, new Data.Cuenta{ });
            }
        }

        public static Data.Result<Data.LogAction> UpdateItem(Data.Cuenta cuenta)
        {
            try
            {
                List<Data.Cuenta> lstDB = Query().Item1.Resultado;
                int index = lstDB.FindIndex(x => x.CuentaId == cuenta.CuentaId);

                if (index!=-1)
                {
                    lstDB[index] = cuenta;

                    XmlSerializer xmlSerializer = new XmlSerializer(lstDB.GetType());

                    using (StreamWriter writer = new StreamWriter(FilePath))
                    {
                        xmlSerializer.Serialize(writer, lstDB);
                    }

                    return Result.GetResult(new { Message = "Guardado correctamente" }, false, new Data.LogAction {Resultado=$"Registro {cuenta.CuentaId} - Actualizado",Tabla="Cuenta" });
                }
                else
                {
                    return Result.GetResult(new { Message = "No se encontro el id" }, true, new Data.LogAction { });
                }
            }
            catch (Exception error)
            {
                return Result.GetResult(error, true, new Data.LogAction { });
            }
        }
        public static Data.Result<Data.LogAction> Exist()
        {
            try
            {
                if (File.Exists(FilePath))
                {
                    return Result.GetResult(new { Message = "El archivo ya existe" }, false, new Data.LogAction { });
                }
                else
                {
                    File.Create(FilePath);
                    return Result.GetResult(new { Message = "El archivo fue creado exitosamente" }, false, new Data.LogAction { } );
                }
            }
            catch (Exception error)
            {
                return Result.GetResult(error, true, new Data.LogAction { });
            }
        }
        public static (Data.Result<List<Data.Cuenta>>, Data.Result<Data.LogAction>) Query()
        {
            List<Data.Cuenta> lstResult = new List<Data.Cuenta>();
            try
            {
                Exist();

                XDocument doc = XDocument.Load(FilePath);
                var serializer = new XmlSerializer(typeof(Data.Cuenta));
                var items = doc.Element("ArrayOfCuenta").Elements("Cuenta");//.Select(x=> x.Value).ToList();                

                items.ToList().ForEach(x =>
                {
                    lstResult.Add((Data.Cuenta)serializer.Deserialize(x.CreateReader()));
                });
                
                return Result.GetResult(new { Message = "Consulta Exitosa" }, false, lstResult);

            }
            catch (Exception error)
            {
                return Result.GetResult(error, true, lstResult);
            }
        }

    }
}
