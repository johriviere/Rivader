using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Rivader.Domain.Collections;
using Rivader.Domain.Core;
using Rivader.Domain.Services;
using Rivader.Infra.Repositories;
using Rivader.Infra.Storage;

namespace Rivader.Web
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
            services.AddDbContext<RivaderDbContext>(x => x.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                assembly => assembly.MigrationsAssembly(typeof(RivaderDbContext).Assembly.FullName)));

            services.AddControllers()
                //https://stackoverflow.com/questions/59199593/net-core-3-0-possible-object-cycle-was-detected-which-is-not-supported
                .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.TryAddScoped<IUnitOfWork, UnitOfWork>();

            ConfigureCore(services);
        }

        private void ConfigureCore(IServiceCollection services)
        {
            services.AddScoped<ISpaceInvadersService, SpaceInvadersService>();
            services.AddScoped<ISpaceInvadersRepository, SpaceInvadersRepository>();
            services.AddScoped<ITranslationsService, TranslationsService>();
            services.AddScoped<ITranslationsRepository, TranslationsRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
