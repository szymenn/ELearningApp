using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ELearningApp.Api.Extensions;
using ELearningApp.Api.MapperConfig;
using ELearningApp.Core.Auth.Handlers;
using ELearningApp.Core.Auth.Requirements;
using ELearningApp.Core.Dtos.ApiModels.Auth;
using ELearningApp.Core.Entities.Auth;
using ELearningApp.Core.Helpers;
using ELearningApp.Core.Interfaces.Repositories.Auth;
using ELearningApp.Core.Interfaces.Services.Auth;
using ELearningApp.Core.Options;
using ELearningApp.Core.Services.Auth;
using ELearningApp.Infrastructure.Data;
using ELearningApp.Infrastructure.Repositories.Auth;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
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
using Microsoft.IdentityModel.Tokens;

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
            
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITokenRepository, TokenRepository>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IRefreshTokenService, RefreshTokenService>();
            services.AddScoped<IJwtService, JwtService>();
            
            services.AddIdentity<User, IdentityRole>(options =>
                {
                    options.SignIn.RequireConfirmedEmail = true;
                    options.User.RequireUniqueEmail = true;
                })
                .AddEntityFrameworkStores<UserStoreDbContext>()
                .AddDefaultTokenProviders();

            var token = Configuration.GetSection(Constants.JwtSettings).Get<JwtSettings>();
            var secret = Encoding.ASCII.GetBytes(token.Secret);
            
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(secret),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
                
            services.AddAuthorization(options =>
            {
                options.AddPolicy("IsTeacher", policy =>
                    policy.Requirements.Add(new RoleRequirement(RoleEnum.Teacher)));
                options.AddPolicy("IsStudent", policy => 
                    policy.Requirements.Add(new RoleRequirement(RoleEnum.Student)));
            });

            services.AddSingleton<IAuthorizationHandler, TeacherHandler>();
            services.AddSingleton<IAuthorizationHandler, StudentHandler>();
            

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseCustomExceptionHandler();
            }
            
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}