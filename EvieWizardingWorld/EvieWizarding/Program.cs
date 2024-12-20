using EvieWizarding.Resources;
using EvieWizarding.Controllers;
using EvieWizarding.Models;
using EvieWizarding.Services;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.RateLimiting;
using System.Threading.RateLimiting;
using EvieWizarding.HealthChecks;


namespace EvieWizarding
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();
            builder.Services.AddScoped<SpellsService>();
            builder.Services.AddScoped<SpellsModel>();
            builder.Services.AddScoped<TeachersService>();
            builder.Services.AddScoped<TeachersModel>();
            builder.Services.AddHealthChecks().AddCheck<TeacherHealthCheck>("Winston", failureStatus: HealthStatus.Unhealthy, tags: new[] { "teachers" });
            
            builder.Services.AddRateLimiter(options =>
            {
                options.AddFixedWindowLimiter(policyName: "fixed", options =>
                {
                    options.PermitLimit = 3;
                    options.Window = TimeSpan.FromMinutes(1);
                    options.QueueLimit = 2;
                    options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
                });
            });

            var app = builder.Build();
            app.UseHealthChecks("/health");
            app.UseRateLimiter();
            app.MapGet("/", () => "Hello World!");
            app.MapControllers();

            app.Run();
        }
    }
}
