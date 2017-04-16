using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

using System.Linq; 
using System.Collections.Generic;
using Google.Cloud.Storage.V1;

namespace ConsoleApplication {

    public class Startup {

        private static void GCSTest(IApplicationBuilder app)
        {
            app.Run(async context =>
            {

                var ret = "";
                var client = StorageClient.Create();

                foreach (var obj in client.ListObjects("uspto-pair", "").Take(100))
                {
                        ret = ret + "  " + obj.Name + "  ";
                }
                ret = "Object list in gs://uspto-pair: [" + ret + "]";

                await context.Response.WriteAsync(ret);
            });
        }

        private static void HealthCheck(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("ok");
            });
        }

        public void Configure(IApplicationBuilder app){

           app.Map("/gcs", GCSTest);
           app.Map("/_ah/health", HealthCheck);
                     
            app.Run(context => {
                return context.Response.WriteAsync("Hello world");
            });
        }
    }
}