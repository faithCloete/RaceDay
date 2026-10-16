using Microsoft.EntityFrameworkCore;
using RaceDay.API.Data;
using RaceDay.API.Services;
    
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

//register password service
builder.Services.AddScoped<PasswordService>();

// Add services to the container
builder.Services.AddDbContext<RaceDayContext>(options =>
options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")));



builder.Services.AddControllers();
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

app.UseHttpsRedirection();

app.UseSession();

app.UseAuthorization();

//DATABASE TEST END POINT

app.MapGet("/api/health/database", async (RaceDayContext context) =>
{
    bool connected = await context.Database.CanConnectAsync();

    return connected
        ? Results.Ok("Connected to the RaceDay database!")
        : Results.Problem("Could not connect to the RaceDay database.");
});

app.MapControllers();

app.Run();
