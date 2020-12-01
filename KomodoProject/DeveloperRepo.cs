using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoProject
{
    public class DeveloperRepo
    {
        private readonly List<Developer> _developerDirectory = new List<Developer>();

        //Developer Create
        public void AddDeveloperToList(Developer person)
        {
            _developerDirectory.Add(person);
        }

        //Developer Read
        public List<Developer> GetDeveloperList()
        {
            return _developerDirectory;
        }

        //Developer Update
        public bool UpdateExistingDevelopers(int originalIdNumber, Developer newPerson)
        {
            Developer oldPerson = GetDeveloperByIdNumber(originalIdNumber);

            if (oldPerson != null)
            {
                oldPerson.DeveloperIdNumber = newPerson.DeveloperIdNumber;
                oldPerson.DeveloperName = newPerson.DeveloperName;
                oldPerson.HasAccessToPluralsight = newPerson.HasAccessToPluralsight;
                oldPerson.TypeOfLanguage = newPerson.TypeOfLanguage;

                return true;
            }
            else
            {
                return false;
            }
        }

        //Developer Delete
        public bool RemoveDeveloperFromList(int idNumber)
        {
            Developer person = GetDeveloperByIdNumber(idNumber);
            if (person == null)
            {
                return false;
            }

            int inititialCount = _developerDirectory.Count;
            _developerDirectory.Remove(person);

            if (inititialCount > _developerDirectory.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Developer Helper (Get Developer by ID)
        public Developer GetDeveloperByIdNumber(int idNumber)
        {
            foreach (Developer person in _developerDirectory)
            {
                if (person.DeveloperIdNumber == idNumber)
                {
                    return person;
                }
            }

            return null;
        }
    }
}
