using Microsoft.VisualStudio.TestTools.UnitTesting;
using LList;
using System;

namespace LinkedList.Test
{
    [TestClass]
    public class UnitTest1
    {
        LinkedList<string> _sut;

        [TestInitialize]
        public void TestInitialize()
        {
            var names = new string[]
            {
                "Anna", "Balázs", "Bence", "Barbara", "Dániel",
                "Eszter", "Gábor", "Gabriella", "István", "József",
                "Katalin", "Krisztián", "László", "Lilla", "Máté",
                "Nóra", "Réka", "Tamás", "Veronika", "Zoltán"
            };
            _sut = new LinkedList<string>();

            foreach (var name in names)
            {
                _sut.Add(name);
            }

        }

        //---------- Add ----------
        [TestMethod]
        public void Add_AddedElement()
        {
            _sut.Add("alma");
            Assert.AreEqual("alma", _sut.Tail.Data);
        }
        [TestMethod]
        public void Add_WorksWithNullInput()
        {
            _sut.Add(null);
            Assert.AreEqual(null, _sut.Tail.Data);
        }

        //---------- Get ----------


        //---------- Insert ----------
        [TestMethod]
        public void Insert_InsertedValueAtCorrectLocation()
        {
            _sut.Insert(2, "alma");
            Assert.AreEqual("alma",_sut.Get(2));
        }
        [TestMethod]
        public void Insert_HandelsNegativeArgumentCorrectly()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => _sut.Insert(-2, "alma"));
        }
    }
}
