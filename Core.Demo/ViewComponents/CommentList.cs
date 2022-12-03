using Core.Demo.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Demo.ViewComponents
{
    public class CommentList:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var commentvalues = new List<UserComment>
            {
                new UserComment
                {
                     ID=1,
                     Username="ESRA"
                },
                new UserComment
                {
                     ID=1,
                     Username="ALİ"
                },
                new UserComment
                {
                     ID=1,
                     Username="EKİM"
                },
            };
            return View(commentvalues);
        }

        

    }
}
