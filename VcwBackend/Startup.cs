using Application.Interfaces.Challenge;
using Application.Interfaces.Filter;
using Application.Interfaces.FilterStatus;
using Application.Interfaces.General;
using Application.Interfaces.Idea;
using Application.Interfaces.IdeaStatus;
using Application.Interfaces.Invite;
using Application.Interfaces.User;
using Application.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Persistence;
using Persistence.Core;
using Persistence.Repositories;

namespace VcwBackend
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("RecruiterSystem");
            services.AddDbContext<ApiContext>(context =>
                context.UseSqlServer(connectionString));

            services.AddCors(options => options.AddPolicy("Cors", builder =>
            {
                builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            }));
            services.AddScoped<IChallengeRepository, ChallengeRepository>();
            services.AddScoped<IInviteRepository, InviteRepository>();
            services.AddScoped<IChallengeService, ChallengeService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IIdeaRepository, IdeaRepository>();
            services.AddScoped<IIdeaService, IdeaService>();
            services.AddScoped<IFilterRepository, FilterRepository>();
            services.AddScoped<IFilterService, FilterService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IIdeaStatusService, IdeaStatusService>();
            services.AddScoped<IIdeaStatusRepository, IdeaStatusRepository>();
            services.AddScoped<IFilterStatusService, FilterStatusService>();
            services.AddScoped<IFilterStatusRepository, FilterStatusRepository>();
//            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//                .AddJwtBearer(options =>
//                {
//                    options.TokenValidationParameters = new TokenValidationParameters
//                    {
//                        ValidateIssuerSigningKey = true,
//                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII
//                            .GetBytes(Configuration.GetSection("AppSettings:Token").Value)),
//                        ValidateIssuer = false,
//                        ValidateAudience = false
//                    };
//                });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2).AddJsonOptions(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseHsts();

//            app.UseHttpsRedirection();
            app.UseCors("Cors");
            app.UseMvc();
        }
    }
}