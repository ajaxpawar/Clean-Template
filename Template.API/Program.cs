using Microsoft.EntityFrameworkCore;
using Template.Application;
using Template.API.Middeleware;
using Template.Infrastructure.Extensions;
using Template.API.Extensions;
using Microsoft.AspNetCore.ResponseCompression;
using Serilog;

string connection_string = string.Empty;

var builder = WebApplication.CreateBuilder(args);

//add appseting configuration
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

connection_string = builder.Configuration.GetConnectionString("DefaultConnection");

//add application DI
builder.Services.AddApplication();

//add context
builder.Services.AddContextDI(connection_string);

// Add services to the container.
builder.Services
    .AddFeatureUseCases()
    .AddFeatureLocalServices();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerDI();

//httpcontext register
builder.Services.AddHttpContextAccessor();




builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

builder.Services.AddResponseCompression(options =>
{
    options.EnableForHttps = true;
    options.Providers.Add<GzipCompressionProvider>();
});

builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration)
) ;

var app = builder.Build();

app.UseMiddleware<ErrorHandlingMiddleware>();
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
