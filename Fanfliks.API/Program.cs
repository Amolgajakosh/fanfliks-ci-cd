var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();  // Registers [ApiController] endpoints

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapControllers();

app.Run();
