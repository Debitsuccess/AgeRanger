using System;
using System.Collections.Generic;
using System.Linq;

using WebApi.Repositories;

using ContractPerson = WebApi.Contracts.Person;
using DomainPerson = WebApi.Domain.Person;

namespace WebApi.Services
{
// ReSharper disable once UnusedMember.Global
	public class PersonService : IPersonService
	{
		private readonly IWritableRepository<int, DomainPerson> personRepository;
		private readonly IAgeGroupService ageGroupService;


		public PersonService(
			IWritableRepository<int, DomainPerson> personRepository,
			IAgeGroupService ageGroupService
		)
		{
			this.personRepository = personRepository;
			this.ageGroupService = ageGroupService;
		}


		public IEnumerable<ContractPerson> GetAllPeople()
		{
			return personRepository.GetAll()
				.Select(ConvertDomainToContract);
		}

		public ContractPerson GetPerson(int id)
		{
			return ConvertDomainToContract(personRepository.Get(id));
		}

		public void SaveNewPerson(ContractPerson person)
		{
			if (person == null)
			{
				throw new ArgumentNullException(nameof(person));
			}


			person.Id = -1;
			person.Version = 0;
			personRepository.Put(ConvertContractToDomain(person));
		}

		public void UpdatePerson(ContractPerson person)
		{
			if (person == null)
			{
				throw new ArgumentNullException(nameof(person));
			}


			personRepository.Put(ConvertContractToDomain(person));
		}

		public void RemovePerson(int id)
		{
			personRepository.Delete(id);
		}


		private ContractPerson ConvertDomainToContract(DomainPerson person) => (person == null)
			? null
			: new ContractPerson
			{
				Id = person.Id,
				Created = person.Created,
				Modified = person.Modified,
				Version = person.Version,

				FirstName = person.FirstName,
				LastName = person.LastName,

				Age = person.Age,
				AgeGroup = ageGroupService.GetAgeGroup(person.Age)?.Description
			};

		private static DomainPerson ConvertContractToDomain(ContractPerson person) => (person == null)
			? null
			: new DomainPerson
			{
				Id = person.Id,
				Version = person.Version,

				FirstName = person.FirstName,
				LastName = person.LastName,

				Age = person.Age
			};
	}
}
