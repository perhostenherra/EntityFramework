using PersonDBApp.Models;
using PersonDBApp.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonDBApp.Views
{
    class PersonView : IPersonView
    {
        private readonly IPersonService _personService;
        public PersonView()
        {
            _personService = new PersonService();
        }
        public void CreatePerson()
        {   //Kysy muutkin kentät
            Person newPerson = new Person();

            Console.Write("Syötä henkilön etunimi: ");
            newPerson.FirstName = Console.ReadLine();

            Console.Write("Syötä henkilön sukunimi: ");
            newPerson.LastName = Console.ReadLine();

            Console.Write("Syötä henkilön kaupunki: ");
            newPerson.City = Console.ReadLine();

            Console.Write("Syötä henkilön sukupuoli(Female/Male): ");
            newPerson.Sex = Console.ReadLine();

            Console.Write("Syötä henkilön syntymäaika: ");
            newPerson.DateOfBirth = Convert.ToDateTime(Console.ReadLine());

            Console.Write("Syötä henkilön pituus: ");
            newPerson.Height = Convert.ToInt32(Console.ReadLine());

            Console.Write("Syötä henkilön silmien väri: ");
            newPerson.EyeColor = Console.ReadLine();

            Console.Write("Syötä henkilön kengän numero: ");
            newPerson.ShoeSize = Convert.ToInt32(Console.ReadLine());

           newPerson = _personService.Create(newPerson);
            if (newPerson != null)
            {

                Console.WriteLine("Henkilön lisääminen onnistui");
            }
            else
            {
                Console.WriteLine("Henkilön lisääminen epäonnistui");
            }
        }

        public void DeletePerson()
        {
            Console.Write("Syötä henkilön Id:");
            long id = Convert.ToInt64(Console.ReadLine());
            var person = _personService.Read(id);
            PrintPerson(person);
            _personService.Delete(id);
        }

        public void PrintAllPeople()
        {
            var people = _personService.Read();
            PrintPeople(people);
        }

        public void PrintByCity()
        {
            Console.Write("Syötä kaupungin nimi:");
            string city = Console.ReadLine();
            var people = _personService.Read(city);
            PrintPeople(people);
             
        }

        public void PrintSinglePerson()
        {
            Console.Write("Syötä henkilön Id:");
            long id = Convert.ToInt64(Console.ReadLine());
            var person = _personService.Read(id);
            PrintPerson(person);
        }

        public void UpdatePerson()
        {
            Console.Write("Syötä henkilön Id:");
            long id = Convert.ToInt64(Console.ReadLine());
            var person = _personService.Read(id);
            PrintPerson(person);

            //Kysytään kaikki uudet arvot
            Console.Write("Anna henkilön uusi etunimi: ");
            person.FirstName = Console.ReadLine();

            Console.Write("Anna henkilön uusi sukunimi: ");
            person.LastName = Console.ReadLine();

            Console.WriteLine("Anna henkilön uusi kaupunki: ");
            person.City = Console.ReadLine();

            Console.Write("Anna henkilön uusi sukupuoli(female/male): ");
            person.Sex = Console.ReadLine();

            Console.Write("Anna henkilön uusi pituus: ");
            person.Height = Convert.ToInt32(Console.ReadLine());

            Console.Write("Anna henkilön uusi kengännumero: ");
            person.ShoeSize = Convert.ToInt32(Console.ReadLine());

            _personService.Update(id, person);

        }

        private void PrintPeople(List<Person> people)
        {
            Console.WriteLine("Id\t Etunimi \t Sukunimi \t Sukupuoli \t Kaupunki");
            foreach (var p in people)
            {
                PrintPerson(p);
            }
        }

        private void PrintPerson(Person p)
        {
            Console.WriteLine($"{p.Id}\t{p.FirstName}\t {p.LastName}\t {p.Sex} \t  {p.City} ");
        }
    }
}
