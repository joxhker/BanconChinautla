using BanconChinautla.DbConnection;
using Microsoft.AspNetCore.Mvc.Rendering;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BanconChinautla.Models
{
    public class PaisMV
    {
        public int COD_PAIS { get; set; }
        public String DESCRIPCION { get; set; }
        public String FECHA { get; set; }
        public string TIPO { get; set; }
        public char STATUS { get; set; }

        public List<SelectListItem> Paises()
        {
            List<SelectListItem> p = new List<SelectListItem>();
            OracleConnection cp = OrclConnection.getConnection();
            if (cp == null) { return p; }
            using (OracleCommand cmd = cp.CreateCommand())
            {
                cp.Open();
                cmd.CommandText = "SELECT COD_PAIS,DESCRIPCION FROM TB_PAIS WHERE STATUS= 'A'";
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SelectListItem item = new SelectListItem
                    {
                        Text = reader.GetString(1),
                        Value = reader.GetInt32(0).ToString()
                    };
                    p.Add(item);
                }
            }
            return p;
        }
    }
}
