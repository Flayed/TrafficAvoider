using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficAvoider.Lib.Helpers;

namespace TrafficAvoider.Lib.UnitTests.Helpers
{
    [TestClass]
    public class AutoMapperTests
    {
        public class MyObject
        {
            public int MyIntProperty { get; set; }
            public long MyLongProperty { get; set; }
            public string MyStringProperty { get; set; }
            public DateTime MyDateTimeProperty { get; set; }
        }

        public class MyObjectClone
        {
            public int MyIntProperty { get; set; }
            public long MyLongProperty { get; set; }
            public string MyStringProperty { get; set; }
            public DateTime MyDateTimeProperty { get; set; }
        }

        public class MyOtherObject
        {
            public int IntProperty { get; set; }
            public long LongProperty { get; set; }
            public string StringProperty { get; set; }
            public DateTime DateTimeProperty { get; set; }
            public int MyIntProperty { get; set; }
            public long MyLongProperty { get; set; }
        }

        public class MyNullableObject
        {
            public int? MyIntProperty { get; set; }
            public long? MyLongProperty { get; set; }
            public string MyStringProperty { get; set; }
            public DateTime? MyDateTimeProperty { get; set; }
        }

        [TestMethod]
        public void Map_MapsGenericProperties()
        {
            int expectedInt = 42;
            long expectedLong = 8675309;
            string expectedString = "ExpectedString";
            DateTime expectedDateTime = new DateTime(2015, 6, 12, 1, 2, 3);
            MyObject myObject = new MyObject() { MyIntProperty = expectedInt, MyLongProperty = expectedLong, MyStringProperty = expectedString, MyDateTimeProperty = expectedDateTime };

            var actual = AutoMapper.Map<MyObjectClone, MyObject>(myObject);

            Assert.AreEqual(expectedInt, actual.MyIntProperty);
            Assert.AreEqual(expectedLong, actual.MyLongProperty);
            Assert.AreEqual(expectedString, actual.MyStringProperty);
            Assert.AreEqual(expectedDateTime, actual.MyDateTimeProperty);
        }

        [TestMethod]
        public void Map_MapsOnlyMatchingGenericProperies()
        {
            int expectedInt = 42;
            long expectedLong = 8675309;
            MyObject myObject = new MyObject { MyIntProperty = expectedInt, MyLongProperty = expectedLong, MyStringProperty = "THIS IS A STRING", MyDateTimeProperty = DateTime.Now };

            var actual = AutoMapper.Map<MyOtherObject, MyObject>(myObject);

            Assert.AreEqual(expectedInt, actual.MyIntProperty);
            Assert.AreEqual(expectedLong, actual.MyLongProperty);
            Assert.AreEqual(0, actual.IntProperty);
            Assert.AreEqual(0, actual.LongProperty);
            Assert.AreEqual(null, actual.StringProperty);
            Assert.AreEqual(new DateTime(), actual.DateTimeProperty);
        }

        [TestMethod]
        public void Map_MapsWithCustomMappingFunction()
        {
            int expectedInt = 42;
            long expectedLong = 8675309;
            string expectedString = "ExpectedString";
            DateTime expectedDateTime = new DateTime(2015, 6, 12, 1, 2, 3);
            int expectedOtherInt = expectedInt * 2;
            long expectedOtherLong = expectedLong * 2;
            MyObject myObject = new MyObject() { MyIntProperty = expectedInt, MyLongProperty = expectedLong, MyStringProperty = expectedString, MyDateTimeProperty = expectedDateTime };

            var actual = AutoMapper.Map<MyOtherObject, MyObject>(myObject, (source, destination) => {
                destination.StringProperty = source.MyStringProperty;
                destination.DateTimeProperty = source.MyDateTimeProperty;
                destination.IntProperty = source.MyIntProperty * 2;
                destination.LongProperty = source.MyLongProperty * 2;
            });

            Assert.AreEqual(expectedInt, actual.MyIntProperty);
            Assert.AreEqual(expectedLong, actual.MyLongProperty);
            Assert.AreEqual(expectedOtherInt, actual.IntProperty);
            Assert.AreEqual(expectedOtherLong, actual.LongProperty);
            Assert.AreEqual(expectedString, actual.StringProperty);
            Assert.AreEqual(expectedDateTime, actual.DateTimeProperty);
        }

        [TestMethod]
        public void Map_MapsWithNullableProperties()
        {
            int expectedInt = 42;
            long expectedLong = 8675309;
            string expectedString = "ExpectedString";
            DateTime expectedDateTime = new DateTime(2015, 6, 12, 1, 2, 3);
            MyObject myObject = new MyObject() { MyIntProperty = expectedInt, MyLongProperty = expectedLong, MyStringProperty = expectedString, MyDateTimeProperty = expectedDateTime };

            var actual = AutoMapper.Map<MyNullableObject, MyObject>(myObject);

            Assert.AreEqual(expectedInt, actual.MyIntProperty);
            Assert.AreEqual(expectedLong, actual.MyLongProperty);
            Assert.AreEqual(expectedString, actual.MyStringProperty);
            Assert.AreEqual(expectedDateTime, actual.MyDateTimeProperty);
        }

        [TestMethod]
        public void Map_MapsNullablePropertiesToNullableProperties()
        {
            int? expectedInt = 42;
            long? expectedLong = 8675309;
            string expectedString = "ExpectedString";
            DateTime? expectedDateTime = new DateTime(2015, 6, 12, 1, 2, 3);
            MyNullableObject myNullableObject = new MyNullableObject() { MyIntProperty = expectedInt, MyLongProperty = expectedLong, MyStringProperty = expectedString, MyDateTimeProperty = expectedDateTime };

            var actual = AutoMapper.Map<MyNullableObject, MyNullableObject>(myNullableObject);

            Assert.AreEqual(expectedInt, actual.MyIntProperty);
            Assert.AreEqual(expectedLong, actual.MyLongProperty);
            Assert.AreEqual(expectedString, actual.MyStringProperty);
            Assert.AreEqual(expectedDateTime, actual.MyDateTimeProperty);
        }

        [TestMethod]
        public void Map_MapsNullableProperties()
        {
            int? expectedInt = 42;
            long? expectedLong = 8675309;
            string expectedString = "ExpectedString";
            DateTime? expectedDateTime = new DateTime(2015, 6, 12, 1, 2, 3);
            MyNullableObject myNullableObject = new MyNullableObject() { MyIntProperty = expectedInt, MyLongProperty = expectedLong, MyStringProperty = expectedString, MyDateTimeProperty = expectedDateTime };

            var actual = AutoMapper.Map<MyObject, MyNullableObject>(myNullableObject);

            Assert.AreEqual(expectedInt, actual.MyIntProperty);
            Assert.AreEqual(expectedLong, actual.MyLongProperty);
            Assert.AreEqual(expectedString, actual.MyStringProperty);
            Assert.AreEqual(expectedDateTime, actual.MyDateTimeProperty);
        }

        [TestMethod]
        public void Map_MapsNonNullNullableProperties()
        {
            string expectedString = "ExpectedString";
            DateTime? expectedDateTime = new DateTime(2015, 6, 12, 1, 2, 3);
            MyNullableObject myNullableObject = new MyNullableObject() { MyStringProperty = expectedString, MyDateTimeProperty = expectedDateTime };

            var actual = AutoMapper.Map<MyObject, MyNullableObject>(myNullableObject);

            Assert.AreEqual(0, actual.MyIntProperty);
            Assert.AreEqual(0, actual.MyLongProperty);
            Assert.AreEqual(expectedString, actual.MyStringProperty);
            Assert.AreEqual(expectedDateTime, actual.MyDateTimeProperty);
        }
    }
}
