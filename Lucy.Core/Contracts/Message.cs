using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucy.Core.Contracts
{
    public class Message
    {
        public string Topic { get; set; }

        public object Payload { get; set; }
    }
}
