using PersonDBApp.Models;
using PersonDBApp.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonDBApp.Services
{
    class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;


        public PersonService()
        {
            _personRepository = new PersonRepository();
        }
        public Person Create(Person person)
        {
            var createdPerson = _personRepository.CreatePerson(person);
            return createdPerson;
        }

        public void Delete(long id)
        {   
            var dbPerson = _personRepository.Read(id);
            if (dbPerson != null)
            {
                _personRepository.DeletePerson(dbPerson);
                Console.WriteLine("Henkilön poisto onnistui");
            }
            else
            {
                Console.WriteLine("Henkilöä ei löytynyt - poistaminen ei onnistu");
               
            }
        }

        public List<Person> Read()
        {
            
            var people = _personRepository.Read();
                return people;
        }

        public Person Read(long id)
        {
            var person = _personRepository.Read(id);
            return person;
        }

        public List<Person> Read(string city)
        {
            var people = _personRepository.Read(city);
            return people;
        }



        public Person Update(long id, Person person)
        {
            var dbPerson = _personRepository.Read(id);
                if (dbPerson !=null)
            {
                person.Id = id;
                var updatedPerson =_personRepository.UpdatePerson(person);
                return updatedPerson;
            }
                else
            {
                Console.WriteLine("Henkilöä ei ole olemassa - päivitys ei onnistu");
                return null;
            }
        }
    }
}
