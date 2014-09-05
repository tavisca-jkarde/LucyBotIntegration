using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucy.Infrastructure
{
    public interface IDependencyContainer
    {
        IDependencyContainer Register(Type interfaceType, Type concreteType, string name = null);

        object Create(Type interfaceType, string name = null);
    }
}
