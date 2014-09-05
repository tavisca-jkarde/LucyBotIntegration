using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lucy.Core.ConvertToXml;
using System.Diagnostics;
using System.Collections.Generic;

namespace Lucy.Tests
{
    [TestClass]
    public class AttributesRetrieverFixture
    {
        [TestMethod]
        public void GetCommandArgumentAttributesShouldReturnCommandArgumentAttributes()
        {
            string name = "TrialMethodOne";
            AttributesRetriever attributesRetriever = new AttributesRetriever();
            List<Attribute> commandArgumentAttribute=new List<Attribute>(); 
            commandArgumentAttribute=attributesRetriever.GetCommandArgumentAttributes(name);
            Assert.IsNotNull(commandArgumentAttribute);
        }

        [TestMethod]
        public void GetCommandAttributesShouldReturnCommandAttributes()
        {
            string name = "TrialMethodOne";
            AttributesRetriever attributesRetriever = new AttributesRetriever();
            List<Attribute> commandAttribute = new List<Attribute>();
            commandAttribute = attributesRetriever.GetCommandAttributes(name);
            Assert.IsNotNull(commandAttribute);
        }

        [TestMethod]
        public void GetCommandReturnsAttributesShouldReturnCommandReturnsAttributes()
        {
            string name = "TrialMethodOne";
            AttributesRetriever attributesRetriever = new AttributesRetriever();
            List<Attribute> commandReturnsAttribute = new List<Attribute>();
            commandReturnsAttribute = attributesRetriever.GetCommandReturnsAttributes(name);
            Assert.IsNotNull(commandReturnsAttribute);
        }

        [TestMethod]
        public void GetAttributesShouldReturnAllAttributes()
        {
            string name = "TrialMethodOne";
            AttributesRetriever attributesRetriever = new AttributesRetriever();
            List<Attribute> attributes = new List<Attribute>();
            attributes = attributesRetriever.GetAttributes(name);
            Assert.IsNotNull(attributes);
        }

        [TestMethod]
        public void NotExistingMethodShouldReturnEmptyListOfCommandArgumentAttribute()
        {
            string name = "NotExistingMethod";
            AttributesRetriever attributesRetriever = new AttributesRetriever();
            List<Attribute> commandArgumentAttribute = new List<Attribute>();
            commandArgumentAttribute = attributesRetriever.GetCommandArgumentAttributes(name);
            Assert.IsTrue(commandArgumentAttribute.Count==0);
        }

        [TestMethod]
        public void NotExistingMethodShouldReturnEmptyListOfCommandAttribute()
        {
            string name = "NotExistingMethod";
            AttributesRetriever attributesRetriever = new AttributesRetriever();
            List<Attribute> commandAttribute = new List<Attribute>();
            commandAttribute = attributesRetriever.GetCommandAttributes(name);
            Assert.IsTrue(commandAttribute.Count==0);
        }

        [TestMethod]
        public void NotExistingMethodShouldReturnEmptyListOfCommandReturnsAttribute()
        {
            string name = "NotExistingMethod";
            AttributesRetriever attributesRetriever = new AttributesRetriever();
            List<Attribute> commandReturnsAttribute = new List<Attribute>();
            commandReturnsAttribute = attributesRetriever.GetCommandReturnsAttributes(name);
            Assert.IsTrue(commandReturnsAttribute.Count==0);
        }

        [TestMethod]
        public void NotExistingMethodShouldReturnEmptyListOfAttribute()
        {
            string name = "NotExistingMethod";
            AttributesRetriever attributesRetriever = new AttributesRetriever();
            List<Attribute> attributes = new List<Attribute>();
            attributes = attributesRetriever.GetAttributes(name);
            Assert.IsTrue(attributes.Count==0);
        }

    }
}
