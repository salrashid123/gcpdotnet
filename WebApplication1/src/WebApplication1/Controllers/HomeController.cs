using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Google.Cloud.Storage.V1;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public IActionResult Health()
        {
            ViewBag.Status = "ok";
            return PartialView();
        }

        public IActionResult GCS()
        {
            var ret = "";
            var client = StorageClient.Create();

            foreach (var obj in client.ListObjects("uspto-pair", "").Take(100))
            {
                    ret = ret + "  " + obj.Name + "  ";
            }
            ViewData["Message"] = "Object list in gs://uspto-pair: [" + ret + "]";
            return View();
        }


    }
}