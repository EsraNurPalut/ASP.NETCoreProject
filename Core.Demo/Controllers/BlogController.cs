using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            var values = bm.GetBlogListWithWriter(3);
            return View(values);
        }
        [HttpGet]
       public IActionResult BlogAdd() //ekleme yaparken kategorinin ıdsı ben seceyim.
        {
            CategoryManager cm = new CategoryManager(new EFCategoryRepository());
                List<SelectListItem>categoryvalues=(from x in cm.GetList()
                select new SelectListItem
                {
                    Text =x.CategoryName,
                   Value=x.CategoryID.ToString()
                    }).ToList();
            ViewBag.cv = categoryvalues;
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

        public IActionResult DeleteBlog(int id)
        {
            var blogvalue = bm.TGetByID(id);
            bm.TDelete(blogvalue);
            return RedirectToAction("BlogListWithWriter");
        }
        [HttpGet]
        public IActionResult EditBlog(int id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult EditBlog(Blog p)
        {
            return RedirectToAction("BlogListWithWriter");
        }

    }
}
