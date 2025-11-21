namespace uvod_do_oop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Vytvoření prvního objektu typu Car
            Car firstCar = new Car("Červená", "Ferrari", 2002);
            Console.WriteLine("=== PRVNÍ AUTO ===");
            firstCar.ShowDetails();                // vypíše info o autě
            Console.WriteLine("VIN: " + firstCar.Vin);  // get-only vlastnost
            firstCar.StartEngine();               // zavolání metody

            Console.WriteLine();

            // Vytvoření druhého objektu
            Car secondCar = new Car("Zelená", "Audi", 2010);
            Console.WriteLine("=== DRUHÉ AUTO ===");
            secondCar.ShowDetails();
            Console.WriteLine("VIN: " + secondCar.Vin);
            secondCar.StartEngine();

            Console.WriteLine();
            Console.WriteLine("Měním barvu druhého auta na 'Modrá'...");
            secondCar.CarColor = "Modrá";         // změna vlastnosti (má setter)
            secondCar.ShowDetails();

            Console.WriteLine();
            Console.WriteLine("Nastavuji bezpečnostní kód (write-only)...");
            secondCar.SecurityCode = 1234;        // pouze set – nelze vypsat

            Console.WriteLine();

            // Ukázka validace roku – vyvolá výjimku
            Console.WriteLine("Pokus o nastavení neplatného roku:");
            try
            {
                secondCar.CarYear = 1700;  // neplatný rok -> spustí se exception
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Chyba při nastavování roku: " + ex.Message);
            }

            Console.WriteLine();
            Console.WriteLine("Program pokračuje dál...");
        }
    }
}
