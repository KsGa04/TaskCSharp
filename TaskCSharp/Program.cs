using Microsoft.Extensions.Configuration;
using TaskCSharp.Controllers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using TaskCSharp;
using System.Threading;

internal class Program
{
    private static SemaphoreSlim _semaphore;
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
        // Add services to the container.
        builder.Services.Configure<BlacklistOptions>(configuration.GetSection("Blacklist"));
        builder.Services.AddHttpClient();
        builder.Services.AddControllers();

        builder.Services.AddSingleton<RequestCounterService>();
        //var config = builder.Configuration.GetSection("Settings");
        //int parallelLimit = config.GetValue<int>("ParallelLimit");
        //_semaphore = new SemaphoreSlim(parallelLimit, parallelLimit);

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}