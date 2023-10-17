using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidHabit.Domain.ValueObjects
{
    public class LastName : Name
    {
        private LastName(string value) : base(value, "Last Name") { }

        public static new LastName Create(string value)
        {
            return new LastName(value);
        }
    }
}