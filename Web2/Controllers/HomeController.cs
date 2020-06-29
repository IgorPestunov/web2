using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Web2.Models;

namespace Web2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
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





        public IActionResult ManualParsingInSingleAction()
        {
            if (Request.Method.Equals("POST", StringComparison.OrdinalIgnoreCase))
            {
                OperationsModel OM = new OperationsModel();
                OM.value1 = Int32.Parse(Request.Form["value1"]);
                OM.value2 = Int16.Parse(Request.Form["value2"]);
                OM.operation = Request.Form["operation"];
                OM.compute();
                return View("Result", OM);
            }
            else 
                return View();


        }
        [HttpGet]
        public IActionResult ManualParsingInSeparateActions()
        {
            return View();
        }

        [HttpPost, ActionName("ManualParsingInSeparateActions")]
        public IActionResult ManualParsingInSeparateActionsPOST()
        {
            OperationsModel OM = new OperationsModel();
            OM.value1 = Int16.Parse(Request.Form["value1"]);
            OM.value2 = Int16.Parse(Request.Form["value2"]);
            OM.operation = Request.Form["operation"];
            OM.compute();
            return View("Result", OM);
        }


        public IActionResult ModelBindingInParameters(int value1, int value2, string operation)
        { if (Request.Method.Equals("POST", StringComparison.OrdinalIgnoreCase))
            {
                OperationsModel OM = new OperationsModel();
                OM.value1 = value1;
                OM.value2 = value2;
                OM.operation = operation;
                OM.compute();
                return View("Result", OM);
            }
            else 
                return View();
                
        
        }


        [HttpGet]
        public IActionResult ModelBindingInSeparateModel()
        { return View(); }

        [HttpPost]
        public IActionResult ModelBindingInSeparateModel(OperationsModel OM)
        {
            OM.compute();
            return View("Result", OM);
        }
    }
}
