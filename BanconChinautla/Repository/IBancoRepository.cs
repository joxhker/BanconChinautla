using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BanconChinautla.Repository
{
    public interface IBancoRepository
    {
        bool CrearCuenta();
        void Update();
        void Delete();
    }
}
