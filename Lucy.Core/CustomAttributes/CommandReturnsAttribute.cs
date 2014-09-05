using System;

namespace Lucy.Core.CustomAttributes
{
    public class CommandReturnsAttribute : Attribute
    {
        public string ReturnType { get; set; }
        public string Description { get; set; }
        
        public CommandReturnsAttribute()
        {

        }
        
        public CommandReturnsAttribute(string returnType,string description)
        {
            this.ReturnType = returnType;
            this.Description = description;
        }
    }
}
