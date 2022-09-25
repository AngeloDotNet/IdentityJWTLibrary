﻿using IdentityAuth.Authentication.Entities;
using IdentityAuth.Authentication.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace IdentityAuth.Authentication.Requirements;

public class UserActiveHandler : AuthorizationHandler<UserActiveRequirement>
{
    private readonly UserManager<ApplicationUser> userManager;

    public UserActiveHandler(UserManager<ApplicationUser> userManager)
    {
        this.userManager = userManager;
    }

    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, UserActiveRequirement requirement)
    {
        if (context.User.Identity.IsAuthenticated)
        {
            var userId = context.User.GetId();
            var user = await userManager.FindByIdAsync(userId.ToString());
            if (user != null && user.LockoutEnd.GetValueOrDefault() <= DateTimeOffset.UtcNow)
            {
                context.Succeed(requirement);
            }
        }
    }
}