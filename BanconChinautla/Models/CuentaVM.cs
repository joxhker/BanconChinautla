using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BanconChinautla.Models
{
    public class CuentaVM
    {
        public string NumeroCuenta { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public decimal Saldo { get; set; }
        public bool Activa { get; set; }
        public List<SelectListItem> Tipos => new List<SelectListItem>()
                                            { new SelectListItem { Text = "Monetaria", Value = "1" },
                                              new SelectListItem { Text = "Ahorro", Value = "2"},
                                              new SelectListItem { Text = "Ahorro Preferencial", Value = "3"},
                                              new SelectListItem { Text = "Ahorro Plazo Fijo", Value = "4"}};
    }
}
