using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoProject
{
    public enum LanguageType
    {
        CSharp = 1,
        Javascript,
        Python,
        SQL,
        Java
    }
    public class Developer
    {
        public int DeveloperIdNumber { get; set; }
        public string DeveloperName { get; set; }
        public bool HasAccessToPluralsight { get; set; }
        public LanguageType TypeOfLanguage { get; set; }

        public Developer() { }

        public Developer(string developerName, int developerIdNumber, bool hasAccessToPluralsight, LanguageType codingLanguage)
        {
            DeveloperIdNumber = developerIdNumber;
            DeveloperName = developerName;
            HasAccessToPluralsight = hasAccessToPluralsight;
            TypeOfLanguage = codingLanguage;
        }
    }
}
