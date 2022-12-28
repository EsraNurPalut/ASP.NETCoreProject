using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Demo.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic1:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
