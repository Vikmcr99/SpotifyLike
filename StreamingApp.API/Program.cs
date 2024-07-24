using Microsoft.EntityFrameworkCore;
using StreamingApp.Application.Account;
using StreamingApp.Repository;
using StreamingApp.Repository.Account;
using StreamingApp.Repository.Streaming;
using StreamingApp.Repository.Transaction;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();
builder.Services.AddDbContext<ApplicationContext>(c =>
{
    c.UseInMemoryDatabase("StreamingApp");
});

builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<BandRepository>();
builder.Services.AddScoped<PlanRepository>();


builder.Services.AddScoped<UserService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
