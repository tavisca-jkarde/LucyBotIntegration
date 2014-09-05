using DevOps.CustomAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucy.Core.ConvertToXml
{
    public class AttributesRetriever
    {

        public List<Attribute> GetCommandArgumentAttributes(string methodName)
        {
                List<Attribute> attributes=new List<Attribute>();
                System.Reflection.MemberInfo[] inf = typeof(TrialMySqlCH).GetMethods();
                if(inf.Any(method => (method.Name == methodName)))
                    attributes = ((Attribute[])inf.First(method => (method.Name == methodName))
                        .GetCustomAttributes(typeof(CommandArgumentAttribute), false)).ToList();
                    
                return attributes;
        }

        public List<Attribute> GetCommandAttributes(string methodName)
        {
            List<Attribute> attributes = new List<Attribute>();
            System.Reflection.MemberInfo[] inf = typeof(TrialMySqlCH).GetMethods();
            if (inf.Any(method => (method.Name == methodName)))
                attributes = ((Attribute[])inf.First(method => (method.Name == methodName))
                    .GetCustomAttributes(typeof(CommandAttribute), false)).ToList();

            return attributes;
        }

        public List<Attribute> GetCommandReturnsAttributes(string methodName)
        {
            List<Attribute> attributes = new List<Attribute>();
            System.Reflection.MemberInfo[] inf = typeof(TrialMySqlCH).GetMethods();
            if (inf.Any(method => (method.Name == methodName)))
                attributes = ((Attribute[])inf.First(method => (method.Name == methodName))
                    .GetCustomAttributes(typeof(CommandReturnsAttribute), false)).ToList();

            return attributes;
        }

        public List<Attribute> GetAttributes(string methodName)
        {
            List<Attribute> attributes = new List<Attribute>();

            attributes=attributes.Concat(this.GetCommandArgumentAttributes(methodName)).ToList();
            attributes = attributes.Concat(this.GetCommandAttributes(methodName)).ToList();
            attributes = attributes.Concat(this.GetCommandReturnsAttributes(methodName)).ToList();

            return attributes;
        }

    }
}
