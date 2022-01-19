using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GTGatoFortunna.Bussines
{
    public class Cuenta
    {
        public static Data.Result Add(Data.Cuenta cuenta)
        {
            try
            {
                return FileXML.NewItem(cuenta);
            }
            catch (Exception error)
            {
                return Bussines.Result.GetResult(error, true, null);
            }
        }

        internal static Data.Result Get()
        {
            try
            {
                return FileXML.Query();
            }
            catch (Exception error)
            {
                return Bussines.Result.GetResult(error, true, null);
            }
        }

        internal static Data.Result GetById(int CuentaId)
        {
            try
            {
                return FileXML.Query(CuentaId);
            }
            catch (Exception error)
            {
                return Bussines.Result.GetResult(error, true, null);
            }
        }
    }
}
