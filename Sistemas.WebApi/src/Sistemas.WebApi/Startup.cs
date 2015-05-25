//-----------------------------------------------------------//
//                                                           //
//  Gino Llerena --- https://pe.linkedin.com/in/ginollereta  //
//                                                           //
//-----------------------------------------------------------//

using System.Linq;
using Microsoft.AspNet.Builder;
using Microsoft.Framework.DependencyInjection;
using Sistemas.WebApi.Models;
using Microsoft.AspNet.Mvc;
using Sistemas.WebApi.Repositorios.Interfaces;
using Sistemas.WebApi.Repositorios;
using Newtonsoft.Json.Serialization;
using Microsoft.Framework.ConfigurationModel;
using Microsoft.AspNet.Hosting;
using Microsoft.Data.Entity;

namespace Sistemas.WebApi
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            Configuration = new Configuration(env.WebRootPath.Substring(0, env.WebRootPath.Length - 8))
                        .AddJsonFile("config.json")
                        .AddEnvironmentVariables(); //All environment variables in the process's context flow in as configuration values.
        }

        public IConfiguration Configuration { get; private set; }

        // This method gets called by a runtime.
        // Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddEntityFramework()
            .AddSqlServer()
            .AddDbContext<SistemaContext>((options =>
                        options.UseSqlServer(Configuration.Get("Data:DefaultConnection:ConnectionString"))));

            services.AddCors();
            services.ConfigureCors(config => config.AddPolicy("Any",
                policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

            services.AddMvc().Configure<MvcOptions>(options =>
            {
                options.OutputFormatters
                           .Where(x => x.GetType() == typeof(JsonOutputFormatter))
                           .Select(f => f as JsonOutputFormatter)
                           .First()
                           .SerializerSettings
                           .ContractResolver = new CamelCasePropertyNamesContractResolver();
            });

            services.AddScoped<IProductoRepositorio, ProductoRepositorio>();
            services.AddScoped<IUnidadRepositorio, UnidadRepositorio>();
        }

        public void Configure(IApplicationBuilder app) //, IHostingEnvirnment env)
        {
            var sampleData = ActivatorUtilities.CreateInstance<SistemaContextInicialice>(app.ApplicationServices);
            sampleData.InitializeData();

            app.UseCors("Any");

            app.UseMvc();
        }
    }
}
