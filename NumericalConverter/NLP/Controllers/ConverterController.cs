using Newtonsoft.Json;
using NLP.Models;
using NLP.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
namespace NLP.Controllers
{
    public class ConverterController : ApiController
    {
        readonly BusinessRepository bus = new BusinessRepository();
        //resultmessage

        // GET: api/Converter
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        // POST: api/Converter
       
        [HttpPost]
        public string Convert([FromBody] TextModel txt)
        {          
            string metin = txt.Usertext.ToLower();
            return bus.ConvertToNumeric(metin);
        }

    }
}
