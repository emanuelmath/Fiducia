using Fiducia.API.Exceptions;
using Fiducia.Application.DTOs;
using Fiducia.Application.Factories;
using Fiducia.Application.Interfaces;
using Fiducia.Application.Services;
using Fiducia.Application.Validators;
using Fiducia.Domain.Interfaces;
using Fiducia.Domain.Services;
using Fiducia.Infrastructure.Persistence;
using Fiducia.Infrastructure.Repositories;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddProblemDetails(configure =>
{
    configure.CustomizeProblemDetails = context =>
    {
        context.ProblemDetails.Extensions.TryAdd("requestId", context.HttpContext.TraceIdentifier);
    };
});
builder.Services.AddExceptionHandler<ValidationExceptionHandler>();
builder.Services.AddExceptionHandler<TypeOfAmortizationExceptionHandler>();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

// DbContext.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<FiduciaDbContext>(options =>
    options.UseSqlServer(connectionString));

//DI.
builder.Services.AddScoped<ILoanRepository, LoanRepository>();
builder.Services.AddScoped<ILoanService, LoanService>();
builder.Services.AddScoped<FrenchAmortizationCalculator>();
builder.Services.AddScoped<IAmortizationFactory, AmortizationFactory>();
builder.Services.AddValidatorsFromAssemblyContaining<LoanRequestValidator>();


// Add services to the container.
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        // Show the value of enums.
        options.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
    }); 
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Fiducia",
        Version = "v1",
        Description = @"A backend financial engine designed for loan calculation logic
                        and scalable financial operations."
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
