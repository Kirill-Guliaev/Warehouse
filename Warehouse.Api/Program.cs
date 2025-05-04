using Microsoft.EntityFrameworkCore;
using Warehouse.Api.Middlewares;
using Warehouse.Domain.UseCases.SignIn;
using Warehouse.Domain.UseCases.SignOn;
using Warehouse.Storage;
using Warehouse.Storage.Storages;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<WarehouseDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("Postgres")), ServiceLifetime.Singleton);

builder.Services
     .AddScoped<ISignOnStorage, SignOnStorage>()
     .AddScoped<ISignInStorage, SignInStorage>()
     ;

builder.Services
    .AddScoped<ISignOnUseCase, SignOnUseCase>()
    .AddScoped<ISignInUseCase, SignInUseCase>()
    ;

var app = builder.Build();

app.Services.GetRequiredService<WarehouseDbContext>().Database.Migrate();

app.UseSwagger();
app.UseSwaggerUI();

app.UseMiddleware<AuthenticationMiddleware>();

//app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
