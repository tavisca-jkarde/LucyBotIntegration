﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucy.Handlers.MySql.CustomException
{
    public class InvalidConnectionStringException : Exception
    {
        public InvalidConnectionStringException()
            : base()
        {
        }
    }


}
