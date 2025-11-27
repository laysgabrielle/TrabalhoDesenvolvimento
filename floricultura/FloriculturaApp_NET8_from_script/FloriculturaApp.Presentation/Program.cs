using FloriculturaApp.Application.Interfaces;
using FloriculturaApp.Application.Services;
using FloriculturaApp.Domain.Entities;
using FloriculturaApp.Domain.Interfaces;
using FloriculturaApp.Infrastructure.Data;
using FloriculturaApp.Infrastructure.Repositories;
using Mapster;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// DbContext
builder.Services.AddDbContext<FloriculturaContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")
                     ?? "Data Source=floricultura.db"));

// Repositórios genéricos
builder.Services.AddScoped<IGenericRepository<Category>>(provider =>
    new GenericRepository<Category>(provider.GetRequiredService<FloriculturaContext>()));

builder.Services.AddScoped<IGenericRepository<Product>>(provider =>
    new GenericRepository<Product>(provider.GetRequiredService<FloriculturaContext>()));

// Serviços
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();

// Mapster
builder.Services.AddMapster();

// MVC
builder.Services.AddControllersWithViews();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Criar banco e rodar migrations automaticamente
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<FloriculturaContext>();
    db.Database.Migrate();

    // Seed somente se estiver vazio
    if (!db.Categories.Any())
    {
        db.Categories.AddRange(new[]
        {
            new Category { Name = "Rosas" },
            new Category { Name = "Orquídeas" },
            new Category { Name = "Arranjos" }
        });
        db.SaveChanges();
    }
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllers();

app.Run();
