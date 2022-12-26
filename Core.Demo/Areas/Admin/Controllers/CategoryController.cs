using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace Core.Demo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EFCategoryRepository());

        public IActionResult Index(int page = 1)
        {    
            var values = cm.GetList().ToPagedList(page,3); //topagedlist :baslangıc parametresi(sayfalamaa işlemşn kacıncı sayfadan baslıyor),her bir sayfada senin kac tane degerin olacak. 
            return View(values);
        }

        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCatgeory(Category category)
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
