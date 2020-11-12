using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Destiny.Core.TaskScheduler.Domain.Models;
using Destiny.Core.TaskScheduler.Domain.Repository;
using Destiny.Core.TaskScheduler.Identity;
using System;

namespace Destiny.Core.TaskScheduler.AuthenticationCenter.Startups
{
    public class IdentityModule : IdentityModuleBase<UserStore, RoleStore, UserEntity, UserRoleEntity, RoleEntity, Guid, Guid>
    {
        protected override void AddAuthentication(IServiceCollection services)
        {
        }

        protected override Action<IdentityOptions> IdentityOption()
        {
            return options =>
            {
                options.SignIn.RequireConfirmedEmail = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.User.RequireUniqueEmail = false;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;
            };
        }

        protected override IdentityBuilder UseIdentityBuilder(IdentityBuilder identityBuilder)
        {
            return identityBuilder;/*.AddEntityFrameworkStores<DefaultDbContext>().AddDefaultTokenProviders();*/
        }
    }
}