using System.Reflection;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using InTech.Application.Handlers.CommandHandlers;
using InTech.Core.Repositories.Command;
using InTech.Core.Repositories.Command.Base;
using InTech.Core.Repositories.Query;
using InTech.Core.Repositories.Query.Base;
using InTech.Infrastructure.Data;
using InTech.Infrastructure.Repositories.Command;
using InTech.Infrastructure.Repositories.Command.Base;
using InTech.Infrastructure.Repositories.Query;
using InTech.Infrastructure.Repositories.Query.Base;

namespace InTech.API
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

            services.AddControllers();

            // Configure for SqlServer
            services.AddDbContext<ProductsContext>(
                options => options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")
                )
            );

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "InTech.API", Version = "v1" });
            });

            // Register dependencies
            services.AddAutoMapper(typeof(Startup));
            services.AddMediatR(typeof(CreateProductHandler).GetTypeInfo().Assembly);
            services.AddScoped(typeof(IQueryRepository<>), typeof(QueryRepository<>));
            services.AddTransient<IProductQueryRepository, ProductQueryRepository>();
            services.AddTransient<IUserQueryRepository, UserQueryRepository>();
            services.AddScoped(typeof(ICommandRepository<>), typeof(CommandRepository<>));
            services.AddTransient<IProductCommandRepository, ProductCommandRepository>();
            services.AddTransient<IUserCommandRepository, UserCommandRepository>();

            //Agregamos Cors
            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "InTech.API v1"));
            }

            app.UseCertificateForwarding();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            //Habilitamos CORS para todos los orígenes, encabezados y métodos (GET,PUT,POST,DELETE,etc)
            app.UseCors(options => options
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
