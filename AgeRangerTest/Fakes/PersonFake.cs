using AgeRanger.DTO;
using Infrastructure.Model;

namespace AgeRangerTest.Fakes
{
    public static class PersonFake
    {
        public static Person Person = new Person
        {
            Id = 1,
            FirstName = "Faisal",
            LastName = "Noor",
            Age = 30
        };

        public static Person CreatePerson = new Person
        {
            Id = 10,
            FirstName = "Faisal",
            LastName = "Noor",
            Age = 30
        };

        public static Person UpdatePerson = new Person
        {
            Id = 10,
            FirstName = "Faisal_Updated",
            LastName = "Noor_Updated",
            Age = 30
        };

        public static PersonViewModel PersonViewModel = new PersonViewModel
        {
            Id = 10,
            FirstName = "Faisal",
            LastName = "Noor",
            Age = 30
        };
    }
}
