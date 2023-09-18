using Microsoft.EntityFrameworkCore;
using RegisterPeople.Application.Interface;
using RegisterPeople.Application.Main;
using RegisterPeopleManagement.Infra.Data.DbContextEntity;
using RegisterPeopleManagement.Infra.Interface;
using RegisterPeopleManagement.Infra.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddScoped<IPeopleApplication, PeopleApplication>();
builder.Services.AddScoped<IPeopleRepository, PeopleRepository>();
builder.Services.AddScoped<IPhonesRepository, PhonesRepository>();
builder.Services.AddScoped<IEmailAddressRepository, EmailAddressRepository>();
builder.Services.AddScoped<IAddressRepository, AddressRepository>();

builder.Services.AddDbContext<DataContext>(options =>
{
    string testAssemblyName = "Microsoft.TestPlatform";

    var result = AppDomain.CurrentDomain.GetAssemblies()
        .Any(a => a.FullName.StartsWith(testAssemblyName));
    if (!result)
    {
        var connectionEnvString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
        var connectionString = string.IsNullOrEmpty(connectionEnvString) ? builder.Configuration.GetConnectionString("DefaultConnection") : connectionEnvString;
        options.UseSqlServer(connectionString, sqlServerOptionsAction: sqlOptions =>
        {
            sqlOptions.EnableRetryOnFailure(
            maxRetryCount: 2,
            maxRetryDelay: TimeSpan.FromSeconds(50),
            errorNumbersToAdd: null);
        });
    }
    else
    {
        options = new DbContextOptionsBuilder<DataContext>().UseInMemoryDatabase(databaseName: "Projects");
    }
});

builder.Services.AddSwaggerGen();
builder.Services.AddMvc();

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

namespace RegisterPeople
{
    public partial class Program
    { }
}