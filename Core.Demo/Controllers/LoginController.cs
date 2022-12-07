using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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

        public IActionResult Index(Writer p)
        {
            Context c = new Context();
            var datavalue = c.Writers.FirstOrDefault(x => x.WriterMail == p.WriterMail && x.Password == p.Password);
            if (datavalue !=null)
            {
                HttpContext.Session.SetString("username", p.WriterMail);
                return RedirectToAction("Writer", "Blog");
            }
            else
            {
                return View();
            }
        }

    }
}
