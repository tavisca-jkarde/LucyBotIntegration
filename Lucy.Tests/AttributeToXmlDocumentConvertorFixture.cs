using System;
using System.Collections.Generic;
using Lucy.Core.CustomAttributes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lucy.Tests
{
    [TestClass]
    public class AttributeToXmlDocumentConvertorFixture
    {
        private AttributeToXmlDocumentConvertor _attributeToXmlDocumentConvertor;

        [TestInitialize]
        public void BeforeTest()
        {
            _attributeToXmlDocumentConvertor = new AttributeToXmlDocumentConvertor();
        }

        [TestCleanup]
        public void AfterTest()
        {
            _attributeToXmlDocumentConvertor = null;
        }
        
        [TestMethod]
        public void TryGetXmlDocument()
        {
            var attributes = new List<Attribute>();

            var xmlDocument = _attributeToXmlDocumentConvertor.GetDefaultXmlDocument();

            xmlDocument = _attributeToXmlDocumentConvertor.AddCommandToXmlDocument(xmlDocument, attributes);

            var commandNodes = xmlDocument.SelectNodes("//Commands/Command");

            Assert.IsNotNull(commandNodes);
            Assert.IsTrue(commandNodes.Count > 0);
        }
        
        [TestMethod]
        public void TryGetXmlDocumentWithAllAttibutes()
        {
            var attributesRetriever = new MethodAttributeReader();

            var attributes = attributesRetriever.GetAttributes("TrialMethodOne", typeof(ServiceHandlerStub));

            var xmlDocument = _attributeToXmlDocumentConvertor.GetDefaultXmlDocument();

            xmlDocument = _attributeToXmlDocumentConvertor.AddCommandToXmlDocument(xmlDocument, attributes);

            var commandNodes = xmlDocument.SelectNodes("//Commands/Command");
            var commandReturnsNode = xmlDocument.SelectNodes("//Commands/Command/CommandReturns");
            var commandArgumentNode = xmlDocument.SelectNodes("//Commands/Command/CommandArgument");

            Assert.IsNotNull(commandNodes);
            Assert.IsTrue(commandNodes.Count > 0);
            Assert.IsNotNull(commandReturnsNode);
            Assert.IsTrue(commandNodes.Count > 0);
            Assert.IsNotNull(commandArgumentNode);
            Assert.IsTrue(commandNodes.Count > 0);
        }
    }
}
