using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Microsoft.AspNetCore.Identity;
namespace GymMembership.Infrastructure.Identity;

public class IdentityService : IIdentityService
{
    private readonly UserManager<IdentityUser> _userManager;

    public IdentityService(UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
    }
    public async Task<string> CreateUserAsync(string email, string password)
    {

        var identityUser = new IdentityUser
        {
            UserName = email,
            Email = email
        };

        var identityResult = await _userManager.CreateAsync(identityUser, password);

        if (!identityResult.Succeeded)
        {
            var errors = string.Join(", ", identityResult.Errors.Select(e => e.Description));
            throw new Exception($"Account authentication registration failed: {errors}");
        }
        return identityUser.Id;
    }

    public async Task DeleteUserAsync(string identityUserId)
    {
        var user = await _userManager.FindByIdAsync(identityUserId);

        if (user == null)
        {
            return;
        }

        var result = await _userManager.DeleteAsync(user);

        if (!result.Succeeded)
        {
            var errors = string.Join(", ", result.Errors.Select(e => e.Description));
            throw new Exception($"Failed to delete authentication account: {errors}");
        }
    }
}
