using FluentValidation.AspNetCore;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using FluffyLinks.Models.Database;
using FluffyLinks.Business;
using FluffyLinks.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(configure =>
{
    configure.Filters.Add(new ProducesResponseTypeAttribute(500));
    configure.Filters.Add(new ProducesResponseTypeAttribute(typeof(ValidationProblemDetails), 400));
})
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
        options.SerializerSettings.Converters.Add(new StringEnumConverter());
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "localCors",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
        });
});

builder.Services.Configure<MongoDbSettings>(
    builder.Configuration.GetSection("MongoDbSettings"));

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddScoped<INotesBal, NotesBal>();

builder.Services.AddScoped<INoteRepository, NoteRepository>();

var app = builder.Build();


app.UseSwagger();

app.UseSwaggerUI();

app.UseCors("localCors");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
