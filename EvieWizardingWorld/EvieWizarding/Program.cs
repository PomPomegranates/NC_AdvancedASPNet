using EvieWizarding.Resources;
using EvieWizarding.Controllers;
using EvieWizarding.Models;
using EvieWizarding.Services;
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
            var app = builder.Build();
            app.MapControllers();
            //app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }
}
