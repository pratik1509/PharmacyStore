using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Common.Mongo.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PharmacyStore.Framework.DependencyRegister;
using PharmacyStore.Services;
using PharmacyStore.Services.Abstraction;
using PharmacyStore.Services.abstractions;
using PharmacyStore.Web.Helpers;
using Swashbuckle.AspNetCore.Swagger;
using FluentValidation.AspNetCore;
using PharmacyStore.Framework.Filters;
using PharmacyStore.Web.Doctor.ViewModels;
using PharmacyStore.Web.Mapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using PharmacyStore.Framework;
using PharmacyStore.Web.Middleware;
using Common.Persistence.SecurityManagement;

namespace PharmacyStore.Web
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
            services.AddMvc(opt =>
                {
                    //opt.Filters.Add(typeof(ModelValidationFilter));
                })
            .AddFluentValidation(fv =>
            {
               // fv.RunDefaultMvcValidationAfterFluentValidationExecutes = false;
                fv.RegisterValidatorsFromAssemblyContaining<Startup>();
            });

            services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            });

            #region mapper configuration

            // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc =>
            {
                //add all your mapper profiles here
                mc.AddProfile(new MapperConfigurations());
            });

            IMapper mapper = mappingConfig.CreateMapper();

            #endregion

            services.AddSingleton(mapper);

            // httpcontext for userclaims
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IUserClaimsService, UserClaims>();
            services.AddTransient<IEncryptionService, EncryptionService>();

            #region request response logger
            
            //request response logger 
            services.AddScoped<IWorkContext, WebWorkContext>();
            services.AddSingleton<IRequestResponseLoggerService, RequestResponseLoggerService>();

            #endregion

            services.AddSingleton<IMongoDbContext>(x =>
            new MongoDbContext(Configuration["Database:ConnectionString"], Configuration["Database:Database"]));

            #region Domain Services

            services.AddSingleton<IDoctorService, DoctorService>();
            services.AddSingleton<IMedicineCategoryService, MedicineCategoryService>();
            //services.AddSingleton<IMedicineService, MedicineService>();

            #endregion

            DIEngineContext.ServiceProvider = services.BuildServiceProvider();

            #region swagger settings

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Pharmacy store API",
                    Description = "Pharmacy store project"
                });

                c.AddFluentValidationRules();

                c.AddSecurityDefinition("Bearer", new ApiKeyScheme()
                {
                    Description = "Authorization header using the Bearer scheme",
                    Name = "Authorization",
                    In = "header",
                    //Type="ApiKey"
                });

            });

            //mongo repository


            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            //swagger settings to enable authorization in swagger
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Pharmacy store API V1");
            });

            app.UseHttpsRedirection();
            app.UseMiddleware<RequestResponseLoggingMiddleware>();
            app.UseMvc();
        }
    }
}
