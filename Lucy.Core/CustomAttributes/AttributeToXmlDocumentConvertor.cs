using System;
using System.Collections.Generic;
using System.Xml;

namespace Lucy.Core.CustomAttributes
{
    public class AttributeToXmlDocumentConvertor
    {
        public XmlDocument AddCommandToXmlDocument(XmlDocument xmlDocument, List<Attribute> attributes)
        {
            var commandsNode = xmlDocument.GetElementsByTagName("Commands").Item(0);

            var commandNode = xmlDocument.CreateElement("Command");

            if (commandsNode != null) commandsNode.AppendChild(commandNode);

            attributes.ForEach(x => AppendToCommandNode(x, commandNode, xmlDocument));

            return xmlDocument;
        }

        private static void AppendToCommandNode(Attribute attribute, XmlElement commandNode, XmlDocument xmlDocument)
        {
            var commandAttribute = attribute as CommandAttribute;
            if (commandAttribute != null)
            {
                commandNode.SetAttribute("Name", commandAttribute.Name);
                commandNode.SetAttribute("Synopsis", commandAttribute.Synopsis);
                commandNode.SetAttribute("Description", commandAttribute.Description);
                return;
            }

            var commandArgumentAttribute = attribute as CommandArgumentAttribute;
            if (commandArgumentAttribute != null)
            {
                var commandArgumentElement = xmlDocument.CreateElement("CommandArgument");
                commandArgumentElement.SetAttribute("Name", commandArgumentAttribute.Name);
                commandArgumentElement.SetAttribute("Description", commandArgumentAttribute.Description);
                commandNode.AppendChild(commandArgumentElement);
                return;
            }

            var commandReturnsAttribute = attribute as CommandReturnsAttribute;
            if (commandReturnsAttribute == null) return;

            var commandReturnsElement = xmlDocument.CreateElement("CommandReturns");
            commandReturnsElement.SetAttribute("Description", commandReturnsAttribute.Description);
            commandNode.AppendChild(commandReturnsElement);
        }

        public XmlDocument GetDefaultXmlDocument()
        {
            var xmlDocument = new XmlDocument();

            var rootNode = xmlDocument.CreateElement("Help");

            xmlDocument.AppendChild(rootNode);

            var commandsNode = xmlDocument.CreateElement("Commands");

            rootNode.AppendChild(commandsNode);
            return xmlDocument;
        }
    }
}
