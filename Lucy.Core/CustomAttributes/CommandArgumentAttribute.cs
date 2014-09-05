using System;

namespace Lucy.Core.CustomAttributes
{
    public class CommandArgumentAttribute : Attribute
    {
        public string Name { get; set; }
        public bool IsMandatory { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }

        public CommandArgumentAttribute()
        {
        }

        public CommandArgumentAttribute(string name, bool isMandatory, string type, string description)
        {
            this.Name = name;
            this.IsMandatory = isMandatory;
            this.Type = type;
            this.Description = description;
        }

    }
}
