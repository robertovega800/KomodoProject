using KomodoProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoProject_Console
{
    class ProgramUI
    {
        private DevTeamRepo _teamRepo = new DevTeamRepo();

        private DeveloperRepo _developerRepo = new DeveloperRepo();
        public void Run()
        {
            SeedDeveloperList();
            SeedTeamList();
            Menu();
        }

        private void Menu()
        {
            Console.Clear();
            bool KeepRunning = true;
            while (KeepRunning)
            {
                Console.WriteLine("Select a menu option:\n" +
                    "1. Go to 'Developers' Menu\n" +
                    "2. Go to 'Dev Teams' Menu\n" +
                    "3. Exit");
                
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        DevsMenu();
                        break;
                    case "2":
                        DevTeamsMenu();
                        break;
                    case "3":
                        Console.WriteLine("Goodbye!");
                        KeepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number");
                        break;
                }
                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
        private void DevTeamsMenu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.Clear();
                Console.WriteLine("Select a menu option:\n" +
                    "1. Add New Dev Team to 'Dev Team Directory'\n" +
                    "2. View All Dev Teams\n" +
                    "3. View Dev Teams by ID Number\n" +
                    "4. Update Existing Dev Team's info\n" +
                    "5. Delete Existing Dev Team From Directory\n" +
                    "6. Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddNewDevTeam();
                        break;
                    case "2":
                        ViewAllDevTeams();
                        break;
                    case "3":
                        ViewDevTeamByIdNumber();
                        break;
                    case "4":
                        UpdateExistingDevTeam();
                        break;
                    case "5":
                        DeleteExistingDevTeam();
                        break;
                    case "6":
                        Console.WriteLine("Goodbye!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number");
                        break;
                }
                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        // Create a new Dev Team 
        private void AddNewDevTeam()
        {
            Console.Clear();
            DevTeam newTeam = new DevTeam();

            // DevTeam ID
            Console.WriteLine("Enter the ID Number for the new Dev Team:");
            newTeam.DevTeamId = int.Parse(Console.ReadLine());

            // Dev Team Project Name
            Console.WriteLine("Enter the project name for the new Dev Team:");
            newTeam.DevTeamName = Console.ReadLine();

            // Developer known language 
            Console.WriteLine("Enter the number for prefered known coding language for the project:\n" +
                "1. C#\n" +
                "2. JavaScript\n" +
                "3. Python\n" +
                "4. SQL\n" +
                "5. Java");

            string languageAsString = Console.ReadLine();
            int languageAsInt = int.Parse(languageAsString);
            newTeam.PreferedLanguage = (CodingLanguagePrefered)languageAsInt;

            _teamRepo.AddTeamToList(newTeam);
        }

        // Display all Dev Teams
        private void ViewAllDevTeams()
        {
            Console.Clear();
            List<DevTeam> listOfTeams = _teamRepo.GetTeamList();

            foreach (DevTeam team in listOfTeams)
            {
                Console.WriteLine($"Team ID Number: {team.DevTeamId}\n" +
                    $"Project Name: {team.DevTeamName}");
            }
        }

        // Display Dev Team by ID number
        private void ViewDevTeamByIdNumber()
        {
            Console.Clear();

            // Ask for team ID
            Console.WriteLine("Enter the ID number of the Dev Team you would like to see:");

            // Find the team by ID number
            int idNumber = int.Parse(Console.ReadLine());

            //Find the team by that ID Number
            DevTeam team = _teamRepo.GetTeamByIdNumber(idNumber);

            // Display team if it isn't null
            if (team != null)
            {
                Console.WriteLine($"Team ID Number: {team.DevTeamId}\n" +
                   $"Project Name: {team.DevTeamName}\n" +
                   $"Prefered Coding Language: {team.PreferedLanguage}");
            }
            else
            {
                Console.WriteLine("No team by that ID number...");
            }
        }

        // Update existing Dev Team
        private void UpdateExistingDevTeam()
        {
            // Display All Teams
            ViewAllDevTeams();

            // Ask which Dev Team to update by Team Id
            Console.WriteLine("Enter the ID number of the Dev Team you wuoldl like to update:");

            // Get that Dev Team
            int oldIdNumber = int.Parse(Console.ReadLine());

            // Build a new object
            DevTeam newTeam = new DevTeam();

            // DevTeam ID
            Console.WriteLine("Enter the ID Number for the new Dev Team:");
            newTeam.DevTeamId = int.Parse(Console.ReadLine());

            // Dev Team Project Name
            Console.WriteLine("Enter the project name for the new Dev Team:");
            newTeam.DevTeamName = Console.ReadLine();

            // Developer known language 
            Console.WriteLine("Enter the number for prefered known coding language for the project:\n" +
                "1. C#\n" +
                "2. JavaScript\n" +
                "3. Python\n" +
                "4. SQL\n" +
                "5. Java");

            string languageAsString = Console.ReadLine();
            int languageAsInt = int.Parse(languageAsString);
            newTeam.PreferedLanguage = (CodingLanguagePrefered)languageAsInt;


            // Verify the Dev Team was updated
            bool wasUpdated = _teamRepo.UpdateExistingTeams(oldIdNumber, newTeam);
            if (wasUpdated)
            {
                Console.WriteLine("Dev Team was successfully updated!");
            }
            else
            {
                Console.WriteLine("Could not update Dev Team...");
            }
        }


        // Delete existing Dev Team
        private void DeleteExistingDevTeam()
        {
            ViewAllDevTeams();

            // Get the Dev Team by Team ID number they want to delete
            Console.WriteLine("\nEnter the ID number of the team you want to remove:");

            int input = int.Parse(Console.ReadLine());

            // Call the delete method
            bool wasDeleted = _teamRepo.RemoveTeamFromList(input);

            // If the team was deleted, say so; Otherwise, state it could not be deleted
            if (wasDeleted)
            {
                Console.WriteLine("The team was successfuly deleted.");
            }
            else
            {
                Console.WriteLine("The team could not be deleted.");
            }


        }

        private void AddDevelopersToTeam()
        {

        }

        // Seed Method for DevTeams
        private void SeedTeamList()
        {
            DevTeam teamOne = new DevTeam(01, "Project 01", CodingLanguagePrefered.CSharp);
            DevTeam teamTwo = new DevTeam(02, "Project 02", CodingLanguagePrefered.CSharp);
            DevTeam teamThree = new DevTeam(03, "Project 03", CodingLanguagePrefered.CSharp);

            _teamRepo.AddTeamToList(teamOne);
            _teamRepo.AddTeamToList(teamTwo);
            _teamRepo.AddTeamToList(teamThree);
        }

        private void DevsMenu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.Clear();
                Console.WriteLine("Select a menu option:\n" +
                    "1. Add New Developer to 'Developer Directory'\n" +
                    "2. View All Developers\n" +
                    "3. View Developers by ID Number\n" +
                    "4. Update Existing Developer's info\n" +
                    "5. Delete Existing Developer From Directory\n" +
                    "6. Exit to Main Menu");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddNewDeveloper();
                        break;
                    case "2":
                        ViewAllDevelopers();
                        break;
                    case "3":
                        ViewDevelopersByIdNumber();
                        break;
                    case "4":
                        UpdateExistingDevelopers();
                        break;
                    case "5":
                        DeleteExistingDevelopers();
                        break;
                    case "6":
                        Console.WriteLine("Goodbye!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number");
                        break;
                }
                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void AddNewDeveloper()
        {
            Console.Clear();
            Developer newDeveloper = new Developer();

            //Developer ID
            Console.WriteLine("Enter the ID number for the new developer:");
            newDeveloper.DeveloperIdNumber = int.Parse(Console.ReadLine());

            //Developer Name
            Console.WriteLine("Enter the new developer's name:");
            newDeveloper.DeveloperName = Console.ReadLine();

            //Has Access To Plurlsight
            Console.WriteLine("Does this developer have access to Pluralsight? (y/n)");
            string accessToPluralsightString = Console.ReadLine().ToLower();
            
            if(accessToPluralsightString == "y")
            {
                newDeveloper.HasAccessToPluralsight = true;
            }
            else
            {
                newDeveloper.HasAccessToPluralsight = false;
            }

            //Developer's known coding language
            Console.WriteLine("Enter the known language number:\n" +
                "1.C#\n" +
                "2. JavaScript\n" +
                "3. Python\n" +
                "4. SQL\n" +
                "5. Java");

            string languageAsString = Console.ReadLine();
            int languageAsInt = int.Parse(languageAsString);
            newDeveloper.TypeOfLanguage = (LanguageType)languageAsInt;

            _developerRepo.AddDeveloperToList(newDeveloper);
        }

        // Display all developers
        private void ViewAllDevelopers()
        {
            List<Developer> listOfDevelopers = _developerRepo.GetDeveloperList();

            foreach (Developer developer in listOfDevelopers)
            {
                Console.WriteLine($"Developer ID Number: {developer.DeveloperIdNumber}\n" +
                    $"Developer Name: {developer.DeveloperName}"); 
            }
        }

        // Display deveolpers by ID number
        private void ViewDevelopersByIdNumber()
        {
            Console.Clear();

            Console.WriteLine("Enter the ID number of the developer you would like to see:");

            int idNumber = int.Parse(Console.ReadLine());

            Developer developer = _developerRepo.GetDeveloperByIdNumber(idNumber);

            if(developer != null)
            {
                Console.WriteLine($"Developer ID Number: {developer.DeveloperIdNumber}\n" +
                    $"Developer Name: {developer.DeveloperName}\n" +
                    $"Does Developer Have Access To Pluralsight: {developer.HasAccessToPluralsight}\n" +
                    $"Developer's Prefered Coding Language: {developer.TypeOfLanguage}");
            }
            else
            {
                Console.WriteLine("No developer by that ID number...");
            }
        }

        // Update existing developers 
        private void UpdateExistingDevelopers()
        {
            ViewAllDevelopers();

            Console.WriteLine("Enter the ID number of the developer you would like to update:");

            int oldIdNumber = int.Parse(Console.ReadLine());

            Developer newDeveloper = new Developer();

            //Developer ID
            Console.WriteLine("Enter the ID number for the new developer:");
            newDeveloper.DeveloperIdNumber = int.Parse(Console.ReadLine());

            //Developer Name
            Console.WriteLine("Enter the new developer's name:");
            newDeveloper.DeveloperName = Console.ReadLine();

            //Has Access To Plurlsight
            Console.WriteLine("Does this developer have access to Pluralsight? (y/n)");
            string accessToPluralsightString = Console.ReadLine().ToLower();

            if (accessToPluralsightString == "y")
            {
                newDeveloper.HasAccessToPluralsight = true;
            }
            else
            {
                newDeveloper.HasAccessToPluralsight = false;
            }

            //Developer's known coding language
            Console.WriteLine("Enter the known language number:\n" +
                "1.C#\n" +
                "2. JavaScript\n" +
                "3. Python\n" +
                "4. SQL\n" +
                "5. Java");

            string languageAsString = Console.ReadLine();
            int languageAsInt = int.Parse(languageAsString);
            newDeveloper.TypeOfLanguage = (LanguageType)languageAsInt;

           bool wasUpdated =  _developerRepo.UpdateExistingDevelopers(oldIdNumber, newDeveloper);

            if (wasUpdated)
            {
                Console.WriteLine("Developer was successfully updated!");
            }
            else
            {
                Console.WriteLine("Developer was not successfully update...");
            }
        }

        // Delete existing developers
        private void DeleteExistingDevelopers()
        {
           ViewAllDevelopers();
            Console.WriteLine("\nEnter the ID number of the developer you would like to remove:");

            int input = int.Parse(Console.ReadLine());

            bool wasDeleted = _developerRepo.RemoveDeveloperFromList(input);

            if (wasDeleted)
            {
                Console.WriteLine("The developer was succesfully deleted.");
            }
            else
            {
                Console.WriteLine("The developer could not be deleted.");
            }

        }

     //Seed Method for Developers
     private void SeedDeveloperList()
        {
            Developer DevOne = new Developer("Developer One", 01, true, LanguageType.CSharp);
            Developer DevTwo = new Developer("Developer Two", 02, false, LanguageType.CSharp);
            Developer DevThree = new Developer("Developer Three", 03, true, LanguageType.CSharp);

            _developerRepo.AddDeveloperToList(DevOne);
            _developerRepo.AddDeveloperToList(DevTwo);
            _developerRepo.AddDeveloperToList(DevThree);
            
        }
    }
}
