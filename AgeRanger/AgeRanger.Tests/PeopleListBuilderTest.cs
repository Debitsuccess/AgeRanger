using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AgeRanger.Models;
using System.Collections.Generic;

namespace AgeRanger.Tests
{
    [TestClass]
    public class PeopleListBuilderTest
    {
        [TestMethod]
        public void Build_UnsortedList()
        {
            var ranger = new TestAgeRanger();
            var builder = new PeopleListBuilder(ranger);
            var list = GetList();
            var people = builder.Build(list, 0, 20, 0, "desc", string.Empty);
            Assert.AreEqual(20, people.Count, "list contains 20 items");
            Assert.AreEqual("Scottie", people[0].FirstName, "should sort by clumn 0");
        }

        [TestMethod]
        public void Build_SortsByNameAscending()
        {
            var ranger = new TestAgeRanger();
            var builder = new PeopleListBuilder(ranger);
            var list = GetList();
            var people = builder.Build(list, 0, 20, 1, "asc", string.Empty);
            Assert.AreEqual(20, people.Count, "list contains 20 items");
            Assert.AreEqual("Alec", people[0].FirstName, "should sort by column 0");
        }

        [TestMethod]
        public void Build_SortsByNameDescending()
        {
            var ranger = new TestAgeRanger();
            var builder = new PeopleListBuilder(ranger);
            var list = GetList();
            var people = builder.Build(list, 0, 20, 1, "desc", string.Empty);
            Assert.AreEqual(20, people.Count, "list contains 20 items");
            Assert.AreEqual("Temple", people[0].FirstName, "should sort by name");
        }

        [TestMethod]
        public void Build_SortsByNameWithNulls()
        {
            var ranger = new TestAgeRanger();
            var builder = new PeopleListBuilder(ranger);
            var list = GetListWithItemsContainingNulls();
            var people = builder.Build(list, 0, 22, 1, "asc", string.Empty);
            Assert.AreEqual(22, people.Count, "list contains 22 items");
            Assert.AreEqual(101, people[0].Id, "should sort by name");
        }

        [TestMethod]
        public void Build_SortsByLastName()
        {
            var ranger = new TestAgeRanger();
            var builder = new PeopleListBuilder(ranger);
            var list = GetList();
            var people = builder.Build(list, 0, 20, 2, "asc", string.Empty);
            Assert.AreEqual(20, people.Count, "list contains 20 items");
            Assert.AreEqual("Bonds", people[0].LastName, "should sort by last name");
        }

        [TestMethod]
        public void Build_SortsByLastNameWithNulls()
        {
            var ranger = new TestAgeRanger();
            var builder = new PeopleListBuilder(ranger);
            var list = GetListWithItemsContainingNulls();
            var people = builder.Build(list, 0, 22, 2, "asc", string.Empty);
            Assert.AreEqual(22, people.Count, "list contains 22 items");
            Assert.AreEqual(100, people[0].Id, "should sort by last name");
        }

        [TestMethod]
        public void Build_SortsByAge()
        {
            var ranger = new TestAgeRanger();
            var builder = new PeopleListBuilder(ranger);
            var list = GetList();
            var people = builder.Build(list, 0, 20, 3, "desc", string.Empty);
            Assert.AreEqual(20, people.Count, "list contains 20 items");
            Assert.AreEqual("Jammie", people[0].FirstName, "should sort by age");
        }

        [TestMethod]
        public void Build_SortsByAgeRange()
        {
            var ranger = new TestAgeRanger();
            var builder = new PeopleListBuilder(ranger);
            var list = GetList();
            var people = builder.Build(list, 0, 20, 3, "asc", string.Empty);
            Assert.AreEqual(20, people.Count, "list contains 20 items");
            Assert.AreEqual("Lizzette", people[0].FirstName, "should sort by column 2");
        }


        // skips 5
        [TestMethod]
        public void Build_SkipsNRecords()
        {
            var ranger = new TestAgeRanger();
            var builder = new PeopleListBuilder(ranger);
            var list = GetList();
            var people = builder.Build(list, 5, 20, 0, "asc", string.Empty);
            Assert.AreEqual(15, people.Count, "list contains 15 items");
            Assert.AreEqual("Lola", people[0].FirstName, "should sort by column 2");
        }

        [TestMethod]
        public void Build_TakesNRecords()
        {
            var ranger = new TestAgeRanger();
            var builder = new PeopleListBuilder(ranger);
            var list = GetList();
            var people = builder.Build(list, 0, 10, 0, "asc", string.Empty);
            Assert.AreEqual(10, people.Count, "list contains 10 items");
            Assert.AreEqual("Scottie", people[0].FirstName, "should sort by column 2");
        }

        [TestMethod]
        public void Build_TakesAllRecords()
        {
            var ranger = new TestAgeRanger();
            var builder = new PeopleListBuilder(ranger);
            var list = GetList();
            var people = builder.Build(list, 0, -1, 0, "asc", string.Empty);
            Assert.AreEqual(20, people.Count, "list contains All items");
            Assert.AreEqual("Scottie", people[0].FirstName, "should sort by column 2");
        }

        [TestMethod]
        public void Build_SkipsAndTakesNRecords()
        {
            var ranger = new TestAgeRanger();
            var builder = new PeopleListBuilder(ranger);
            var list = GetList();
            var people = builder.Build(list, 10, 5, 0, "asc", string.Empty);
            Assert.AreEqual(5, people.Count, "list contains 5 items");
            Assert.AreEqual("Beth", people[0].FirstName, "should sort by column 2");
        }

        [TestMethod]
        public void Build_SearchByFirstAndLastName()
        {
            var ranger = new TestAgeRanger();
            var builder = new PeopleListBuilder(ranger);
            var list = GetList();
            var people = builder.Build(list, 0, 20, 0, "asc", "AN");
            Assert.AreEqual(4, people.Count, "list contains 4 items");
            Assert.AreEqual(7, people[0].Id, "should filter output");
        }

        [TestMethod]
        public void Build_SearchByFirstAndLastNameWithNulls()
        {
            var ranger = new TestAgeRanger();
            var builder = new PeopleListBuilder(ranger);
            var list = GetListWithItemsContainingNulls();
            var people = builder.Build(list, 0, 20, 0, "asc", "AN");
            Assert.AreEqual(5, people.Count, "list contains 5 items");
            Assert.AreEqual(7, people[0].Id, "should filter output");
        }

        private static List<Person> GetList()
        {
            var list = new List<Person>() {
                new Person { FirstName="Scottie", LastName= "Graber", Age = 10, Id = 1 },
                new Person { FirstName="Nicki", LastName= "Groen" ,Age = 21, Id = 2 },
                new Person { FirstName="Karine", LastName= "Taub" ,Age = 120, Id = 3 },
                new Person { FirstName="Lucille", LastName= "Venturi" ,Age = 45, Id = 4 },
                new Person { FirstName="Marg", LastName= "Sartor" ,Age = 64, Id = 5 },
                new Person { FirstName="Lola", LastName= "Helle" ,Age = 31, Id = 6 },
                new Person { FirstName="Ana", LastName= "Wilkinson" ,Age = 22, Id = 7 },
                new Person { FirstName="Nona", LastName= "Fesler" ,Age = 15, Id = 8 },
                new Person { FirstName="Elden", LastName= "Lubbers" ,Age = 11, Id = 9 },
                new Person { FirstName="Jammie", LastName= "Franchi" ,Age = 5023, Id = 10 },
                new Person { FirstName="Beth", LastName= "Leto" ,Age = 220, Id = 11 },
                new Person { FirstName="Nichelle", LastName= "Hendry" ,Age = 16, Id = 12 },
                new Person { FirstName="Shari", LastName= "Bonds" ,Age = 43, Id = 13 },
                new Person { FirstName="Catina", LastName= "Muff" ,Age = 81, Id = 14 },
                new Person { FirstName="Sonja", LastName= "Reagle" ,Age = 12, Id = 15 },
                new Person { FirstName="Lizzette", LastName= "Chenail" ,Age = 9, Id = 16 },
                new Person { FirstName="Alec", LastName= "Mcneill" ,Age = 20, Id = 17 },
                new Person { FirstName="Temple", LastName= "Sisler" ,Age = 23, Id = 18 },
                new Person { FirstName="Sanora", LastName= "Bueno" ,Age = 55, Id = 19 },
                new Person { FirstName="Maryanna", LastName= "Mcquay" ,Age = 99, Id = 20 }
            };
            return list;
        }

        private static List<Person> GetListWithItemsContainingNulls()
        {
            var list = GetList();
            list.Add(new Person { FirstName = "Laurena", LastName = null, Age = 49, Id = 100 });
            list.Add(new Person { FirstName = null, LastName = "Landon", Age = 38, Id = 101 });
            return list;
        }
    }

    /// <summary>
    /// Use Fake rather than Mock as simple and some data required to test sorting
    /// </summary>
    class TestAgeRanger : IAgeRanger
    {
        public string GetAgeDescription(int age)
        {
            return (age/10).ToString();
        }
    }
}
