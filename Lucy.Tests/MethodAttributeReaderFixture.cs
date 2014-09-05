using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lucy.Core.CustomAttributes;
using System.Collections.Generic;

namespace Lucy.Tests
{
    [TestClass]
    public class MethodAttributeReaderFixture
    {
        private MethodAttributeReader _attributesRetriever;
       
        [TestInitialize]
        public void BeforeTest()
        {
            _attributesRetriever = new MethodAttributeReader();
        }

        [TestCleanup]
        public void AfterTest()
        {
            _attributesRetriever = null;
        }
        

        [TestMethod]
        public void GetCommandArgumentAttributesShouldReturnCommandArgumentAttributes()
        {
            var name = "TrialMethodOne";
            var commandArgumentAttribute = _attributesRetriever.GetCommandArgumentAttributes(name, typeof(ServiceHandlerStub));
            Assert.IsNotNull(commandArgumentAttribute);
        }

        [TestMethod]
        public void GetCommandAttributesShouldReturnCommandAttributes()
        {
            var name = "TrialMethodOne";
            var commandAttribute = _attributesRetriever.GetCommandAttributes(name, typeof(ServiceHandlerStub));
            Assert.IsNotNull(commandAttribute);
        }

        [TestMethod]
        public void GetCommandReturnsAttributesShouldReturnCommandReturnsAttributes()
        {
            var name = "TrialMethodOne";
            var commandReturnsAttribute = _attributesRetriever.GetCommandReturnsAttributes(name, typeof(ServiceHandlerStub));
            Assert.IsNotNull(commandReturnsAttribute);
        }

        [TestMethod]
        public void GetAttributesShouldReturnAllAttributes()
        {
            var name = "TrialMethodOne";
            var attributes = _attributesRetriever.GetAttributes(name, typeof(ServiceHandlerStub));
            Assert.IsNotNull(attributes);
        }

        [TestMethod]
        public void NotExistingMethodShouldReturnEmptyListOfCommandArgumentAttribute()
        {
            var name = "NotExistingMethod";
            var commandArgumentAttribute = _attributesRetriever.GetCommandArgumentAttributes(name, typeof(ServiceHandlerStub));
            Assert.IsTrue(commandArgumentAttribute.Count == 0);
        }

        [TestMethod]
        public void NotExistingMethodShouldReturnEmptyListOfCommandAttribute()
        {
            var name = "NotExistingMethod";
            var commandAttribute = _attributesRetriever.GetCommandAttributes(name, typeof(ServiceHandlerStub));
            Assert.IsNull(commandAttribute);
        }

        [TestMethod]
        public void NotExistingMethodShouldReturnEmptyListOfCommandReturnsAttribute()
        {
            var name = "NotExistingMethod";
            var commandReturnsAttribute = _attributesRetriever.GetCommandReturnsAttributes(name, typeof(ServiceHandlerStub));
            Assert.IsNull(commandReturnsAttribute);
        }

        [TestMethod]
        public void NotExistingMethodShouldReturnEmptyListOfAttribute()
        {
            const string name = "NotExistingMethod";
            var attributes = _attributesRetriever.GetAttributes(name, typeof(ServiceHandlerStub));
            Assert.IsTrue(attributes.Count == 0);
        }

        [TestMethod]
        public void GetAttributesOfAllMethodsFromClassShouldReturnAllAttributes()
        {
            var classNameList = new List<Type> { typeof(ServiceHandlerStub) };
            var attributes = _attributesRetriever.GetAttributesOfAllMethodsFromClass(classNameList);
            Assert.IsTrue(attributes.Count != 0);
        }
    }
}
