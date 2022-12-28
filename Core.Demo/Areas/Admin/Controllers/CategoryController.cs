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
        public IActionResult AddCategory(Category p)
        {
            CategoryValidator cv = new CategoryValidator();
            ValidationResult results = cv.Validate(p); //validationu kontrol edecek
            if (results.IsValid) //gecerli ise
            {
                p.CategoryStatus = true;             
                cm.TAdd(p);
                return RedirectToAction("Index", "Category");

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
        public IActionResult DeleteCategory(int id)
        {
            var value = cm.TGetByID(id);
            cm.TDelete(value);
            return RedirectToAction("Index");
        }
    }
}
