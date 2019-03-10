using Programming.API.Attributes;
using Programming.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace Programming.API.Controllers
{
    public class LanguagesController : ApiController
    {
        LanguagesDal languagesDal = new LanguagesDal();
        [HttpGet]
        public IHttpActionResult SearchByName(string name)
        {
            return Ok("Name : " + name);
        }

        [HttpGet]
        public IHttpActionResult SearchBySurname(string surname)
        {
            return Ok("Name : " + surname);
        }

        [Authorize]
        [ResponseType(typeof(IEnumerable<Languages>))]
        public IHttpActionResult Get()
        {
            var languages = languagesDal.GetAllLanguages();

            return Ok(languages);
                
                //Request.CreateResponse(HttpStatusCode.OK, languages);
        }
        [ResponseType(typeof(Languages))]
        [ApiExceptionAttribute]
        public IHttpActionResult Get(int id)
        {
            //try
            //{
                var language = languagesDal.GetLanguagesById(id);
                if (language == null)
                {
                    return NotFound();
                    //Request.CreateResponse(HttpStatusCode.NotFound,"Böyle kayıt bulunamadı");
                }

                return Ok(language);
                //Request.CreateResponse(HttpStatusCode.OK, language);
            //}
            //catch (Exception e)
            //{
                //HttpResponseMessage errorResponse = new HttpResponseMessage(HttpStatusCode.BadGateway);
                //errorResponse.ReasonPhrase = e.Message;
                //throw new HttpResponseException(errorResponse);
            //}
        }
        [ResponseType(typeof(Languages))]
        public IHttpActionResult Post (Languages languages)
        {
            if (ModelState.IsValid)
            {
                var createdLanguage = languagesDal.CreateLanguage(languages);
                return CreatedAtRoute("DefaultApi", new { id = createdLanguage.ID }, createdLanguage);
                    
                   // Request.CreateResponse(HttpStatusCode.Created, createdLanguage);
            }
            else
            {
                return BadRequest(ModelState);
                    //Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

        }
        [ResponseType(typeof(Languages))]
        public IHttpActionResult Put(int id,Languages languages)
        {
            if (languagesDal.IsThereAnyLanguage(id))
            {
                return NotFound();
                    //Request.CreateErrorResponse(HttpStatusCode.NotFound, "Bulunamadı");

            }
            else if (ModelState.IsValid==false)
            {
                return BadRequest(ModelState);
                    //Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            else
            {
                return Ok(languagesDal.UpdateLanguage(id, languages));
                    //Request.CreateResponse(HttpStatusCode.OK, languagesDal.UpdateLanguage(id, languages));
            }
        
        }
        public IHttpActionResult Delete(int id)
        {
            if (languagesDal.IsThereAnyLanguage(id)==false)
            {
                return NotFound();
                    //Request.CreateErrorResponse(HttpStatusCode.NotFound, "Kayıt bulunamadı");
            }
            else
            {
                languagesDal.DeleteLanguage(id);
                return Ok(); 
                    //Request.CreateResponse(HttpStatusCode.NoContent);
            }
        }

       
    }
}
