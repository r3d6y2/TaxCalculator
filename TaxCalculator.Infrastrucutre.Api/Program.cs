using Microsoft.EntityFrameworkCore;
using TaxCalculator.DataAccess.Dummy.Repositories;
using TaxCalculator.DataAccess.SqlDb;
using TaxCalculator.DataAccess.SqlDb.Repositories;
using TaxCalculator.Domain.Services.Interfaces.Repositories;
using TaxCalculator.Domain.Services.Interfaces;
using TaxCalculator.Infrastructure.Api.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var configurationBuilder = new ConfigurationBuilder();
configurationBuilder.AddJsonFile("appsettings.json");
var configuration = configurationBuilder.Build();

// Add DI for repositories and automapper profiles
builder.Services
    //.AddTransient<ITaxBandRepository, DummyTaxBandRepository>()
    .AddTransient<ITaxBandRepository, TaxBandSqlRepository>()
    .Scan(scan =>
        scan.FromAssembliesOf(typeof(ICommandHandler<,>))
            .AddClasses(classes => classes.AssignableTo(typeof(ICommandHandler<,>)))
            .AsSelf()
            .AsImplementedInterfaces());

// Allow cross policy support to test application locally
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin", policyBuilder =>
    {
        policyBuilder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

// Register controllers and register filters in options
builder.Services.AddControllers(options =>
{
    options.Filters.Add<ExceptionHandlerFilter>();
});

builder.Services.AddDbContext<TaxDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("TaxDb")));


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services
    .AddAutoMapper(config =>
    {
        config.AllowNullCollections = true;
        config.AllowNullDestinationValues = true;
    }, AppDomain.CurrentDomain.GetAssemblies())
    .AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowOrigin");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();