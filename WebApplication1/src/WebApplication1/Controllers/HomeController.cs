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

            var buckets = service.Buckets.List("mineral-minutia-820").Execute();
            if (buckets.Items != null)
            {
                foreach (var bucket in buckets.Items)
                {
                    Console.WriteLine($"Bucket: {bucket.Name}");
                    ret = ret +  bucket.Name + "," ;
                }
            }
            ViewData["Message"] = "bucketList: [" + ret + "]";
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