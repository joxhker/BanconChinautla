using BanconChinautla.DbConnection;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BanconChinautla.Repository
{
    public class BancoRepository : IBancoRepository
    {
        //Template de un Data Source para el connection string
        //<hostname or IP address>:<listener port>/<database service name>
        //ConnectionString completo de ejemplo: User Id=hr;Password=<password>;Data Source=localhost:1521/orcl

        const string connectionString = "ORACLE connectionString here";
        private OracleConnection _conexion;

        BancoRepository()
        {
            
        }

        public bool CrearCuenta()
        {
            var queryString = "";
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                OracleCommand command = new OracleCommand(queryString, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }

            //Retornar si fue exitoso o no... si se desea mensaje de excepción, retornar un string
            return true;
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
