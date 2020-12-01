using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoProject
{
    public class DevTeamRepo
    {
        private readonly List<DevTeam> _devTeams = new List<DevTeam>();

        //DevTeam Create
        public void AddTeamToList(DevTeam team)
        {
            _devTeams.Add(team);
        }

        //DevTeam Read
        public List<DevTeam> GetTeamList()
        {
            return _devTeams;
        }

        //DevTeam Update
        public bool UpdateExistingTeams(int originalTeamIdNumber, DevTeam newTeam)
        {
            DevTeam oldTeam = GetTeamByIdNumber(originalTeamIdNumber);

            if (oldTeam != null)
            {
                oldTeam.DevTeamId = newTeam.DevTeamId;
                oldTeam.DevTeamName = newTeam.DevTeamName;
                oldTeam.PreferedLanguage = newTeam.PreferedLanguage;

                return true;
            }
            else
            {
                return false;
            }
        }

        //DevTeam Delete
        public bool RemoveTeamFromList(int idNumber)
        {
            DevTeam team = GetTeamByIdNumber(idNumber);

            if (team == null)
            {
                return false;
            }

            int initialCount = _devTeams.Count;
            _devTeams.Remove(team);

            if (initialCount > _devTeams.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //DevTeam Helper (Get Team by ID)
        public DevTeam GetTeamByIdNumber(int idNumber)
        {
            foreach (DevTeam team in _devTeams)
            {
                if (team.DevTeamId == idNumber)
                {
                    return team;
                }
            }
            return null;
        }
    }
}
