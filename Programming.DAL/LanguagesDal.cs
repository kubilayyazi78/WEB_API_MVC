using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming.DAL
{
    public class LanguagesDal
    {
        ProgrammingDbEntities db = new ProgrammingDbEntities();

        public IEnumerable<Languages> GetAllLanguages()
        {
            return db.Languages;
        }
        public Languages GetLanguagesById(int id)
        {
            return db.Languages.Find(id);
        }

        public Languages CreateLanguage(Languages languages)
        {
            db.Languages.Add(languages);
            db.SaveChanges();
            return languages;
        }

        public Languages UpdateLanguage(int id ,Languages languages)
        {
            db.Entry(languages).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return languages;

        }

        public void DeleteLanguage(int id)
        {
            db.Languages.Remove(db.Languages.Find(id));
            db.SaveChanges();
        }
        public bool IsThereAnyLanguage(int id)
        {
            return db.Languages.Any(x=>x.ID==id);
        }
    }
}
