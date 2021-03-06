﻿using System;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Linq;

using Cogito.Dynamic;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Newtonsoft.Json;

namespace Cogito.Core.Tests.Dynamic
{

    [TestClass]
    public class ElasticObjectTests
    {

        [TestMethod]
        public void Test_serialize_invalid_property_name_with_old_xml()
        {
            dynamic o = new ElasticObject();
            o["000"] = "foo";
            var s = new DataContractSerializer(typeof(ElasticObject));
            var m = new XmlDocument();
            using (var w = m.CreateNavigator().AppendChild())
                s.WriteObject(w, o);
        }

        [TestMethod]
        public void Test_serialize_invalid_property_name()
        {
            dynamic o = new ElasticObject();
            o["000"] = "foo";
            var s = new DataContractSerializer(typeof(ElasticObject));
            var m = new XDocument();
            using (var w = m.CreateWriter())
                s.WriteObject(w, o);
        }

        [TestMethod]
        public void Test_serialize_to_xml()
        {
            dynamic o = new ElasticObject();
            o.Property1 = "foo";
            o.Property2 = "bar";
            var s = new DataContractSerializer(typeof(ElasticObject));
            var m = new XDocument();
            using (var w = m.CreateWriter())
                s.WriteObject(w, o);
        }

        [TestMethod]
        public void Test_serialize_to_json()
        {
            dynamic o = new ElasticObject();
            o.Property1 = "foo";
            o.Property2 = "bar";
            var s = JsonConvert.SerializeObject(o);
        }

        [TestMethod]
        public void Test_serialize_nested_properties_to_json()
        {
            dynamic o = new ElasticObject();
            o.Property1 = "foo";
            o.Property2 = "bar";
            o.Nested1 = new ElasticObject();
            o.Nested1.Property1 = "foo";
            o.Nested1.Property2 = "foo";
            var s = JsonConvert.SerializeObject(o);
        }

        [TestMethod]
        public void Test_serialize_nested_properties_to_xml()
        {
            dynamic o = new ElasticObject();
            o.Property1 = "foo";
            o.Property2 = "bar";
            o.Nested1 = new ElasticObject();
            o.Nested1.Property1 = "foo";
            o.Nested1.Property2 = "foo";
            var s = new DataContractSerializer(typeof(ElasticObject));
            var m = new XDocument();
            using (var w = m.CreateWriter())
                s.WriteObject(w, o);
        }

        [TestMethod]
        public void Test_deserialize_from_json()
        {
            dynamic o = new ElasticObject();
            o.Property1 = "foo";
            o.Property2 = "bar";
            var s = JsonConvert.SerializeObject(o);
            o = JsonConvert.DeserializeObject<ElasticObject>(s);
            Assert.IsNotNull(o);
            Assert.AreEqual("foo", o.Property1);
            Assert.AreEqual("bar", o.Property2);
        }

        [TestMethod]
        public void Test_deserialize_from_xml()
        {
            dynamic o = new ElasticObject();
            o.Property1 = "foo";
            o.Property2 = "bar";
            var s = new DataContractSerializer(typeof(ElasticObject));
            var m = new XDocument();
            using (var w = m.CreateWriter())
                s.WriteObject(w, o);
            o = s.ReadObject(m.CreateReader());
            Assert.IsNotNull(o);
            Assert.AreEqual("foo", o.Property1);
            Assert.AreEqual("bar", o.Property2);
        }

        [TestMethod]
        public void Test_deserialize_nested_properties_from_json()
        {
            dynamic o = new ElasticObject();
            o.Property1 = "foo";
            o.Property2 = "bar";
            o.Nested1 = new ElasticObject();
            o.Nested1.Property1 = "1foo";
            o.Nested1.Property2 = "1bar";
            var s = JsonConvert.SerializeObject(o);
            o = JsonConvert.DeserializeObject<ElasticObject>(s);
            Assert.IsNotNull(o);
            Assert.AreEqual("foo", o.Property1);
            Assert.AreEqual("bar", o.Property2);
            Assert.AreEqual("1foo", o.Nested1.Property1);
            Assert.AreEqual("1bar", o.Nested1.Property2);
        }

        [TestMethod]
        public void Test_deserialize_nested_properties_from_xml()
        {
            dynamic o = new ElasticObject();
            o.Property1 = "foo";
            o.Property2 = "bar";
            o.Nested1 = new ElasticObject();
            o.Nested1.Property1 = "1foo";
            o.Nested1.Property2 = "1bar";
            var s = new DataContractSerializer(typeof(ElasticObject));
            var m = new XDocument();
            using (var w = m.CreateWriter())
                s.WriteObject(w, o);
            o = s.ReadObject(m.CreateReader());
            Assert.IsNotNull(o);
            Assert.AreEqual("foo", o.Property1);
            Assert.AreEqual("bar", o.Property2);
            Assert.AreEqual("1foo", o.Nested1.Property1);
            Assert.AreEqual("1bar", o.Nested1.Property2);
        }

        [TestMethod]
        public void Test_Array_SerializeToXml()
        {
            dynamic o = new ElasticObject();
            o.Array = new string[] { "hello", "mom" };
            o.Foo = new int[] { 1, 2, 3 };
            var s = new DataContractSerializer(typeof(ElasticObject));
            var m = new XDocument();
            using (var w = m.CreateWriter())
                s.WriteObject(w, o);
        }

        [TestMethod]
        public void Test_Array_SerializeToJson()
        {
            dynamic o = new ElasticObject();
            o.Array = new string[] { "hello", "mom" };
            var s = JsonConvert.SerializeObject(o);
        }

        [TestMethod]
        public void Test_Array_DeserializeFromJson()
        {
            dynamic o = new ElasticObject();
            o.Array = new string[] { "hello", "mom" };
            var s = JsonConvert.SerializeObject(o);
            o = JsonConvert.DeserializeObject<ElasticObject>(s);
            Assert.IsTrue(o.Array is string[]);
        }

        [TestMethod]
        public void Test_Array_DeserializeFromJson2()
        {
            dynamic o = new ElasticObject();
            o.Array = new object[] { "hello", "mom", 1 };
            var s = JsonConvert.SerializeObject(o);
            o = JsonConvert.DeserializeObject<ElasticObject>(s);
            Assert.IsTrue(o.Array is object[]);
        }

        [TestMethod]
        public void Test_Array_DeserializeFromJson3()
        {
            dynamic o = new ElasticObject();
            o.Array = new object[] { new { Foo = "123" }, "mom", 1 , TimeSpan.FromMinutes(1), };
            var s = JsonConvert.SerializeObject(o);
            o = JsonConvert.DeserializeObject<ElasticObject>(s);
            Assert.IsTrue(o.Array is object[]);
        }

    }

}
