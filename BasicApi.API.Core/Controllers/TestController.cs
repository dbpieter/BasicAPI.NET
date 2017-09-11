using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace BasicApi.API.Core.Controllers
{
    [RoutePrefix("api/test")]
    public class TestController : ApiController
    {
        public TestController() { }

        [Route("hello")]
        [HttpGet]
        public IHttpActionResult Hello()
        {
            return Ok("hello");
        }

        [Route("getfile")]
        [HttpGet]
        public HttpResponseMessage Test()
        {
            string localFilePath = HttpContext.Current.Server.MapPath("~/somePicture.jpeg");
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            //response.Content = new StreamContent(yourFileStream);
            response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
            response.Content.Headers.ContentDisposition.FileName = Path.GetFileName(localFilePath);
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/jpeg");

            return response;
        }
    }
}
