using BanconChinautla.DbConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BanconChinautla.Repository
{
    public class BancoRepository : IBancoRepository
    {
        private OrclConnection _conexion;
        BancoRepository()
        {

        }

        public void Add()
        {
            throw new NotImplementedException();
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
