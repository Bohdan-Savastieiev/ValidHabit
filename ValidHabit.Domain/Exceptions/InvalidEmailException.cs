using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidHabit.Domain.Exceptions
{
    public class InvalidEmailException : DomainException
    {
        public string InvalidEmail { get; }

        public InvalidEmailException(string message, string invalidEmail) : base(message)
        {
            InvalidEmail = invalidEmail;
        }
    }
}