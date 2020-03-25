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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CajaVM collection)
        {
            try
            {
                if (ModelState.IsValid)
                {

                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}