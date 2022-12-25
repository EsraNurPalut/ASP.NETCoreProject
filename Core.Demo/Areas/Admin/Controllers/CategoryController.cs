using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
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
    }
}
