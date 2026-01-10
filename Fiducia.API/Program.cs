using Fiducia.Application.DTOs;
using Fiducia.Application.Interfaces;
using Fiducia.Application.Services;
using Fiducia.Domain.Interfaces;
using Fiducia.Domain.Services;
using Fiducia.Infrastructure.Persistence;
using Fiducia.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using Fiducia.API.Exceptions;
using Fiducia.Application.Validators;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddProblemDetails(configure =>
{
    configure.CustomizeProblemDetails = context =>
    {
        context.ProblemDetails.Extensions.TryAdd("requestId", context.HttpContext.TraceIdentifier);
    };
});
builder.Services.AddExceptionHandler<ValidationExceptionHandler>();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

// DbContext.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<FiduciaDbContext>(options =>
    options.UseSqlServer(connectionString));

//DI.
builder.Services.AddScoped<ILoanRepository, LoanRepository>();
builder.Services.AddScoped<ILoanService, LoanService>();
builder.Services.AddScoped<IAmortizationCalculator, AmortizationCalculator>();
builder.Services.AddValidatorsFromAssemblyContaining<LoanRequestValidator>();
//builder.Services.AddFluentValidation

// Add services to the container.
builder.Services.AddControllers();
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

app.UseExceptionHandler();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
