using BoxTI.DojoIntegrado.API.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Configuration
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", true, true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json")
    .AddEnvironmentVariables();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowEveryone",
        builder =>
        {
            builder.AllowAnyHeader();
            builder.AllowAnyMethod();
            builder.AllowAnyOrigin();
        });
});

builder.Services.AddAuthConfig(builder.Configuration);
builder.Services.AddServicesConfig();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddJwtConfig(builder.Configuration);
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

app.UseCors("AllowEveryone");

app.UseAuthConfig();

app.MapControllers();

app.Run();
