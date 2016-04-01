using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AnalisisYDisenio1Examen2.Logic;

namespace AnalisisYDisenio1Examen2.Tests
{
    [TestClass]
    public class AnalisisYDisenio1Examen2Tests
    {
        [TestMethod]
        public void Test_Serialize_Int32()
        {
            var serializer = new XMLSerializer();
            int value = 10;
            Assert.AreEqual("<Int32>" + value + "</Int32>", serializer.Serialize(value), "Int32 Parser not correct");
        }

        [TestMethod]
        public void Test_Serialize_String()
        {
            var serializer = new XMLSerializer();
            string value = "Hello";
            Assert.AreEqual("<String>" + value + "</String>", serializer.Serialize(value), "String Parser not correct");
        }

        [TestMethod]
        public void Test_Serialize_Double()
        {
            var serializer = new XMLSerializer();
            double value = 10.5;
            Assert.AreEqual("<Double>" + value + "</Double>", serializer.Serialize(value), "Double Parser not correct");
        }

        [TestMethod]
        public void Test_Serialize_Float()
        {
            var serializer = new XMLSerializer();
            float value = 10.5F;
            Assert.AreEqual("<Single>" + value + "</Single>", serializer.Serialize(value), "Float Parser not correct");
        }

        [TestMethod]
        public void Test_Serialize_DateTime()
        {
            var serializer = new XMLSerializer();
            DateTime value = DateTime.Now;
            Assert.AreEqual("<DateTime>" + value + "</DateTime>", serializer.Serialize(value), "DateTime Parser not correct");
        }

        [TestMethod]
        public void Test_Serialize_Boolean()
        {
            var serializer = new XMLSerializer();
            bool value = false;
            Assert.AreEqual("<Boolean>" + value + "</Boolean>", serializer.Serialize(value), "Boolean Parser not correct");
        }

        [TestMethod]
        public void Test_Serialize_Char()
        {
            var serializer = new XMLSerializer();
            char value = 'c';
            Assert.AreEqual("<Char>" + value + "</Char>", serializer.Serialize(value), "Char Parser not correct");
        }

        [TestMethod]
        public void Test_Serialize_Long()
        {
            var serializer = new XMLSerializer();
            long value = 10;
            Assert.AreEqual("<Int64>" + value + "</Int64>", serializer.Serialize(value), "Long Parser not correct");
        }

        [TestMethod]
        public void Test_Serialize_Short()
        {
            var serializer = new XMLSerializer();
            short value = 10;
            Assert.AreEqual("<Int16>" + value + "</Int16>", serializer.Serialize(value), "Short Parser not correct");
        }

        [TestMethod]
        public void Test_Serialize_Unsigned_Int()
        {
            var serializer = new XMLSerializer();
            uint value = 10;
            Assert.AreEqual("<UInt32>" + value + "</UInt32>", serializer.Serialize(value), "Unsigned Int Parser not correct");
        }

        [TestMethod]
        public void Test_Serialize_Decimal()
        {
            var serializer = new XMLSerializer();
            decimal value = 10.5M;
            Assert.AreEqual("<Decimal>" + value + "</Decimal>", serializer.Serialize(value), "Decimal Parser not correct");
        }

        [TestMethod]
        public void Test_Serialize_Nonprimitive_Object()
        {
            var serializer = new XMLSerializer();
            School value = new School("A", 12, "C");
            Assert.AreEqual("<School><String name = 'Name'>A</String><Int32 name = 'ClassCount'>12</Int32></School>", serializer.Serialize(value), "Decimal Parser not correct");
        }

        [TestMethod]
        public void Test_Serialize_Object_that_Contains_Another_Object()
        {
            var serializer = new XMLSerializer();
            SchoolCollection value = new SchoolCollection(new School("A", 12, "C"));
            Assert.AreEqual("<SchoolCollection><School name = 'MainSchool'><String name = 'Name'>A</String><Int32 name = 'ClassCount'>12</Int32></School></SchoolCollection>", serializer.Serialize(value), "Decimal Parser not correct");
        }

        [TestMethod]
        public void Test_Serialize_null_value()
        {
            var serializer = new XMLSerializer();
            Assert.AreEqual("", serializer.Serialize(null), "Decimal Parser not correct");
        }

        [TestMethod]
        public void Test_Serialize_Int_Array()
        {
            var serializer = new XMLSerializer();
            Assert.AreEqual("<Int32[]><Int32>1</Int32><Int32>2</Int32><Int32>3</Int32><Int32>4</Int32></Int32[]>", serializer.Serialize(new int[]{ 1,2,3,4}),"Decimal Parser not correct");
        }

        [TestMethod]
        public void Test_Serialize_Custom_Class_Array()
        {
            var serializer = new XMLSerializer();
            Assert.AreEqual("<School[]><School><String name = 'Name'></String><Int32 name = 'ClassCount'>0</Int32></School><School><String name = 'Name'></String><Int32 name = 'ClassCount'>0</Int32></School></School[]>", serializer.Serialize(new School[] { new School("", 0, ""), new School("",0,"")}), "Decimal Parser not correct");
        }

        [TestMethod]
        public void Test_Serialize__Class_with_XMLName()
        {
            var serializer = new XMLSerializer();
            Assert.AreEqual("<Student><String name = 'studentName'>Carlos</String></Student>", serializer.Serialize(new Student("Carlos")), "Decimal Parser not correct");
        }
    }
}
