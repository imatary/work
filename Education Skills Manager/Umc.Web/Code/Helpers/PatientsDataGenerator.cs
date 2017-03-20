using System;
using System.Collections;
using System.Linq;

namespace Umc.Web {
    public static class PatientsDataGenerator {
        static IEnumerable inMemoryData;
        static readonly string[] clinics = new string[] {
            "St. Mary Hospital",
            "Florida General Hospital",
            "Johnson Neuropsychiatric Hospital",
            "Orlando Clinic",
            "Redmond Medical Center",
            "Dobson Institute for Rehabilitation",
            "Cofir Clinic",
            "St. Petersburg University Hospital",
            "University of Jenkintown Medical Center"
        };

        static readonly string[] firstNames = new string[] {
            "Jacob", "Michael", "Joshua", "Matthew", "Daniel",
			"Christopher", "Andrew", "Ethan", "Joseph", "William",
			"Anthony", "David", "Alexander", "Nicholas", "Ryan",
			"Tyler", "James", "John", "Jonathan", "Noah", "Brandon",
			"Christian", "Dylan", "Samuel", "Benjamin", "Zachary",
			"Nathan", "Logan", "Justin", "Gabriel", "Jose", "Austin",
			"Kevin", "Elijah", "Caleb", "Robert", "Thomas", "Jordan",
			"Cameron", "Jack", "Hunter", "Jackson", "Angel", "Isaiah",
			"Evan", "Isaac", "Mason", "Luke", "Jason", "Gavin", "Jayden",
			"Aaron", "Connor", "Aiden", "Aidan", "Kyle", "Juan", "Charles",
			"Luis", "Adam", "Lucas", "Brian", "Eric", "Adrian",
			"Nathaniel", "Sean", "Alex", "Carlos", "Bryan", "Ian", "Owen",
			"Landon", "Julian", "Chase", "Cole", "Diego", "Jeremiah",
			"Steven", "Sebastian", "Xavier", "Timothy", "Carter",
			"Wyatt", "Brayden", "Blake", "Hayden", "Devin", "Cody",
			"Richard", "Seth", "Dominic", "Jaden", "Antonio", "Miguel",
			"Liam", "Patrick", "Carson", "Jesse", "Tristan"
		};

        static readonly string[] lastNames = new string[] {
			"Smith", "Johnson", "Williams", "Jones", "Brown", "Davis",
			"Miller", "Wilson", "Moore", "Taylor", "Anderson",
			"Thomas", "Jackson", "White", "Harris", "Martin",
			"Thompson", "Garcia", "Martinez", "Robinson", "Clark",
			"Rodriguez", "Lewis", "Lee", "Walker", "Hall", "Allen",
			"Young", "Hernandez", "King", "Wright", "Lopez",
			"Hill", "Scott", "Green", "Adams", "Baker", "Gonzalez",
			"Nelson", "Carter", "Mitchell", "Perez", "Roberts",
			"Turner", "Phillips", "Campbell", "Parker", "Evans",
			"Edwards", "Collins", "Stewart", "Sanchez", "Morris",
			"Rogers", "Reed", "Cook", "Morgan", "Bell", "Murphy",
			"Bailey", "Rivera", "Cooper", "Richardson", "Cox",
			"Howard", "Ward", "Torres", "Peterson", "Gray",
			"Ramirez", "James", "Watson", "Brooks", "Kelly",
			"Sanders", "Price", "Bennett", "Wood", "Barnes",
			"Ross", "Henderson", "Coleman", "Jenkins", "Perry",
			"Powell", "Long", "Patterson", "Hughes", "Flores",
			"Washington", "Butler", "Simmons", "Foster", "Gonzales",
			"Bryant", "Alexander", "Russell", "Griffin", "Diaz", "Hayes"
		};

        static readonly string[] doctorNames = new string[] {
            "Peter Dolan", "Ryan Fischer", "Richard Fisher", 
		    "Tom Hamlett", "Mark Hamilton", "Steve Lee", "Jimmy Lewis", "Jeffrey W McClain", 
		    "Andrew Miller", "Dave Murrel", "Bert Parkins", "Mike Roller", "Ray Shipman", 
		    "Paul Bailey", "Brad Barnes", "Carl Lucas", "Jerry Campbell"
        };

        public static IEnumerable GetInMemoryData() {
            if(inMemoryData == null)
                inMemoryData = GenerateInMemory(3000);
            return inMemoryData;
        }

        static IList GenerateInMemory(int count) {
            var firstNameField = new DatabaseGenerator.FieldData("FirstName", firstNames);
            var lastNameField = new DatabaseGenerator.FieldData("LastName", lastNames);
            var doctorField = new DatabaseGenerator.FieldData("Doctor", doctorNames);
            var clinicField = new DatabaseGenerator.FieldData("Clinic", clinics);
            var visitDateField = new DatabaseGenerator.FieldData("VisitDate", GenerateVisitDate);

            return Enumerable.Range(0, count).Select(i => new {
                ID = i,
                Patient = string.Format("{0} {1}", firstNameField.GenerateValue().ToString(), lastNameField.GenerateValue().ToString()),
                Doctor = doctorField.GenerateValue().ToString(),
                Clinic = clinicField.GenerateValue().ToString(),
                VisitDate = Convert.ToDateTime(visitDateField.GenerateValue()),
            }).ToList();
        }

        static object GenerateVisitDate(Random rnd) {
            return DateTime.Now.Date.Subtract(TimeSpan.FromDays(rnd.Next(-365, 365)));
        }
    }
}
