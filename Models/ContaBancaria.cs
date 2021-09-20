using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB.API_Banco.Models
{
    public class ContaBancaria
    {
        public int idCounta { get; set; }
        public double saldo { get; set; }
        public DateTime dataAbertura { get; set; }
    }
}
