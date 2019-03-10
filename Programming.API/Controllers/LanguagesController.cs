using Programming.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Programming.API.Controllers
{
    public class LanguagesController : ApiController
    {
        LanguagesDal languagesDal = new LanguagesDal();
        public HttpResponseMessage Get()
        {
            var languages = languagesDal.GetAllLanguages();

            return Request.CreateResponse(HttpStatusCode.OK, languages);
        }
        public HttpResponseMessage Get(int id)
        {
            var language = languagesDal.GetLanguagesById(id);
            if (language==null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound,"Böyle kayıt bulunamadı");
            }

            return Request.CreateResponse(HttpStatusCode.OK, language);
        }
        public Languages Post (Languages languages)
        {
            return languagesDal.CreateLanguage(languages);
        }
        public Languages Put(int id,Languages languages)
        {
            return languagesDal.UpdateLanguage(id, languages);
        }
        public void Delete(int id)
        {
            languagesDal.DeleteLanguage(id);
        }
    }
}
