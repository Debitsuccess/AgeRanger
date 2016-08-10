using AgeRanger.Models;
using System;
using System.Collections.Generic;

namespace AgeRanger.Services
{
    public interface IAgeRangerService
    {
        List<Person> GetAllPeople();
        List<Person> SearchPersonByFirstName(string firstName);
        List<Person> SearchPersonByLastName(string lastName);
        Person GetPersonById(int id);
        void AddPerson(Person person);
        Person UpdatePerson(int id, Person person);
        void DeletePerson(int id);
    }
}