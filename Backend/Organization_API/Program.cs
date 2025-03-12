

using Microsoft.Extensions.Configuration;


var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add controllers services
builder.Services.AddControllers();

//Add Dbcontext 
builder.Services.ApplicationPersisitenceRegistration(builder.Configuration);
builder.Services.AddApplicationRegistration();

//AddSerilog..
// Add services to the container.
var logger = new LoggerConfiguration()
  .ReadFrom.Configuration(configuration)
  .Enrich.FromLogContext()
  .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//controller middleware
app.MapControllers();
app.Run();

