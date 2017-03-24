using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebClient.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public string File()
        {
            if (Request.Files != null && Request.Files.Count > 0)
            {
                // 1.保存文件
                var f = Request.Files[0];
                string fileName = Path.GetFileName(f.FileName);

                //Response.AddHeader("location", $"http://localhost:62299/{fileName}");
                //Response.Write(fileName);

                return fileName;
            }
            else throw new Exception("未接收到文件！");
        }
    }
}