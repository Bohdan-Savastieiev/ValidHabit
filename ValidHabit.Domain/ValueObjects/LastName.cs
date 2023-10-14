using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidHabit.Domain.ValueObjects
{
    public class LastName : Name
    {
        public LastName(string value) : base(value) { }

        protected override string GetExceptionMessage(string baseMessage)
        {
            return baseMessage.Replace("Name", "Last Name");
        }
    }
}