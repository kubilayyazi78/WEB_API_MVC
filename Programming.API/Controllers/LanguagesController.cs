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
        public IEnumerable<Languages> Get()
        {
            return languagesDal.GetAllLanguages();
        }
        public Languages Get(int id)
        {
            return languagesDal.GetLanguagesById(id);
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
