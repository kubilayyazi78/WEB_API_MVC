using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Web_Api_First.Controllers
{[EnableCors("*","*","*")]
    public class SehirController : ApiController
    {//domain adresi/api/sehir

        private string[] _sehirler= new string[] { "Antalya", "Karabük", "İstanbul" };
        public string[] Get()
        {
            return _sehirler;
        }

        public string Get(int id)
        {
            return _sehirler[id];
        }
    }
}
