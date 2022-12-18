using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using Core.Demo.Models;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
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
        [HttpGet]
        public IActionResult WriterEditProfile()
        {
            var values = wm.TGetByID(1);
            return View(values);

        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult WriterEditProfile(Writer p)
        {
                wm.TUpdate(p);
                return RedirectToAction( "Index", "Dashboard");
        }


        [AllowAnonymous]
        [HttpGet]
        public IActionResult WriterAdd()
        {
            return View();

        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult WriterAdd(AddProfileImge p)
        {
            Writer w = new Writer();
            if (p.WriterImage !=null)
            {
                var extension = Path.GetExtension(p.WriterImage.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/writerImageFiles/", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                p.WriterImage.CopyTo(stream);
                w.WriterImage = newimagename;
            }
            w.WriterMail = p.WriterMail;
            w.WriterName = p.WriterName;
            w.Password = p.Password;
            w.WriterStatus = true;
            w.WriterAbout = p.WriterAbout;
            wm.TAdd(w);
            return RedirectToAction("Index", "Dashboard");
        }

    }
}
