

using ApiBackendCsharp.Services;
var builder = WebApplication.CreateBuilder(args);

// Servicios
//builder.Services.AddSingleton<IPeopleService, ApiBackendCsharp.People2Service>();
builder.Services.AddKeyedSingleton<IPeopleService, ApiBackendCsharp.PeopleService>("PeopleService");
builder.Services.AddKeyedSingleton<IPeopleService, ApiBackendCsharp.People2Service>("People2Service");
    

builder.Services.AddKeyedSingleton<IRandomServices, ApiBackendCsharp.Services.RandomServices>("randomSingleton");
builder.Services.AddKeyedScoped<IRandomServices, ApiBackendCsharp.Services.RandomServices>("randomScoped");
builder.Services.AddKeyedTransient<IRandomServices, ApiBackendCsharp.Services.RandomServices>("randomTransient");

builder.Services.AddControllers();        // Registra los controladores
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();         // Genera JSON de Swagger
    app.UseSwaggerUI();       // Genera la UI visual
}

app.UseHttpsRedirection();
app.MapControllers();                     // Mapea las rutas de los controladores

// Tu endpoint
var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
