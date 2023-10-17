﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidHabit.Domain.Exceptions
{
    public class DomainException : Exception
    {
        public DomainException() : base() { }
        public DomainException(string message) : base(message) { }
        public DomainException(string message, Exception inner) : base(message, inner) { }
    }
}