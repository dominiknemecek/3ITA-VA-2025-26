namespace studentske_vysledky
{
    internal class Group
    {
        // Soukromý seznam všech studentů ve skupině
        // Zapouzdření → nikdo nemůže měnit seznam přímo zvenku
        private List<Student> students = new();

        // Metoda pro přidání studenta do skupiny
        public void AddStudent(Student student)
        {
            students.Add(student);   // uloží objekt Student do Listu
        }

        // Metoda pro výpis všech studentů + jejich známek + průměru
        public void PrintAllStudents()
        {
            foreach (var student in students)
            {
                student.PrintGrades();                        // výpis známek studenta
                Console.WriteLine("Průměr: " + student.CalculateAverage());
                Console.WriteLine("---------------------------------------");
            }
        }

        // Metoda pro nalezení studenta podle jména (case insensitive)
        public void FindStudentByFirstName(string firstName)
        {
            foreach (var student in students)
            {
                // Porovnání ignorující velká/malá písmena
                if (student.FirstName.Equals(firstName, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Student nalezen:");
                    student.PrintGrades();
                    Console.WriteLine("Průměr: " + student.CalculateAverage());
                    return; // okamžitě končí, nemusíme hledat dál
                }
            }

            // Kód sem dojde pouze pokud se student nenašel
            Console.WriteLine("Student s tímto jménem nebyl nalezen!");
        }
    }
}
