using Microsoft.VisualStudio.TestTools.UnitTesting;
using AgeRanger.Models;
using System.Collections.Generic;

namespace AgeRanger.Tests
{
    [TestClass]
    public class AgeRangerTest
    {
        private List<AgeGroup> TheGroups = new List<AgeGroup>
        {
            new AgeGroup { MinAge = null, MaxAge = 2, Description = "Toddler" },
            new AgeGroup { MinAge = 2, MaxAge = 14, Description = "Child" },
            new AgeGroup { MinAge = 14, MaxAge = 20, Description = "Teenager" },
            new AgeGroup { MinAge = 20, MaxAge = 25, Description = "Early twenties" },
            new AgeGroup { MinAge = 25, MaxAge = 30, Description = "Almost thirty" },
            new AgeGroup { MinAge = 30, MaxAge = 50, Description = "Very adult" },
            new AgeGroup { MinAge = 50, MaxAge = 70, Description = "Kinda old" },
            new AgeGroup { MinAge = 70, MaxAge = 99, Description = "Old" },
            new AgeGroup { MinAge = 99, MaxAge = 110, Description = "Very old" },
            new AgeGroup { MinAge = 110, MaxAge = 199, Description = "Crazy ancient" },
            new AgeGroup { MinAge = 199, MaxAge = 4999, Description = "Vampire" },
            new AgeGroup { MinAge = 4999, MaxAge = null, Description = "Kauri tree" }
        };

        [TestMethod]
        public void GetAgeDescription_InvalidAge()
        {
            var ranger = new Models.AgeRanger(TheGroups);
            var description = ranger.GetAgeDescription(-1);
            Assert.AreEqual("unknown", description, "should be unknown");
        }

        [TestMethod]
        public void GetAgeDescription_Toddler()
        {
            var ranger = new Models.AgeRanger(TheGroups);
            var description = ranger.GetAgeDescription(0);
            Assert.AreEqual("Toddler", description, "should be Toddler");
            description = ranger.GetAgeDescription(1);
            Assert.AreEqual("Toddler", description, "should be Toddler");
        }

        [TestMethod]
        public void GetAgeDescription_Child()
        {
            var ranger = new Models.AgeRanger(TheGroups);
            var description = ranger.GetAgeDescription(2);
            Assert.AreEqual("Child", description, "should be Child");
            description = ranger.GetAgeDescription(13);
            Assert.AreEqual("Child", description, "should be Child");
        }

        [TestMethod]
        public void GetAgeDescription_Teenager()
        {
            var ranger = new Models.AgeRanger(TheGroups);
            var description = ranger.GetAgeDescription(14);
            Assert.AreEqual("Teenager", description, "should be Teenager");
            description = ranger.GetAgeDescription(19);
            Assert.AreEqual("Teenager", description, "should be Teenager");
        }

        [TestMethod]
        public void GetAgeDescription_EarlyTwenties()
        {
            var ranger = new Models.AgeRanger(TheGroups);
            var description = ranger.GetAgeDescription(20);
            Assert.AreEqual("Early twenties", description, "should be Early twenties");
            description = ranger.GetAgeDescription(24);
            Assert.AreEqual("Early twenties", description, "should be Early twenties");
        }

        [TestMethod]
        public void GetAgeDescription_AlmostThirty()
        {
            var ranger = new Models.AgeRanger(TheGroups);
            var description = ranger.GetAgeDescription(25);
            Assert.AreEqual("Almost thirty", description, "should be Almost thirty");
            description = ranger.GetAgeDescription(29);
            Assert.AreEqual("Almost thirty", description, "should be Almost thirty");
        }

        [TestMethod]
        public void GetAgeDescription_VeryAdult()
        {
            var ranger = new Models.AgeRanger(TheGroups);
            var description = ranger.GetAgeDescription(30);
            Assert.AreEqual("Very adult", description, "should be Very adult");
            description = ranger.GetAgeDescription(49);
            Assert.AreEqual("Very adult", description, "should be Very adult");
        }
        [TestMethod]
        public void GetAgeDescription_KindaOld()
        {
            var ranger = new Models.AgeRanger(TheGroups);
            var description = ranger.GetAgeDescription(50);
            Assert.AreEqual("Kinda old", description, "should be Kinda old");
            description = ranger.GetAgeDescription(69);
            Assert.AreEqual("Kinda old", description, "should be Kinda old");
        }

        [TestMethod]
        public void GetAgeDescription_Old()
        {
            var ranger = new Models.AgeRanger(TheGroups);
            var description = ranger.GetAgeDescription(70);
            Assert.AreEqual("Old", description, "should be Old");
            description = ranger.GetAgeDescription(98);
            Assert.AreEqual("Old", description, "should be Old");
        }

        [TestMethod]
        public void GetAgeDescription_VeryOld()
        {
            var ranger = new Models.AgeRanger(TheGroups);
            var description = ranger.GetAgeDescription(99);
            Assert.AreEqual("Very old", description, "should be Very old");
            description = ranger.GetAgeDescription(109);
            Assert.AreEqual("Very old", description, "should be Very old");
        }
        [TestMethod]
        public void GetAgeDescription_CrazyAncient()
        {
            var ranger = new Models.AgeRanger(TheGroups);
            var description = ranger.GetAgeDescription(110);
            Assert.AreEqual("Crazy ancient", description, "should be Crazy ancient");
            description = ranger.GetAgeDescription(198);
            Assert.AreEqual("Crazy ancient", description, "should be Crazy ancient");
        }

        [TestMethod]
        public void GetAgeDescription_Vampire()
        {
            var ranger = new Models.AgeRanger(TheGroups);
            var description = ranger.GetAgeDescription(199);
            Assert.AreEqual("Vampire", description, "should be Vampire");
            description = ranger.GetAgeDescription(4998);
            Assert.AreEqual("Vampire", description, "should be Vampire");
        }

        [TestMethod]
        public void GetAgeDescription_KauriTree()
        {
            var ranger = new Models.AgeRanger(TheGroups);
            var description = ranger.GetAgeDescription(4999);
            Assert.AreEqual("Kauri tree", description, "should be Kauri tree");
            description = ranger.GetAgeDescription(2147483647);
            Assert.AreEqual("Kauri tree", description, "should be Kauri tree");
        }
    }
}
