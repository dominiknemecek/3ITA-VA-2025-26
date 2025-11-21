namespace studentske_vysledky
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Vytvoření studentů + přidání jejich známek
            // Při vytvoření objektu Student se volá konstruktor Student("Jméno", "Příjmení")
            Student student1 = new Student("Jan", "Novak");
            student1.AddGrade(3);
            student1.AddGrade(2);
            student1.AddGrade(4);

            Student student2 = new Student("Petra", "Svobodova");
            student2.AddGrade(1);
            student2.AddGrade(3);

            Student student3 = new Student("Lukas", "Kral");
            student3.AddGrade(5);

            // Vytvoření objektu Group – obsahuje seznam studentů
            Group group = new Group();

            // Přidání studentů do skupiny (List<Student>)
            group.AddStudent(student1);
            group.AddStudent(student2);
            group.AddStudent(student3);

            // Výpis všech studentů a jejich známek přes metodu Group.PrintAllStudents()
            Console.WriteLine("Všichni studenti ve skupině:");
            group.PrintAllStudents();

            // Ukázka hledání studenta podle jména
            Console.WriteLine("\nHledání studenta podle jména:");
            group.FindStudentByFirstName("Petra");
        }
    }
}
