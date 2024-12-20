using EvieWizarding.Resources;
using EvieWizarding.Controllers;
using EvieWizarding.Models;
using EvieWizarding.Services;
using Microsoft.Extensions.Diagnostics.HealthChecks;
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
            builder.Services.AddScoped<TeacherService>();
            builder.Services.AddScoped<TeacherModel>();
            builder.Services.AddHealthChecks().AddCheck<TeacherHealthCheck>("Winston", failureStatus: HealthStatus.Unhealthy, tags: new[] { "teachers" });
            var app = builder.Build();
            app.MapControllers();
            app.UseHealthChecks("/health");
            //app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }
}
