using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BanconChinautla.Models
{
    public class CajaVM
    {

        public String codCaja { get; set; }
        public String codAgencia { get; set; }
        public String noCaja { get; set; }
        public String status { get; set; }
        public String nombreAgencia { get; set; }
        public String statusAgencia { get; set; }

    }
}
