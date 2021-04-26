using PersonDBApp.Data;
using PersonDBApp.Views;
using System;
using System.Linq;

namespace PersonDBApp
{
    class Program
    {

        static private readonly IPersonView _personView = new PersonView();
        static void Main(string[] args)
        {
            string choice = null;

            do
            {
                choice = UserInterface();

                switch(choice.ToUpper())
                {
                    case "C":
                        _personView.CreatePerson();
                        break;
                    case "R":
                        _personView.PrintAllPeople();
                        break;
                    case "U":
                        _personView.UpdatePerson();
                        break;
                    case "D":
                        _personView.DeletePerson();
                        break;
                    case "R1":
                        _personView.PrintSinglePerson();
                        break;
                    case "R2":
                        _personView.PrintByCity();
                        break;
                        
                }
                Console.WriteLine("Paina enteriä jatkaaksesi....");
                Console.ReadLine();
            }
            while (choice.ToUpper() != "X");
           
        }

        static string UserInterface()
        {
            Console.WriteLine("Tietokannan käsittelyesimerkki");
            Console.WriteLine("[C] - Lisää uusi henkilö");
            Console.WriteLine("[R] - Tulosta kaikki henkilöt");
            Console.WriteLine("[U] - Päivitä henkilön tietoja");
            Console.WriteLine("[D] - Poista henkilön tiedot");
            Console.WriteLine("[R1] - Tulosta yksi henkilö");
            Console.WriteLine("[R2] - Tulosta kaikki henkilöt kaupungin mukaan");
            Console.WriteLine("[X] - Lopeta ohjelman suoritus");

            return Console.ReadLine();

        }
        
    }
}
