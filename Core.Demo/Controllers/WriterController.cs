using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Demo.Controllers
{
  
    public class WriterController : Controller
    {
        WriterManager wm = new WriterManager(new EFWriterRepository());

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult WriterProfile()
        {
            return View();
        }

        public IActionResult WriterMail()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Test()
        {
            return View();
        }


        [AllowAnonymous]
        public IActionResult WriterNavbarPartial()
        {
            return PartialView();
        }


        [AllowAnonymous]
        public IActionResult WriterEditProfile()
        {
            var values = wm.TGetByID(1);
            return View(values);

        }



    }
}
