using Claim.Respository;
using Claim.Service;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using YCompany.Library.RabbitMQ.Infra.IOC;
using YCompany.Microservices.Claim.CommandHandlers;
using YCompany.Microservices.EventSourcing.Commands.Claim;

namespace Claim
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
            services.AddDbContext<ClaimDbContext>(options => options.UseSqlServer(Configuration["SqlConnection"]));
            services.AddTransient<ClaimRepository>();
            services.AddTransient<ClaimService>();
            services.AddMediatR(typeof(Startup).GetTypeInfo().Assembly);
            services.AddTransient<IRequestHandler<RegisterClaimCommand, bool>, RegisterClaimCommandHandler>();
            services.RegisterEventBusServices(Configuration);      

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

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
