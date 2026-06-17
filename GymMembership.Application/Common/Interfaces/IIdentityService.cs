using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IIdentityService
{
    Task<string> CreateUserAsync(string email, string password);
    Task DeleteUserAsync(string identityUserId);
}
