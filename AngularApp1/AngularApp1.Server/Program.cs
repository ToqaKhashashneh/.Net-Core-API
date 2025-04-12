using AngularApp1.Server.DataService;
using AngularApp1.Server.IDataService;
using AngularApp1.Server.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("YourConnectionString")));

builder.Services.AddScoped<IDataService, DataService>();

//Cors == Allow all origin 
builder.Services.AddCors(
    options => options.AddPolicy(
        "Develop", options => //develop is the name of the policy that follow cors
                    {
                        options.AllowAnyOrigin(); //Or for specific options.WithOrigins("http://localhost:4200")
                        options.AllowAnyMethod();
                        options.AllowAnyHeader();
                    }
        )
    );

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors("Develop"); //use the cors policy

app.MapFallbackToFile("/index.html");

app.Run();
