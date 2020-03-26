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
        List<SelectListItem> selectAgencias(); 
        int EliminarCaja(int cod_caja,int token); 
        int CrearCaja(int cod_agencia, int no_caja, int token);
    }
}
