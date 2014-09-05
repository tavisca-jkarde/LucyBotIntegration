using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucy.Infrastructure
{
    public static class ObjectBuilder
    {
        public static IDependencyContainer Container { get; set; } // Initialize this

        public static object Create(Type type, string name = null)
        {
            return Container.Create(type, name);
        }

        public static T Create<T>(string name = null )
        {
            return (T)Container.Create(typeof(T), name);
        }
    }
}
