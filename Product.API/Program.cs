using Microsoft.EntityFrameworkCore;
using Products.API.Data;
using Products.API.Respositories.Implementation;
using Products.API.Respositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//connectionString
builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


//Repository DI
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

#region
builder.Services.AddCors(options =>
{
  options.AddPolicy("cors",
            builder => builder.WithOrigins("https://localhost:4200", "http://localhost:4200")
                               .AllowAnyMethod()
                               .AllowCredentials()
                               .AllowAnyHeader()
                               .Build());
});

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(option =>
{
  option.AllowAnyHeader();
  option.AllowAnyOrigin();
  option.AllowAnyMethod();
});


app.UseAuthorization();

app.MapControllers();

app.Run();
