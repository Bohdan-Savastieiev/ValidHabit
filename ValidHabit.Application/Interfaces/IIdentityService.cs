using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidHabit.Application.Interfaces
{
    public interface IIdentityService
    {
        Task<string> CreateAsync(string username, string password);
        Task<string> LoginAsync(string username, string password);
    }
}
