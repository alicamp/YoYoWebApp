using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Yo_Yo_Web_App.Models;


namespace Yo_Yo_Web_App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public ActionResult Index()
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

        [HttpGet]
        public JsonResult GetYoYoTest()
        {
            string _rootPath = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);
            _rootPath = _rootPath.Substring(0, _rootPath.IndexOf("bin"));
            string _filePath = $"{_rootPath}YoyoTest.json";
            List<YoYoClass> Items = new List<YoYoClass>();
            string json = string.Empty;
            using (StreamReader r = new StreamReader(_filePath))
            {
                json = r.ReadToEnd();
                Items = Newtonsoft.Json.JsonConvert.DeserializeObject<List<YoYoClass>>(json);
            }

            return Json(Items);
        }
    }
}
