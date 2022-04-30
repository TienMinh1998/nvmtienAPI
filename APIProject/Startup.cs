using AutoMapper;
using APIProject.Domain;
using APIProject.Service.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using APIProject.Repository;
using APIProject.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIProject.Service.Interface;
using System.Text;

using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Identity;
using APIProject.Service;
using System.Reflection;
using System.IO;
using Swashbuckle.AspNetCore.SwaggerUI;
using Microsoft.AspNetCore.Http;

using Microsoft.AspNetCore.HttpOverrides;
using APIProject.Service.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using APIProject.Models;

namespace APIProject
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddAutoMapper(typeof(Startup));
            services.AddControllers();

            services.AddDbContextPool<ApplicationDbContext>(options =>
            options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromHours(1);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            var secretKEy = Configuration["AppSettings:SecretKey"];
            var secretKEyBytes = Encoding.UTF8.GetBytes(secretKEy);


            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                  ValidateIssuer = false,
                  ValidateAudience = false,
                  ValidateIssuerSigningKey = true,
                  IssuerSigningKey = new SymmetricSecurityKey(secretKEyBytes),
                  ClockSkew = TimeSpan.Zero
                };   
            });


            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("App", new OpenApiInfo { Title = "App API", Version = "App" });
                options.AddSecurityDefinition("bearerAuth", new OpenApiSecurityScheme
                {
                    Description = "JWT containing userid claim",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT"
                });
                var security =
                    new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Id = "bearerAuth",
                                    Type = ReferenceType.SecurityScheme
                                },
                                UnresolvedReference = true
                            },
                            new List<string>()
                        }
                    };
                options.AddSecurityRequirement(security);
                // using System.Reflection;
                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

            });
            services.AddDistributedMemoryCache();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            ConfigureCoreAndRepositoryService(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/App/swagger.json", "App API");
                c.SwaggerEndpoint("/swagger/Web/swagger.json", "Web API");
                c.RoutePrefix = string.Empty;
                c.OAuthUseBasicAuthenticationWithAccessCodeGrant();
              // c.DocExpansion(DocExpansion.None); Cloase tabs Swagger
                c.DefaultModelsExpandDepth(-1);
            });


            app.UseAuthentication();
            app.UseSession();
            app.UseRouting();
            app.UseAuthorization();
            app.UseCors("CorsPolicy");
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Login}/{action=LoginWeb}/{id?}");
            });
            app.UseStaticFiles();

            // Using service Get Ip From customer 
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor |
                ForwardedHeaders.XForwardedProto
            });


        }
        private void ConfigureCoreAndRepositoryService(IServiceCollection services)
        {

            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            // basse
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(IServices<>), typeof(BaseService<>));

            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICustomerService, CustomerService>();

            services.AddScoped<IMaterialRepository, MaterialRepository>();
            services.AddScoped<IMaterialServices, MaterialService>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserServices, UserServices>();

        }
    }
}
