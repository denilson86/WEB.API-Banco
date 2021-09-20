using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB.API_Banco.Controllers
{
    public class ContaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
