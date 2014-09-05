using DevOps.CustomAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucy.Core.ConvertToXml
{
    public class TrialMySqlCH
    {
        [CommandArgumentAttribute("Name1",true, "Type1", "Description1")]
        [CommandAttribute("Type1","Description1")]
        [CommandReturnsAttribute("ReturnType1", "Description1")]
        public void TrialMethodOne()
        {
        }

        [CommandArgumentAttribute("Name2", true, "Type2", "Description2")]
        [CommandAttribute("Type2", "Description2")]
        [CommandReturnsAttribute("ReturnType2", "Description2")]
        public void TrialMethodTwo()
        {
        }

        [CommandArgumentAttribute("Name3", true, "Type3", "Description3")]
        [CommandAttribute("Type3", "Description3")]
        [CommandReturnsAttribute("ReturnType3", "Description3")]
        public void TrialMethodThree()
        {
        }

    }
}
