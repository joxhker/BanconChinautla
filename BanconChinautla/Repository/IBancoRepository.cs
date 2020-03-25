using BanconChinautla.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BanconChinautla.Repository
{
    public interface IBancoRepository
    {
        bool CrearCuenta();
        int CrearCaja();
        void Update();
        void Delete();
        List<CajaVM> ListCaja();
    }
}
