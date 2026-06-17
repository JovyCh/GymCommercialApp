using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMembership.Application.Common.Interfaces
{
    public interface IEmailService
    {
        Task<bool> SendEmail(string email);
    }
}
