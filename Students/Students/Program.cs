using dotenv.net;
using MongoDB.Driver;
using Students.Models;
using Students.Repository;
using Students.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IStudentService, StudentService>();

var envVars = DotEnv.Read();
var settings = MongoClientSettings.FromConnectionString(envVars["MONGO-CONNECTIONSTRING"]);
var client = new MongoClient(settings);
var database = client.GetDatabase(envVars["MONGO-DATABASE"]);
builder.Services.AddTransient<IStudentRepository>( x=> new StudentRepository(database.GetCollection<Student>("students")));

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
