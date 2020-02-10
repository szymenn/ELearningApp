using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ELearningApp.Api.MapperConfig;
using ELearningApp.Core.Dtos.ApiModels.Auth;
using ELearningApp.Core.Helpers;
using ELearningApp.Core.Interfaces.Repositories.Auth;
using ELearningApp.Core.Interfaces.Services.Auth;
using ELearningApp.Core.Options;
using ELearningApp.Core.Services.Auth;
using ELearningApp.Infrastructure.Data;
using ELearningApp.Infrastructure.Repositories.Auth;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ELearningApp.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<UserStoreDbContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString(Constants.UserStoreConnectionString)));
            services.AddDbContext<TokenStoreDbContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString(Constants.TokenStoreConnectionString)));
            
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.AddProfile<MappingProfile>();
            });

            var mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.Configure<JwtSettings>(Configuration.GetSection(Constants.JwtSettings));
            services.Configure<EmailVerificationSettings>(
                Configuration.GetSection(Constants.EmailVerificationSettings));
            
            services.AddIdentity<IdentityUser, IdentityRole>(options =>
                {
                    options.SignIn.RequireConfirmedEmail = true;
                    options.User.RequireUniqueEmail = true;
                })
                .AddEntityFrameworkStores<UserStoreDbContext>()
                .AddDefaultTokenProviders();
            
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITokenRepository, TokenRepository>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IJwtHandler, JwtHandler>();
            services.AddScoped<IRefreshTokenHandler, RefreshTokenHandler>();
            
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}