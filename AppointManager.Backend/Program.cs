using AppointManager.Backend.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;



var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ApplicationDbContext>(options => {

    options.UseNpgsql(builder.Configuration.GetConnectionString("Default"));
});

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
builder.Services.AddControllers();




var app = builder.Build();

app.MapControllers();
app.MapGet("/", () => "Hello World!");

app.Run();
