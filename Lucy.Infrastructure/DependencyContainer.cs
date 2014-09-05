using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucy.Infrastructure
{
    public class DependencyContainer:IDependencyContainer
    {

        private static readonly Dictionary<TypeKey, Type> _types = new Dictionary<TypeKey, Type>();

        public IDependencyContainer Register(Type interfaceType, Type concreteType, string name = null)
        {
            if (interfaceType == null || concreteType == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                _types[new TypeKey(interfaceType, name)] = concreteType;
                return this;
            }
        }



        public object Create(Type type, string name = null)
        {
            if (type == null)
                throw new ArgumentNullException();
            bool isInterface = type.IsInterface;
            if (isInterface == true)
                return CreateMappedType(type, name);
            bool hasDefaultConstructor = HasDefaultConstructor(type);
            if (hasDefaultConstructor == true)
                return CreateNewInstance(type);
            else
                return CreateNewInstanceWithParameterizedConstructor(type);
        }

        private object CreateNewInstanceWithParameterizedConstructor(Type type)
        {
            var constructor = type.GetConstructors().Single();
            var args = constructor.GetParameters();
            var values = args.Select(x => this.Create(x.ParameterType)).ToArray();
            return Activator.CreateInstance(type, values);
        }

        private object CreateNewInstance(Type type)
        {
            return Activator.CreateInstance(type);
        }

        private bool HasDefaultConstructor(Type type)
        {
            return type.GetConstructors()
                .Where(c => c.IsPublic == true)
                .Where(c => c.GetParameters().Length == 0)

                .Count() == 1;
        }

        private object CreateMappedType(Type type, string name)
        {
            var mappedType = _types[new TypeKey(type, name)];
            if (mappedType == null)
                throw new KeyNotFoundException();

            return this.Create(mappedType);
        }

        public int DictionaryCount()
        {
            return _types.Count();
        }
       
    }
}
