using System;
using System.Collections.Generic;
using System.Linq;

namespace Lucy.Core.CustomAttributes
{
    public class MethodAttributeReader
    {

        public List<CommandArgumentAttribute> GetCommandArgumentAttributes(string methodName, Type className)
        {
            var attributes = new List<CommandArgumentAttribute>();
            
            var methodInfoDetails = className.GetMethods();
            
            if (methodInfoDetails.Any(method => (method.Name == methodName)))
                attributes = ((CommandArgumentAttribute[])methodInfoDetails.First(method => (method.Name == methodName))
                    .GetCustomAttributes(typeof(CommandArgumentAttribute), false)).ToList();

            return attributes;
        }

        public CommandAttribute GetCommandAttributes(string methodName, Type className)
        {
            var attributes = new List<CommandAttribute>();
            var methodInfoDetails = className.GetMethods();
            if (methodInfoDetails.Any(method => (method.Name == methodName)))
                attributes = ((CommandAttribute[])methodInfoDetails.First(method => (method.Name == methodName))
                    .GetCustomAttributes(typeof(CommandAttribute), false)).ToList();

            return attributes.Any() ? attributes[0] : null;
        }

        public CommandReturnsAttribute GetCommandReturnsAttributes(string methodName, Type className)
        {
            var attributes = new List<CommandReturnsAttribute>();
            var methodInfoDetails = className.GetMethods();
            
            if (methodInfoDetails.Any(method => (method.Name == methodName)))
                attributes = ((CommandReturnsAttribute[])methodInfoDetails.First(method => (method.Name == methodName))
                    .GetCustomAttributes(typeof(CommandReturnsAttribute), false)).ToList();

            return attributes.Any() ? attributes[0] : null;
        }

        public List<Attribute> GetAttributes(string methodName, Type className)
        {
            var attributes = new List<Attribute>();
            var commandAttribute = this.GetCommandAttributes(methodName, className);
            var commandReturnsAttribute = this.GetCommandReturnsAttributes(methodName, className);

            attributes = attributes.Concat(this.GetCommandArgumentAttributes(methodName, className)).ToList();
            if(commandAttribute!=null)
                attributes.Add(commandAttribute);
            if(commandReturnsAttribute!=null)
                attributes.Add(commandReturnsAttribute);

            return attributes;
        }

        public List<Attribute> GetAttributesOfAllMethodsFromClass(List<Type> classNameList)
        {
            var attributes = new List<Attribute>();

            foreach (var className in classNameList)
            {
                var methodInfoDetails = className.GetMethods();
                attributes = methodInfoDetails.Aggregate(attributes, (current, method) => current.Concat(this.GetAttributes(method.Name, className)).ToList());
            }
            return attributes;
        }
    }
}
