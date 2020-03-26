using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BanconChinautla.Models;
using BanconChinautla.Repository;
using Microsoft.AspNetCore.Mvc; 

namespace BanconChinautla.Controllers
{
    public class CajaController : Controller
    {
        
        private readonly IBancoRepository _repo = null;

        public CajaController(IBancoRepository repo)
        {
             _repo = repo;
        }
        public IActionResult Index()
        {
            List<CajaVM> vm = new List<CajaVM>();
            vm = _repo.ListCaja();
            return View(vm);
        }
        [HttpGet]
        public IActionResult Create()
        {
            CajaVM vm = new CajaVM();
            vm.Agencias = _repo.selectAgencias();
            return View(vm); 
        }

        [HttpPost]
        public IActionResult New(CajaVM parametros)
        { 
            int info = _repo.CrearCaja(int.Parse(parametros.codAgencia),int.Parse(parametros.noCaja),5000);
            parametros.status = "Operacion con error.";
            if (info >0) { parametros.status = "Operacion exitosa"; }
             return View(parametros);
        }

        [HttpGet("{controller=Caja}/{action=delete}/{cod_caja}/{token}")]
        public IActionResult Delete(int cod_caja,int token)
        {
            int result = _repo.EliminarCaja(cod_caja, token);
            String operation = "Exito en operacion.";
            if (result<0) { operation = "error en la operacion"; }
            String[] info = { cod_caja.ToString(), token.ToString(),operation};
            return View(info.ToList());
        }

    }
}