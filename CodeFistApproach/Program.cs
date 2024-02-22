using CodeFistApproach.Entity;
using CodeFistApproach.Repository;
using CodeFistApproach.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<BookDBContext>(db => db.UseSqlServer(builder.Configuration.GetConnectionString("OurBookConnectionString")), ServiceLifetime.Singleton);

builder.Services.AddControllers();
builder.Services.AddScoped<IBooksService,BooksService>();
builder.Services.AddScoped<IBookRepository, BooksRepository>();
builder.Services.AddScoped<IAuthorsRepository, AuthorsRepository>();
builder.Services.AddScoped<IAuthorsService, AuthorsService>();

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

app.UseRouting(); 

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
