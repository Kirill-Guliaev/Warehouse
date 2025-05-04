using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Warehouse.Api;
using Warehouse.Api.Authentication;
using Warehouse.Api.Middlewares;
using Warehouse.Domain.Authorization;
using Warehouse.Domain.UseCases.GetUserItems;
using Warehouse.Domain.UseCases.RegisterItem;
using Warehouse.Domain.UseCases.SignIn;
using Warehouse.Domain.UseCases.SignOn;
using Warehouse.Storage;
using Warehouse.Storage.Storages;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => c.EnableAnnotations());
builder.Services.AddDbContext<WarehouseDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("Postgres")), ServiceLifetime.Singleton);

builder.Services
     .AddScoped<ISignOnStorage, SignOnStorage>()
     .AddScoped<ISignInStorage, SignInStorage>()
     .AddScoped<IRegisterItemStorage, RegisterItemStorage>()
     .AddScoped<IUserItemsStorage, UserItemsStorage>()
     ;

builder.Services
    .AddScoped<ISignOnUseCase, SignOnUseCase>()
    .AddScoped<ISignInUseCase, SignInUseCase>()
    .AddScoped<IRegisterItemUseCase, RegisterItemUseCase>()
    .AddScoped<IUserItemsUseCase, UserItemsUseCase>()
    ;
builder.Services
           .AddScoped<IAuthTokenStorage, AuthTokenStorage>()
           .AddScoped<IIntentionManager, IntentionManager>()
           .AddScoped<IIdentityProvider, IdentityProvider>()
           .AddScoped<IIntentionResolver, RegisterItemIntentionResolver>()
           ;

builder.Services.AddValidatorsFromAssemblyContaining<Warehouse.Domain.Models.Warehouse>(includeInternalTypes: true);

var app = builder.Build();

app.Services.GetRequiredService<WarehouseDbContext>().Database.Migrate();

app.UseSwagger();
app.UseSwaggerUI();

app.UseMiddleware<AuthenticationMiddleware>();

//app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
