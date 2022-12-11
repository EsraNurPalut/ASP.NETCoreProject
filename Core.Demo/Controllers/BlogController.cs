using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Demo.Controllers
{
    [AllowAnonymous]
    public class BlogController : Controller
    {
        BlogManager bm = new BlogManager(new EFBlogRepository());

        public IActionResult Index()
        {
            var values = bm.GetBlogListWithCategory();
            return View(values);
        }

        public IActionResult BlogReadAll(int id)
        {
            ViewBag.i = id;
            var values = bm.GetBlogByID(id);
            return View(values);
        }

        public IActionResult BlogListWithWriter()
        {
            var values = bm.GetBlogListWithWriter(1);
            return View(values);
        }
        [HttpGet]
       public IActionResult BlogAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult BlogAdd(Blog p)
        {
                BlogValidator bv = new BlogValidator();
                ValidationResult results = bv.Validate(p); //validationu kontrol edecek
                if (results.IsValid) //gecerli ise
                {
                    p.BlogStatus = true;
                p.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString()); //anın tarihini al
                bm.TAdd(p);
                    return RedirectToAction("BlogListWithWriter", "Blog");

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
