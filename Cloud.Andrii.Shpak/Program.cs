using Cloud.Andrii.Shpak.Controllers;
using Cloud.Andrii.Shpak.Extensions;
using FluentValidation;
using MediatR;
using MongoDB.Driver;
using MongoDB.Entities;

var builder = WebApplication.CreateBuilder(args);

builder.AddLogging();

var assembly = typeof(Program).Assembly;
builder.Services.AddMediatR(assembly);
builder.Services.AddValidatorsFromAssembly(assembly);

builder.Services.AddScoped(_ => new DBContext("cloud",
    MongoClientSettings.FromConnectionString(
        ("mongodb+srv://andrii_shpak:coffad-gecby6-dohkEm@lessons.tozt0.mongodb.net/admin?retryWrites=true&w=majority"))));

var app = builder.Build();
app.AddCourses();
app.MapGet("/", () => "Hello World!");

app.Run();