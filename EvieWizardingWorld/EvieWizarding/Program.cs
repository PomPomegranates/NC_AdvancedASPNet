using EvieWizarding.Resources;
using EvieWizarding.Controllers;
using EvieWizarding.Models;
using EvieWizarding.Services;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
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
            var app = builder.Build();
            app.MapControllers();
            app.UseHealthChecks("/health");
            //app.MapHealthChecks("/health", new HealthCheckOptions {
            //    ResponseWriter = async (context, report) =>
            //    {
            //        context.Response.ContentType = "application/json";
            //        context.Response.WriteAsync(System.Text.Json.JsonSerializer.Serialize(response));
            //    })
            app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }
}
