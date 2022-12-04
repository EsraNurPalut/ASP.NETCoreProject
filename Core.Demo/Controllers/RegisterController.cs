using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Demo.Controllers
{
    public class RegisterController : Controller
    {
        WriterManager wm = new WriterManager(new EFWriterRepository());


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Writer p )
        {
            WriterValidator wv = new WriterValidator();
            ValidationResult results =wv.Validate(p); //validationu kontrol edecek
            if (results.IsValid) //gecerli ise
            {
                p.WriterAbout = "Deneme";
                p.WriterStatus = true;
                wm.WriterAdd(p);
                return RedirectToAction("Index", "Blog");

            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);   //hata mesajı dönderecek. propertının ismi ve mesajı verri.
                }
            }
            return View();
        }
    }
}
