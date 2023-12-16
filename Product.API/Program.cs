using Microsoft.EntityFrameworkCore;

using PigeonPad.Services;

using Product.API.Services;
using Newtonsoft.Json;
using Products.API.Data;
using Products.API.Respositories.Implementation;
using Products.API.Respositories.Interfaces;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

using Swashbuckle.AspNetCore.SwaggerGen;

using System.IO;
using System.Reflection;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<SaleInvoiceService>();
builder.Services.AddScoped<CategoryService>();


builder.Services.AddControllers()
  .AddNewtonsoftJson(x =>
{
  x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
  x.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.None;
})
  ;
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//connectionString
builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


//Repository DI
builder.Services.AddScoped<cUnitOfWork>();

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
