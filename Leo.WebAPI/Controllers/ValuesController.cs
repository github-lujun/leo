using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Leo.WebAPI.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            var filename = DateTime.Now.Ticks;
            string relativePath2 = "/Files/QueryInfo/" + "csv" + "/";
            string path2 = HttpContext.Current.Server.MapPath(relativePath2);
            string newfilename = filename + ".xls";
            string path3 = Path.Combine(path2, newfilename);
            if (!System.IO.Directory.Exists(path2))
            {
                System.IO.Directory.CreateDirectory(path2);
            }
            using (FileStream fs = new FileStream(path3, FileMode.OpenOrCreate, FileAccess.Write))
            {
                
            }
            var fileurl = relativePath2 + newfilename;
            return fileurl;
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
