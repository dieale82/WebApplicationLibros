using DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Queries;
using System.Text.Json.Serialization;
using WebApplicationLibrosAPI.ApiKeyManager;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<LibrosInventoryContext>(x => x.UseSqlServer(connectionString));

// Register the dependencies
builder.Services.AddScoped<IGetBookList, GetBookList>();
builder.Services.AddScoped<ICreateBook, CreateBook>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

//Register the API key manager
app.UseMiddleware<ApiKeyManager>();

app.MapControllers();

app.Run();
