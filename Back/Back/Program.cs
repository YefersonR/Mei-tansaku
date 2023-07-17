using Core.Application;
using Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddRepositories(builder.Configuration);
builder.Services.AddApplicationLayer(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddHealthChecks();

builder.Services.AddCors(options =>
{
    options.AddPolicy("Tansaku_Cors", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseCors("Tansaku_Cors");
app.UseAuthentication();
app.UseAuthorization();
app.UseHealthChecks("/health");
app.MapControllers();

app.Run();
