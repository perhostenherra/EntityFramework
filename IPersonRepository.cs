using PersonDBApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonDBApp.Repositories
{
    public interface IPersonRepository
    {
        //CRUD
        //Create, Read, Update, Delete

        Person CreatePerson(Person person);

        List <Person> Read();

        Person Read(long id);

        List<Person> Read(string city);

        Person UpdatePerson(Person person);

        void DeletePerson(Person person);

    }
}
