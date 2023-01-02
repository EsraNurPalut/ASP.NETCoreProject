using Core.Demo.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Demo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WriterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult WriterList()
        {
            var JsonWriters = JsonConvert.SerializeObject(writers);  //SerializeObject:bir nesnedeki verinin bir yerde depolanması veya ağ ortamında bir yerden bir yere gönderilmesi gerektiği durumlarda uygun formata dönüştürmek.
            return Json(JsonWriters);
        }

        public static List<WriterClass> writers = new List<WriterClass>
        {
            new WriterClass
            {
                Id=1,
                Name="Ayşe"
            },
            new WriterClass
            {
                Id=2,
                Name="Ali"
            },
            new WriterClass
            {
                Id=3,
                Name="Aybüke"
            },
        };
    }
}
