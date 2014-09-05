using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lucy.Infrastructure
{
    public class TypeKey
    {
        public TypeKey(Type type, string name)
        {
            this.Type = type;
            this.Name = name;
        }

        public Type Type { get; private set; }

        public string Name { get; private set; }

        public override bool Equals(object obj)
        {
            if (obj is TypeKey)
            {
                var other = obj as TypeKey;
                return this.Type.Equals(other.Type) &&
                    (this.Name ?? string.Empty).Equals(other.Name ?? string.Empty);
            }
            else return false;
        }

        public override int GetHashCode()
        {
            return (this.Name ?? string.Empty).GetHashCode() ^ this.Type.GetHashCode();
        }
    }
}
