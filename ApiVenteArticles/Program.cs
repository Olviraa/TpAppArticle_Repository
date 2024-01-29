using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

using ApiVenteArticles.Interface;
using ApiVenteArticles.Repositories;
using ApiVenteArticles.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Je pr�cise ma connection string qui s'appelle DefaultConnection dans mon fichier appsettings.json
builder.Services.AddDbContext<ApiDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// J'indique quels sont les service qui peuvent �tre inject�s dans mes controllers
builder.Services.AddScoped<IProduitService, ProduitService>();
//builder.Services.AddScoped<CategoryService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
