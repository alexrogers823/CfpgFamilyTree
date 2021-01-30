using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CfpgFamilyTree.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;

namespace CfpgFamilyTree
{
    public class Startup
    {
        private string _connection = null;
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // var builder = new SqlConnectionStringBuilder(
            //     Configuration.GetConnectionString("TimelineEvents")
            // );

            // builder.Password = Configuration["DbPassword"];
            // _connection = builder.ConnectionString;

            services.AddDbContext<TimelineContext>(opt => opt.UseNpgsql
                (Configuration.GetConnectionString("TimelineEvents")));
            services.AddDbContext<UserContext>(opt => opt.UseNpgsql
                (Configuration.GetConnectionString("Users")));
            services.AddDbContext<MemberContext>(opt => opt.UseNpgsql
                (Configuration.GetConnectionString("Members")));
            services.AddDbContext<CfpgContext>(opt => opt.UseNpgsql
                (Configuration.GetConnectionString("Master")));

            services.AddControllers().AddNewtonsoftJson(s => {
                s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // services.AddScoped<ITimelineRepo, MockTimelineRepo>();
            services.AddScoped<ITimelineRepo, SqlTimelineRepo>();
            services.AddScoped<IUserRepo, SqlUserRepo>();
            services.AddScoped<IMemberRepo, SqlMemberRepo>();
            services.AddScoped<IPhotoRepo, SqlPhotoRepo>();
            services.AddScoped<IArtifactRepo, SqlArtifactRepo>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // app.Run(async (context) =>
            // {
            //     await context.Response.WriteAsync($"DB Connection: {_connection}");
            // });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
