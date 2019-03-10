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
        public HttpResponseMessage Post (Languages languages)
        {
            if (ModelState.IsValid)
            {
                var createdLanguage = languagesDal.CreateLanguage(languages);
                return Request.CreateResponse(HttpStatusCode.Created, createdLanguage);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

        }
        public HttpResponseMessage Put(int id,Languages languages)
        {
            if (languagesDal.IsThereAnyLanguage(id))
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Bulunamadı");

            }
            else if (ModelState.IsValid==false)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, languagesDal.UpdateLanguage(id, languages));
            }
        
        }
        public HttpResponseMessage Delete(int id)
        {
            if (languagesDal.IsThereAnyLanguage(id)==false)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Kayıt bulunamadı");
            }
            else
            {
                languagesDal.DeleteLanguage(id);
                return Request.CreateResponse(HttpStatusCode.NoContent);
            }
        }

       
    }
}
