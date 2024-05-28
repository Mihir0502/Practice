using WebApplication1.Repos;
using WebApplication1.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddSingleton<DapperContext>();
//builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddControllers(); 


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
