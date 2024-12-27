using Microsoft.OpenApi.Models;
using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);

// path of Log
var log_path = "C:\\Users\\User\\Desktop\\Work\\Backend\\ASP_NET_COre\\company\\Company\\logs";
Directory.CreateDirectory(log_path);

Log.Logger = new LoggerConfiguration().WriteTo.File(
     path: $"{log_path}\\log-.txt", // File with rolling pattern
     outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}",
     rollingInterval: RollingInterval.Day, // Creates a new log file daily
     restrictedToMinimumLevel: LogEventLevel.Information
    ).CreateLogger();

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddCors(O =>
{
    O.AddPolicy("CorsPolicy", builder =>
    builder.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo   { Title ="Company", Version ="V1"}));

try
{
    Log.Information("Application is starting.");
    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Company v1") );
    }

    app.UseHttpsRedirection();

    app.UseCors("CorsPolicy");

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch(Exception ex)
{
    Log.Fatal(ex, "Application failed to start.");
}
finally
{
    Log.CloseAndFlush();
}
