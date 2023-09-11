using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using FluentValidation;
using FluentValidation.AspNetCore;
using AutoMapper;
using UniversityApplication.Mapping;
using MediatR;
using UniversityDataLayer.Extensions;
using UniversityApplication.CQRSModuels.Courses.Commands.Create;
using UniversityApplication.CQRSModuels.Groups.Commands.Create;
using UniversityApplication.CQRSModuels.Students.Commands.Create;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using System.Globalization;
using System.Reflection;
using UniversityDataLayer.Migrations;
using Microsoft.AspNetCore.Identity;
using UniversityDataLayer;
using UniversityApplication.User;

namespace UniversityApplication.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddApplicationDependencies (this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDataLayerDependencies(configuration);

            services.AddScoped( provider => new MapperConfiguration(cfg =>
            {
                var scope = provider.CreateScope();
                var userContext = scope.ServiceProvider.GetRequiredService<IUserContext>();

                cfg.AddProfile(new CourseProfile());
                cfg.AddProfile(new GroupProfile());
                cfg.AddProfile(new StudentProfile());
            }).CreateMapper()
            );

            services.AddValidatorsFromAssemblyContaining<CreateCourseCommandValidator>()
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));


            services.AddLocalization(options => options.ResourcesPath = "Resources");

            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new[]
                {
                new CultureInfo("en-US"),
                new CultureInfo("uk-UA"),
            };

                options.DefaultRequestCulture = new RequestCulture(culture: "uk-UA", uiCulture: "uk-UA");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });

            services.AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<UniversityContext>();
        }

        public static void ConfigureAdminUser(this IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();
            using (var scope = serviceProvider.CreateScope())
            {
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
                Task.Run(async () =>
                {
                    var _user = await userManager.FindByEmailAsync("admin@mail.com");

                    if (_user == null)
                    {
                        var poweruser = new IdentityUser
                        {
                            UserName = "admin@mail.com",
                            Email = "admin@mail.com",
                        };
                        string adminPassword = "A_dmin123";

                        var createPowerUser = await userManager.CreateAsync(poweruser, adminPassword);
                        if (createPowerUser.Succeeded)
                        {
                            await userManager.AddToRoleAsync(poweruser, "Admin");
                        }
                    }
                }).Wait();
            }
        }
    }
}
