using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoProject
{
    public enum CodingLanguagePrefered
    {
        CSharp = 1,
        Javascript,
        Python,
        SQL,
        Java
    }
    public class DevTeam
    {
        public int DevTeamId { get; set; }
        public string DevTeamName { get; set; }
        public CodingLanguagePrefered PreferedLanguage { get; set; }
        public List<Developer> DevTeamMembers { get; set; } = new List<Developer>();

        public DevTeam() { }

        public DevTeam(int devTeamId, string devTeamName, CodingLanguagePrefered codeLanguage)
        {
            DevTeamId = devTeamId;
            DevTeamName = devTeamName;
            PreferedLanguage = codeLanguage;
        }
    }
}
