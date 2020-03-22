using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace BanconChinautla.DbConnection
{
    public static class OrclConnection
    {
        public static OracleConnection getConnection()
        {
            try
            {
                String connString = "Pooling=false;User Id=PROYECTOFINAL_DEV;Password=PROYECTOFINAL_DEV;Data Source=localhost:1521/DBMANAGERS;";
                return new OracleConnection(connString);
            }
            catch (Exception ep)
            {

            }
            return null;
        }

    }
}
