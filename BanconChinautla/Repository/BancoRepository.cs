using BanconChinautla.DbConnection;
using BanconChinautla.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        const string connectionString = "Pooling=false;User Id=PROYECTOFINAL_DEV;Password=PROYECTOFINAL_DEV;Data Source=localhost:1521/DBMANAGERS;";

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

        public int CrearCaja()
        {
            var queryString = "";
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                OracleCommand command = new OracleCommand(queryString, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }

            //Retornar si fue exitoso o no... si se desea mensaje de excepción, retornar un string
            return 1;
        }

        public List<CajaVM> ListCaja()
        {
            List<CajaVM> p = new List<CajaVM>();
            OracleConnection cp = new OracleConnection(connectionString);
            if (cp == null) { return p; }
            using (OracleCommand cmd = cp.CreateCommand())
            {
                cp.Open();
                cmd.CommandText = "SELECT TO_CHAR(C.COD_CAJA), TO_CHAR(C.COD_AGENCIA), TO_CHAR(C.NO_CAJA) , CASE WHEN C.STATUS = 'A' THEN 'ALTA' ELSE 'BAJA' END A , A.NOMBRE, CASE WHEN A.STATUS = 'A' THEN 'ALTA' ELSE 'BAJA' END B FROM TB_CAJA C  LEFT JOIN TB_AGENCIA A ON C.COD_AGENCIA = A.COD_AGENCIA ORDER BY C.COD_CAJA,A.COD_AGENCIA";
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CajaVM item = new CajaVM();
                    item.codCaja = reader.GetString(0);
                    item.codAgencia = reader.GetString(1);
                    item.noCaja = reader.GetString(2);
                    item.status = reader.GetString(3);
                    item.nombreAgencia = reader.GetString(4);
                    item.statusAgencia = reader.GetString(5);
                    p.Add(item);
                }
            }
            return p;
        }

        public List<SelectListItem> selectAgencias()
        {
            List<SelectListItem> send = new List<SelectListItem>();
            OracleConnection cp = new OracleConnection(connectionString);
            if (cp == null) { return send; }
            using (OracleCommand cmd = cp.CreateCommand())
            {
                cp.Open();
                cmd.CommandText = "SELECT COD_AGENCIA, NOMBRE ||', '||DIRECCION ZONA FROM TB_AGENCIA WHERE STATUS = 'A'";
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SelectListItem item = new SelectListItem
                    {
                        Text = reader.GetString(1),
                        Value = reader.GetInt32(0).ToString()
                    };
                    send.Add(item);
                }
            }
            return send;
        }


        public int EliminarCaja(int cod_caja, int token)
        {
            int result = 0;
            OracleConnection cp = new OracleConnection(connectionString);
            if (cp == null) { return -500; }
            using (OracleCommand cmd = cp.CreateCommand())
            {
                cp.Open();
                cmd.CommandText = "SELECT FN_BAJA_CAJA("+cod_caja+", "+token+") valor from dual";
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result = reader.GetInt32(0);
                }
            }
            return result;
        }

        public int CrearCaja(int cod_agencia, int no_caja, int token)
        {
            int result = 0;
            OracleConnection cp = new OracleConnection(connectionString);
            if (cp == null) { return -500; }
            using (OracleCommand cmd = cp.CreateCommand())
            {
                cp.Open();
                cmd.CommandText = "select FN_CREAR_CAJA("+cod_agencia+ ", "+ no_caja + ", "+ token + ") info from dual";
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result = reader.GetInt32(0);
                }
            }
            return result;
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
