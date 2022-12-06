using ServerTemp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServerTempAPI.Controllers
{
    public class ServerTempController : ApiController
    {
        [HttpGet]
        public IHttpActionResult ReadTemp()
        {
             string[] lines =  Utility.ReadFileContents();

             return Ok(lines);
        }

        [HttpGet]
        public IHttpActionResult WriteTemp(String d1, String v1, String d2, String v2, String d3, String v3)
        {
            List<KeyValuePair<String, String>> keyVals = Utility.ConvertToKeyValuePair(new String[] { d1, d2, d3 }, new String[] { v1, v2, v3 });
            Utility.PersistData(keyVals);

            return Ok("Success");
        }

     
    }
}
