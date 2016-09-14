using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Net.Http;
using MinimalOwinWebApiSelfHost.Models;
using System.Data.Entity;
using System.Net;

namespace MinimalOwinWebApiSelfHost.Controllers
{
    public class DocumentsController : ApiController
    {
        ApplicationDbContext _Db = new ApplicationDbContext();
        
        public IEnumerable<Document> Get()
        {
            return _Db.Documents.ToList();
        }

        public HttpResponseMessage Post([FromBody]PostDocumentModel model)
        {
            //if (!Request.Content.IsMimeMultipartContent())
            //    throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);

            //var provider = new MultipartMemoryStreamProvider();
            //await Request.Content.ReadAsMultipartAsync(provider);
            //foreach (var file in provider.Contents)
            //{
            //    var filename = file.Headers.ContentDisposition.FileName.Trim('\"');
            //    var buffer = await file.ReadAsByteArrayAsync();
            //    //Do whatever you want with filename and its binaray data.
            //}

            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }

    public class PostDocumentModel
    {
        public string Name { get; set; }
        public string Tags { get; set; }
    }
}
