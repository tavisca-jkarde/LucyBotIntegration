using Lucy.Core.Model;
using System;
using System.Collections.Generic;


namespace Lucy.Core.Model
{
    public class Command
    {
        public Command()
        {
            this.Arguments = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        }

        public string Type { get; set; }

        public Dictionary<string, string> Arguments { get; private set; }
    }
}



