﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL1
{
    public class DekstraException : ApplicationException
    {
        public DekstraException(string message) : base(message)
        {
        }
    }
}
