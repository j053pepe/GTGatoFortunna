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

        public static Data.Result NewItem(Data.Cuenta data)
        {
            try
            {
                List<Data.Cuenta> lstDB = (List<Data.Cuenta>)Query().Resultado;
                lstDB = lstDB is null ? new List<Data.Cuenta>() : lstDB;
                lstDB.Add(data);

                XmlSerializer xmlSerializer = new XmlSerializer(lstDB.GetType());

                using (StreamWriter writer = new StreamWriter(FilePath))
                {
                    xmlSerializer.Serialize(writer, lstDB);
                }

                return Result.GetResult(new { Message = "Guardado correctamente" }, false, null);
            }
            catch (Exception error)
            {
                return Result.GetResult(error, true, null);
            }
        }

        internal static Data.Result Query(int cuentaId)
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

                return Result.GetResult(new { Message = "Consulta Exitosa" }, false, lstResult.FirstOrDefault(x=> x.CuentaId==cuentaId));

            }
            catch (Exception error)
            {
                return Result.GetResult(error, true, null);
            }
        }

        public static Data.Result UpdateItem(Data.Cuenta cuenta)
        {
            try
            {
                List<Data.Cuenta> lstDB = (List<Data.Cuenta>)Query().Resultado;
                int index = lstDB.FindIndex(x => x.CuentaId == cuenta.CuentaId);

                if (index!=-1)
                {
                    lstDB[index] = cuenta;

                    XmlSerializer xmlSerializer = new XmlSerializer(lstDB.GetType());

                    using (StreamWriter writer = new StreamWriter(FilePath))
                    {
                        xmlSerializer.Serialize(writer, lstDB);
                    }

                    return Result.GetResult(new { Message = "Guardado correctamente" }, false, null);
                }
                else
                {
                    return Result.GetResult(new { Message = "No se encontro el id" }, true, null);
                }
            }
            catch (Exception error)
            {
                return Result.GetResult(error, true, null);
            }
        }
        public static Data.Result Exist()
        {
            try
            {
                if (File.Exists(FilePath))
                {
                    return Result.GetResult(new { Message = "El archivo ya existe" }, false, null);
                }
                else
                {
                    File.Create(FilePath);
                    return Result.GetResult(new { Message = "El archivo fue creado exitosamente" }, false, null);
                }
            }
            catch (Exception error)
            {
                return Result.GetResult(error, true, null);
            }
        }
        public static Data.Result Query()
        {
            try
            {
                Exist();

                XDocument doc = XDocument.Load(FilePath);
                var serializer = new XmlSerializer(typeof(Data.Cuenta));
                var items = doc.Element("ArrayOfCuenta").Elements("Cuenta");//.Select(x=> x.Value).ToList();
                List<Data.Cuenta> lstResult = new List<Data.Cuenta>() ;

                items.ToList().ForEach(x =>
                {
                    lstResult.Add((Data.Cuenta)serializer.Deserialize(x.CreateReader()));
                });
                
                return Result.GetResult(new { Message = "Consulta Exitosa" }, false, lstResult);

            }
            catch (Exception error)
            {
                return Result.GetResult(error, true, null);
            }
        }

    }
}
