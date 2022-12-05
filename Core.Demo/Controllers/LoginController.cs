using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Demo.Controllers
{
    public class LoginController : Controller
    {
        [AllowAnonymous] //Kurallardan muaf olmalı.
        public IActionResult Index()
        {
            return View();
        }
    }
}
