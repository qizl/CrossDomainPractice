using System;
using System.IO;
using System.Web;
using System.Web.Http;

namespace WebServer.Controllers
{
    public class FileController : ApiController
    {
        public string Post()
        {
            var context = (HttpContextBase)Request.Properties["MS_HttpContext"];

            if (context.Request.Files != null && context.Request.Files.Count > 0)
            {
                // 1.保存文件
                var f = context.Request.Files[0];
                string fileName = Path.GetFileName(f.FileName);

                return fileName;
            }
            throw new Exception("未接收到文件！");
        }
    }
}
