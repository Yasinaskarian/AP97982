using Microsoft.VisualStudio.TestTools.UnitTesting;
using A8;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A8.Tests
{
    [TestClass()]
    public class A8Tests
    {
        [TestMethod()]
        public void HumanTest()
        {
            DateTime date1 = new DateTime(1999, 3, 1, 7, 0, 0);
            Human yasin = new Human("yasin", "askarian", date1, 188);
            Assert.AreEqual("yasin", yasin.FirstName);
            Assert.AreEqual("askarian", yasin.LastName);
            Assert.AreEqual(date1, yasin.BirthDate);
            Assert.AreEqual(188, yasin.Height);
            Assert.AreNotEqual(DateTime.Today, yasin.BirthDate);
            Assert.AreNotEqual("Mozhgan", yasin.FirstName);
        }
        [TestMethod()]
        public void Plus()
        {
            DateTime date1 = new DateTime(2008, 3, 1, 7, 0, 0);
            Human h1 = new Human("yasin", "askarian", date1, 188);
            Human h2 = new Human("ali", "askarian", DateTime.Today, 188);
            Human person = new Human("ChildFirstName", "ChildLastName", DateTime.Today, 30);
            Assert.AreEqual(person, (h1 + h2));
            Assert.AreNotEqual(h1, (h1 + h2));
        }
        [TestMethod()]
        public void EqualsTest()
        {
            DateTime date1 = new DateTime(2008, 3, 1, 7, 0, 0);
            DateTime date2 = new DateTime(2000, 3, 1, 7, 0, 0);
            Human h1 = new Human("ali", "askarian", DateTime.Today, 188);
            Human h2 = new Human("yasin", "askarian", date1, 188);
            Human h3 = new Human("yasin", "askarian", DateTime.Today, 158);
            Human h4 = new Human("yasin", "askarian", date2, 88);
            Human h5 = new Human("ali", "askarian", DateTime.Today, 188);
            Assert.AreEqual(true, Equals(h5, h1));
            Assert.AreEqual(false, Equals(h1, h2));
            Assert.AreEqual(true, h4 > h2);
            Assert.AreEqual(false, h1 > h2);
            Assert.AreEqual(true, h1 < h2);
            Assert.AreEqual(false, h4 < h2);
            Assert.AreEqual(true, h1 == h3);
            Assert.AreEqual(false, h1 == h2);
            Assert.AreEqual(true, h1 != h2);
            Assert.AreEqual(false, h1 != h3);
            Assert.AreEqual(true, h1 >= h3);
            Assert.AreEqual(false, h1 >= h4);
            Assert.AreEqual(true, h1 <= h3);
            Assert.AreEqual(false, h4 <= h3);

        }

        [TestMethod()]
        public void GetHashCodeTest()
        {
            DateTime date1 = new DateTime(2008, 3, 1, 7, 0, 0);
            Human h1 = new Human("ali", "askarian", DateTime.Today, 188);
            Human h2 = new Human("yasin", "askarian", date1, 188);
            Human h3 = new Human("yasin", "askarian", date1, 188);
            Assert.AreNotEqual(h1.GetHashCode(), h2.GetHashCode());
            Assert.AreEqual(h2.GetHashCode(), h3.GetHashCode());
        }
    }
}