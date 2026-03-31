var builder = WebApplication.CreateBuilder(args);

// Servicios
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