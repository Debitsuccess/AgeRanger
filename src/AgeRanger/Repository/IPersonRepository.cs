﻿using System;
using System.Collections.Generic;
using AgeRanger.Models;
using System.Linq.Expressions;
using System.Linq;

namespace AgeRanger.Repository
{
    public interface IPersonRepository
    {
        void Add(Person item);
        IEnumerable<PersonDto> GetAll();
        IEnumerable<PersonDto> FindBy(Expression<Func<Person, bool>> predicate);
        IEnumerable<PersonDto> FindById(int id);
        IEnumerable<PersonDto> FindByValue(string value);
        void Remove(PersonDto key);
        void Update(PersonDto item);
        Person MapDtoToPerson(PersonDto personDto);
        IEnumerable<PersonDto> MapPersonToDto(IQueryable<Person> selected);
    }
}
