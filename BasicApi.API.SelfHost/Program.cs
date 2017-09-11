using BasicApi.Api;
using System;
using Microsoft.Owin.Hosting;

namespace BasicApi.API.SelfHost
{
    class Program
    {
        static void Main()
        {
            string baseAddress = "http://localhost:8080/";

            // Start OWIN host 
            using (WebApp.Start<Startup>(url: baseAddress))
            {
                Console.WriteLine("API running");
                Console.WriteLine("Press Any key to exit");
                Console.ReadLine();
            }
        }

    }
}
