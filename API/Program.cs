using System.Data.Common;
using API.Helpers;
using API.Middleware;
using Core.Interface;
using Infrastructure.Data;
using Infrastructure.Services;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddDbContext<StoreContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("SabaybuyDb"));
});
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddAutoMapper(typeof(MappingProfiles));
builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", policy =>
    {
        policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:5110", "https://localhost:5110", "http://localhost:4200");
    });
});
builder.Services.AddSingleton<IConnectionMultiplexer> ( config =>
{
    var conString = builder.Configuration.GetConnectionString("Redis");
    if(conString == null) throw new Exception("Cannot get redis connection string");
    var configuration = ConfigurationOptions.Parse(conString, true);
    return ConnectionMultiplexer.Connect(configuration);

});

builder.Services.AddSingleton<ICardService, CardService>();

var app = builder.Build();
app.UseMiddleware<ExceptionMiddleware>();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
