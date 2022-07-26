using APIProject.Data;
using APIProject.Helper;
using APIProject.Repository;
using APIProject.Repository.IRepository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIProject
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DBContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DB")));
            services.AddControllers().AddNewtonsoftJson();
            services.AddTransient<IListModelRepository, ListModelRepository>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "APIProject", Version = "v1" });
            });
            services.AddControllers();

            var config = new AutoMapper.MapperConfiguration(options =>
            {

                options.AddProfile(new ListMapper());
            });
            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        }
       

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
          

            app.UseSwagger();
         
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

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
