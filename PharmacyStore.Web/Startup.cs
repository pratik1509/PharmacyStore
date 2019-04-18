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
using PharmacyStore.Web.Mapper.DoctorMapper;
using Swashbuckle.AspNetCore.Swagger;
using FluentValidation.AspNetCore;
using PharmacyStore.Web.DoctorVm.ViewModels;
using PharmacyStore.Framework.Filters;

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
                    opt.Filters.Add(typeof(ModelValidationFilter));
                })
            .AddFluentValidation(fv =>
            {
                fv.RunDefaultMvcValidationAfterFluentValidationExecutes = false;
                fv.RegisterValidatorsFromAssemblyContaining<AddUpdateDoctorVmValidator>();
            });

            #region mapper configuration

            // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc =>
            {
                //add all your mapper profiles here
                mc.AddProfile(new DoctorMapper());
            });

            IMapper mapper = mappingConfig.CreateMapper();

            #endregion

            services.AddSingleton(mapper);

            var mongoDbContext = new MongoDbContext(Configuration["AppSettings:DbConnectionString"], Configuration["AppSettings:DbName"]);
            services.AddSingleton(typeof(IMongoDbContext), mongoDbContext);

            services.AddSingleton<IUserClaimsService, UserClaimsService>();
			services.AddSingleton<IDoctorServices, DoctorService>();
            
            // httpcontext for userclaims
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IUserClaimsService, UserClaims>();

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

            });

            //mongo repository
            services.AddSingleton<Common.Mongo.Repository.IMongoDbContext>(x =>
            new Common.Mongo.Repository.MongoDbContext(Configuration["Database:ConnectionString"],
            Configuration["Database:Database"]));

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
            app.UseMvc();
        }
    }
}
