namespace studentske_vysledky
{
    internal class Student
    {
        // ===================== FIELDS (soukromá data) =====================

        private string firstName;          // křestní jméno
        private string lastName;           // příjmení
        private List<int> grades = new();  // seznam známek 1–5 pro daného studenta

        // ===================== PROPERTIES =====================

        // Vlastnost pro jméno studenta
        public string FirstName
        {
            get { return firstName; }
            set
            {
                // základní validace (jméno nesmí být prázdné)
                if (!string.IsNullOrEmpty(value))
                    firstName = value;
                else
                    Console.WriteLine("Jméno nesmí být prázdné!");
            }
        }

        // Vlastnost pro příjmení studenta
        public string LastName
        {
            get { return lastName; }
            set
            {
                // základní validace
                if (!string.IsNullOrEmpty(value))
                    lastName = value;
                else
                    Console.WriteLine("Příjmení nesmí být prázdné!");
            }
        }

        // ===================== KONSTRUKTOR =====================

        // Konstruktor – nastavuje počáteční jméno a příjmení
        public Student(string firstName, string lastName)
        {
            FirstName = firstName;     // validace proběhne ve vlastnosti
            LastName = lastName;
        }

        // ===================== METODY =====================

        // Přidání známky studentovi (kontrola, zda je v rozsahu 1–5)
        public void AddGrade(int grade)
        {
            if (grade >= 1 && grade <= 5)
            {
                grades.Add(grade);
            }
            else
            {
                Console.WriteLine("Chyba: Známka musí být v rozmezí 1–5!");
            }
        }

        // Výpis všech známek daného studenta
        public void PrintGrades()
        {
            if (grades.Count == 0)
            {
                Console.WriteLine("Student nemá žádné známky!");
            }
            else
            {
                Console.WriteLine(
                    "Známky studenta {0} {1}: {2}",
                    firstName,
                    lastName,
                    string.Join(", ", grades)
                );
            }
        }

        // Výpočet průměrné známky → součet / počet známek
        public double CalculateAverage()
        {
            if (grades.Count == 0)
            {
                Console.WriteLine("Student nemá žádné známky – nelze spočítat průměr.");
                return 0;
            }

            double sum = 0;

            // Sečtení všech známek
            foreach (int grade in grades)
            {
                sum += grade;
            }

            // Výpočet aritmetického průměru
            return sum / grades.Count;
        }
    }
}
