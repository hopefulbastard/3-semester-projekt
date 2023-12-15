using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer;
using _3_Semester_Class_Library;

//Bjørn + Magnus + Milo

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(option =>
            option.AddPolicy("Allow All",
            builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader())
            );

var optionsBuilderSikkerhedsLog = new DbContextOptionsBuilder<SikkerhedsLogDBContext>();
optionsBuilderSikkerhedsLog.UseSqlServer("Data Source = mssql5.unoeuro.com; Initial Catalog = bbksolutions_dk_db_databasen; User ID = bbksolutions_dk; Password=cmfbeAtrkR5zBaF426x3;Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent = ReadWrite; MultiSubnetFailover=False");
SikkerhedsLogDBContext SikkerhedsContext = new SikkerhedsLogDBContext(optionsBuilderSikkerhedsLog.Options);
builder.Services.AddSingleton<SikkerhedsLogRepositoryDB>(new SikkerhedsLogRepositoryDB(SikkerhedsContext));

var optionsBuilderSMSLog = new DbContextOptionsBuilder<SMSLogDBContext>();
optionsBuilderSMSLog.UseSqlServer("Data Source = mssql5.unoeuro.com; Initial Catalog = bbksolutions_dk_db_databasen; User ID = bbksolutions_dk; Password=cmfbeAtrkR5zBaF426x3;Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent = ReadWrite; MultiSubnetFailover=False");
SMSLogDBContext SMSContext = new SMSLogDBContext(optionsBuilderSMSLog.Options);
builder.Services.AddSingleton<SMSLogRepositoryDB>(new SMSLogRepositoryDB(SMSContext));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.UseCors("Allow All");

app.MapControllers();

app.Run();
