using System;
using System.Threading;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Driver.Core.Clusters;
using server.Models;
using server.Services;

namespace server
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
            var dbSettings = Configuration.GetSection(nameof(SRDBSettings));
            services.Configure<SRDBSettings>(dbSettings);
            services.AddSingleton<ISRDBSettings>(sp => sp.GetRequiredService<IOptions<SRDBSettings>>().Value);
            services.AddSingleton<UserService>();

            testDBServerConnection();

            services.AddControllers().AddNewtonsoftJson();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        public async void testDBServerConnection()
        {
            var startTime = DateTime.UtcNow;
            var client = new MongoClient($"mongodb://localhost/?connectTimeoutMS=5000");
            try
            {
                using (var timeoutCancellationTokenSource = new CancellationTokenSource(TimeSpan.FromMilliseconds(1800)))
                {
                    await client.ListDatabasesAsync(timeoutCancellationTokenSource.Token);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("[OK] DB connection.");
                }
            }
            catch (OperationCanceledException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[FAILED] DB connection.");
            }
            Console.ResetColor();

        }
    }
}
