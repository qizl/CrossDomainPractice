using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Http;

namespace WebServer.Controllers
{
    [RoutePrefix("api")]
    public class FileController : ApiController
    {
        private static Dictionary<string, string> dics = new Dictionary<string, string>();

        public string Post(string key)
        {
            var context = (HttpContextBase)Request.Properties["MS_HttpContext"];

            if (context.Request.Files != null && context.Request.Files.Count > 0)
            {
                // 1.保存文件
                var f = context.Request.Files[0];
                string fileName = Path.GetFileName(f.FileName);

                dics.Add(key, fileName);

                return fileName;
            }
            throw new Exception("未接收到文件！");
        }

        [Route("File/Key")]
        public Guid GetKey() => Guid.NewGuid();

        public string Get(string key)
        {
            var v = string.Empty;
            if (dics.ContainsKey(key))
            {
                v = dics[key];
                dics.Remove(key);
            }
            return v;
        }
    }
}
