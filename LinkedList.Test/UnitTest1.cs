using Microsoft.VisualStudio.TestTools.UnitTesting;
using LList;
using System;
using System.Security.Permissions;

namespace LinkedList.Test
{
    [TestClass]
    public class UnitTest1
    {
        LinkedList<string> _sut;
        string[] names;

        [TestInitialize]
        public void TestInitialize()
        {
            names = new string[]
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

        //---------- Length
        [TestMethod]
        public void Length_ReturnsCorrectValue()
        {
            Assert.AreEqual(names.Length, _sut.Length);
        }
        //---------- 

        //---------- Get 
        [TestMethod]
        public void Get_GetsCorrectElement()
        {
            Assert.AreEqual(_sut.Head.Data, _sut.Get(0));
            Assert.AreEqual(_sut.Tail.Data, _sut.Get(_sut.Length-1));
        }
        //---------- 

        //---------- IndexOf
        [TestMethod]
        public void IndexOf_ReturnsCorrectElement()
        {
            Assert.AreEqual(0, _sut.IndexOf("Anna"));
            Assert.AreEqual(1, _sut.IndexOf("Balázs"));
            Assert.AreEqual(_sut.Length-1, _sut.IndexOf("Zoltán"));
        }
        //---------- 

        //---------- Add 
        [TestMethod]
        public void Add_AddsElement()
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
        //---------- 

        //---------- Insert 
        [TestMethod]
        public void Insert_InsertedValueAtCorrectLocation()
        {
            _sut.Insert(2, "");
            Assert.AreEqual("",_sut.Get(2));

            _sut.Insert(0, "");
            Assert.AreEqual("", _sut.Get(0));
        }
        [TestMethod]
        public void Insert_HandelsNegativeArgumentCorrectly()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => _sut.Insert(-2, "alma"));
        }
        //---------- 

        //---------- Remove 
        [TestMethod]
        public void Remove_RemovesElement()
        {
            _sut.Remove("Balázs");
            Assert.AreEqual(_sut.IndexOf("Balázs"),-1);
        }
        //---------- 

        //---------- RemoveAt 
        [TestMethod]
        public void RemoveAt_RemovesElementAtCorrectLocation()
        {
            var temp = _sut.Get(2);
            _sut.RemoveAt(2);
            Assert.AreNotSame(temp, _sut.Get(2));
        }
        //---------- 
        
        //---------- Search 
        [TestMethod]
        public void Search_SuccessfullyFoundElemnt()
        {
            Assert.AreSame(_sut.Head.Data, _sut.Search( data => data == "Anna"));
            Assert.AreSame(_sut.Tail.Data, _sut.Search( data => data == "Zoltán"));
        }
        //---------- 
    }
}
