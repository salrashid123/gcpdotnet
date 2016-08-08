using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


using Google.Apis;
using Google.Apis.Auth.OAuth2;

using Google.Apis.Util.Store;

using Google.Apis.Storage.v1;
using Google.Apis.Storage.v1.Data;

using Google.Apis.Auth.OAuth2.Responses;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Services;


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

        public async Task<IActionResult> GCS()
        {
            var ret = "";
            service = await CreateServiceAsync();

            var listRequest = service.Objects.List("uspto-pair");
            listRequest.MaxResults = 100;
            var obj = listRequest.Execute();
            if (obj.Items != null)
            {
                foreach (var o in obj.Items)
                {
                    Console.WriteLine($"Object: {o.Name}");
                    ret = ret + "  " + o.Name + "  ";
                }
            }
            ViewData["Message"] = "Object list in gs://uspto-pair: [" + ret + "]";
            return View();
        }

        private StorageService service;
        private async Task<StorageService> CreateServiceAsync()
        {
            GoogleCredential credential = await GoogleCredential.GetApplicationDefaultAsync();
            var serviceInitializer = new BaseClientService.Initializer()
            {
                ApplicationName = "Storage Sample",
                HttpClientInitializer = credential
            };
            service = new StorageService(serviceInitializer);
            return service;
        }

    }
}