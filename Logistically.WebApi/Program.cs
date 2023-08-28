using Logistically.WebApi.Data.Contexts;
using Logistically.WebApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PackageDbContext>();

builder.Services.AddScoped<PackageService>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
