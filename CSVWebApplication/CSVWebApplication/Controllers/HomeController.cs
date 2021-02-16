using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CSVWebApplication.Models;
using Microsoft.AspNetCore.Hosting.Server.Features;
using System.Globalization;

namespace CSVWebApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<Order> ordersList = new List<Order>();
            var lines = System.IO.File.ReadAllLines(@"Content/Orders.csv");

            for (int i = 1; i < lines.Length; i++)
            {
                var values = lines[i].Split(',');
                if (values.Count() > 0)
                {
                    ordersList.Add(new Order()
                    {
                        Id = int.Parse(values[0]),
                        Number = int.Parse(values[1]),
                        Status = values[2],
                        Datecreated = Convert.ToDateTime(values[3]),
                        Total = decimal.Parse(values[4], CultureInfo.InvariantCulture),
                        CustomerId = int.Parse(values[5]),
                        CouierCompany = values[6],
                        WayBillNo = values[7]
                    });
                }
            }

            //foreach (string item in lines)
            //{
                
                
            //}

            return View(ordersList);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
