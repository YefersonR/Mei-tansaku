using Core.Application;
using Infrastructure.Persistence;
using Infraestructure.Identity;
using Infraestructure.Identity.Entities;
using Infraestructure.Identity.Seeds;
using Infrastructure.Shared;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAuthentication();
builder.Services.AddShareInfrastructure(builder.Configuration);
builder.Services.AddIdentityInfrastructure(builder.Configuration);
builder.Services.AddRepositories(builder.Configuration);
builder.Services.AddApplicationLayer(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddHealthChecks();


var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

        await DefaultRoles.Seed(userManager, roleManager);
        await DefaultOwner.Seed(userManager, roleManager);
        await DefaultUser.Seed(userManager, roleManager);
    }
    catch (Exception ex)
    {

    }
}


// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.UseHealthChecks("/health");
app.MapControllers();


app.Run();
