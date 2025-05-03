using Microsoft.EntityFrameworkCore;
using Warehouse.Storage;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<WearhouseDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("Postgres")), ServiceLifetime.Singleton);

var app = builder.Build();

app.Services.GetRequiredService<WearhouseDbContext>().Database.Migrate();

app.UseSwagger();
app.UseSwaggerUI();

//app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
