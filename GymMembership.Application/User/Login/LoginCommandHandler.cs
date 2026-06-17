using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymMembership.Application.Common.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponseDto>
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly IApplicationDbContext _context;

    public LoginCommandHandler( UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IApplicationDbContext context)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _context = context;
    }

    public async Task<LoginResponseDto> Handle(LoginCommand command, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmailAsync(command.Email);
        if (user == null)
            return new LoginResponseDto(false, "", "", DateTime.Now, "Invalid email or password.");

        var result = await _signInManager.CheckPasswordSignInAsync(user, command.Password, lockoutOnFailure: false);
        if (!result.Succeeded)
            return new LoginResponseDto(false, "", "", DateTime.Now, "Invalid email or password.");

        string userType = "Unknown";

        if (await _context.Members.AnyAsync(m => m.IdentityUserId == user.Id, cancellationToken))
        {
            userType = "Member";
        }
        else if (await _context.Instructors.AnyAsync(i => i.IdentityUserId == user.Id, cancellationToken))
        {
            userType = "Instructor";
        }
        else if (await _context.Admins.AnyAsync(a => a.IdentityUserId == user.Id, cancellationToken))
        {
            userType = "Admin";
        }

        // Temp token
        string fakeJwtToken = "generated-json-web-token-goes-here";

        return new LoginResponseDto(true, fakeJwtToken, userType, DateTime.Now.AddHours(1), "");
    }
}
