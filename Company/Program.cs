using AutoMapper;
using Company.Configuration;
using Company.Data;
using Company.Irepository;
using Company.Repository;
using Microsoft.EntityFrameworkCore;
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
// Ignores the link between in tables. USE NewtonsoftJson
builder.Services.AddControllers().AddNewtonsoftJson(
    o => o.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("sqlConnection"))) ;
builder.Services.AddCors(O =>
{
    O.AddPolicy("CorsPolicy", builder =>
    builder.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());
});

// Configuring AutoMapper
builder.Services.AddAutoMapper(typeof(MapperInitializer));
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();



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
