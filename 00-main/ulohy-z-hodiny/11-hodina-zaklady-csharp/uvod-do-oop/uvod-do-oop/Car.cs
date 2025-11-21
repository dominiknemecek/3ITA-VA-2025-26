using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uvod_do_oop
{
    // Třída Car reprezentuje objekt „auto“ s různými vlastnostmi (barva, značka, rok, VIN...)
    internal class Car
    {
        // ==================== POLE (FIELDS) ====================

        // Unikátní VIN kód auta – vygeneruje se automaticky při vytvoření objektu.
        // Guid.NewGuid() vytvoří jedinečný identifikátor (GUID = Globally Unique Identifier),
        // což je 128bitové číslo, které se prakticky nikdy neopakuje.
        // Tento údaj je pouze ke čtení (read-only), proto zde není žádný setter.
        private string vinCode = Guid.NewGuid().ToString();

        // Bezpečnostní kód – write-only údaj (lze nastavit, ale nelze přečíst)
        private int securityCode;

        // ==================== KONSTRUKTOR ====================

        // Konstruktor – metoda, která se zavolá automaticky při vytvoření objektu.
        // Nastavuje počáteční hodnoty pro barvu, značku a rok auta.
        public Car(string carColor, string carBrand, int carYear)
        {
            CarColor = carColor;   // přiřadí barvu
            CarBrand = carBrand;   // přiřadí značku
            CarYear = carYear;     // přiřadí rok výroby (přes vlastnost s kontrolou)
        }

        // ==================== VLASTNOSTI (PROPERTIES) ====================

        // VIN – vlastnost pouze pro čtení (read-only)
        // Lze ji vypsat, ale nelze změnit – žádný setter.
        public string Vin
        {
            get { return vinCode; }
        }

        // SecurityCode – vlastnost pouze pro zápis (write-only)
        // Hodnotu lze nastavit, ale nelze přečíst (chybí get blok).
        public int SecurityCode
        {
            set { securityCode = value; }
        }

        // Automatické vlastnosti (auto-properties)
        // Kompilátor si sám vytvoří privátní proměnnou na pozadí.
        public string CarColor { get; set; }  // barva auta
        public string CarBrand { get; set; }  // značka auta

        // Rok výroby – vlastnost s validací (kontrolou vstupu)
        private int carYear;
        public int CarYear
        {
            get { return carYear; }
            set
            {
                int currentYear = DateTime.Now.Year; // aktuální rok z systému

                // Ověření, že rok dává smysl – auta se vyrábí až od 1886
                if (value < 1886 || value > currentYear)
                    throw new ArgumentException($"Rok musí být v rozmezí 1886 až {currentYear}.");

                carYear = value;
            }
        }

        // ==================== METODY ====================

        // Metoda vypíše informace o autě
        public void ShowDetails()
        {
            Console.WriteLine("Značka auta: " + CarBrand);
            Console.WriteLine("Barva auta: " + CarColor);
            Console.WriteLine("VIN: " + vinCode);
        }

        // Metoda, která simuluje startování motoru
        public void StartEngine()
        {
            Console.WriteLine("Motor auta byl spuštěn.");
        }
    }
}
