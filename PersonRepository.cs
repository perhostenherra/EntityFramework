using PersonDBApp.Data;
using PersonDBApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PersonDBApp.Repositories
{
    class PersonRepository : IPersonRepository
    {
        private readonly PersonTestDBContext _context;

        public PersonRepository()
        {
            _context = new PersonTestDBContext();
        }
        public Person CreatePerson(Person person)
        {
            try
            {
                _context.People.Add(person);
                _context.SaveChanges();
                return person;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public void DeletePerson(Person person)
        {   
            
            try
            {
                _context.People.Remove(person);
                _context.SaveChanges();
                Console.WriteLine("Henkilön poistaminen onnistui");
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Henkilön poistaminen ei onnistunut" +ex.Message);
                
            }
        }


        public List<Person> Read()
        {
            var people = _context.People.ToList();
            return people;
        }


        public Person Read(long id)
        {
            var person = _context.People.Find(id);
            return person;
        }

        public List<Person> Read(string city)
        {
            var people = _context.People.Where(p=> p.City == city).ToList();
            return people;
        }



        public Person UpdatePerson(Person person)
        {   
            try
            {
                _context.People.Update(person);
                _context.SaveChanges();
                return person;
            }
            catch(Exception ex)
            {
                Console.WriteLine("Päivittäminen ei onnistunut" + ex.Message);
                return null;
            }
        }
    }
}
