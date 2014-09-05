using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucy.Infrastructure
{
    public static class DependencyContainerExtensions 
    { 
        public static IDependencyContainer Register<TInterface, TConcrete>(this IDependencyContainer container, string name = null)
        {
            return container.Register(typeof(TInterface), typeof(TConcrete), name);
        }

        public static IDependencyContainer Register<TInterface>(this IDependencyContainer container, string typeString, string name = null)
        {
            return container.Register(typeof(TInterface), Type.GetType(typeString, true), name); 
        }

       
    }
}
