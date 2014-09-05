using System;

namespace Lucy.Core.CustomAttributes
{
    public class CommandAttribute : Attribute
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Synopsis { get; set; }
        
        public CommandAttribute()
        {

        }

        public CommandAttribute(string name, string description, string synopsis)
        {
            this.Name = name;
            this.Description = description;
            this.Synopsis = synopsis;
        }

    }
}
