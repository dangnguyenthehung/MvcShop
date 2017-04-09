using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace ShopAPI.Controllers
{
    public class UploadController : ApiController
    {
        // GET: api/Upload
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //[Route("api/Files/Uploads")]
        //public async Task<string> Post()
        //{
        //    try
        //    {
        //        var httpRequest = HttpContext.Current.Request;
        //        if (httpRequest.Files.Count > 0)
        //        {
        //            foreach (string file in httpRequest.Files)
        //            {
        //                var postedFile = httpRequest.Files[file];

        //                var fileName = postedFile.FileName.Split('\\').LastOrDefault().Split('/').LastOrDefault();
        //                var filePath = HttpContext.Current.Server.MapPath("~/Uploads/" + fileName);

        //                postedFile.SaveAs(filePath);

        //                //return "/Uploads/" + fileName;
        //                return filePath;

        //            }
        //        }
        //        else
        //        {
        //            System.Diagnostics.Debug.WriteLine("No file");
        //        }

        //    }
        //    catch (Exception exeption)
        //    {
        //        return exeption.Message;
        //    }
        //    return "No files";
        //}

        [Route("api/Files/Upload")]
        public async Task<string> PostFormData()
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }
            if (System.Web.HttpContext.Current.Request.Files.Count > 0)
            {
                var file = System.Web.HttpContext.Current.Request.Files[0];

                var fileName = file.FileName.Split('\\').LastOrDefault().Split('/').LastOrDefault();
                var filePath = HttpContext.Current.Server.MapPath("~/Uploads/" + fileName);

                file.SaveAs(filePath);

                System.Diagnostics.Debug.WriteLine(filePath);

                return filePath;
            }
            else
            {
                return "No file";
            }

        }
    }
}
