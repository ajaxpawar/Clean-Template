using Microsoft.EntityFrameworkCore;
using Template.Application.Configuration.Data;
using Template.Application.Services.Local_Services;
using Template.Infrastructure.Persistence;
using Template.Application;
using Template.Infrastructure.Services.Local_Services;
using Template.Application.Features.Movie.Usecase;
using Template.API.Middeleware;

string connection_string = string.Empty;

var builder = WebApplication.CreateBuilder(args);

//add appseting configuration
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

connection_string = builder.Configuration.GetConnectionString("DefaultConnection");

//add DI
builder.Services.AddApplication();

//register dbcontext 
builder.Services.AddDbContext<TemplateDbContext>(options =>
    options.UseSqlServer(connection_string));
builder.Services.AddScoped<IApplicationDbContext>(provider => provider.GetService<TemplateDbContext>());

//Usecase Register
builder.Services.AddScoped<IMovieUsecases, MovieUsecases>();


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//httpcontext register
builder.Services.AddHttpContextAccessor();

//service register 
builder.Services.AddScoped<ICurrentUserService, CurrentUserService>();
builder.Services.AddScoped<IDateTimeService, DateTimeService>();



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
