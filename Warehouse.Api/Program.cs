using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Warehouse.Api;
using Warehouse.Api.Authentication;
using Warehouse.Api.Middlewares;
using Warehouse.Domain.Authorization;
using Warehouse.Domain.IntentionResolvers;
using Warehouse.Domain.UseCases.AcceptRegisteredItem;
using Warehouse.Domain.UseCases.CheckoutItem;
using Warehouse.Domain.UseCases.ConfirmPay;
using Warehouse.Domain.UseCases.EditWarehouse;
using Warehouse.Domain.UseCases.GetReportWarehouse;
using Warehouse.Domain.UseCases.GetUserItems;
using Warehouse.Domain.UseCases.OpenWarehouse;
using Warehouse.Domain.UseCases.RegisterItem;
using Warehouse.Domain.UseCases.SignIn;
using Warehouse.Domain.UseCases.SignOn;
using Warehouse.Domain.UseCases.UnpaidItems;
using Warehouse.Storage;
using Warehouse.Storage.Storages;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();
builder.Host.UseSerilog();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => c.EnableAnnotations());
builder.Services.AddDbContext<WarehouseDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("Postgres")), ServiceLifetime.Singleton);

builder.Services
     .AddScoped<ISignOnStorage, SignOnStorage>()
     .AddScoped<ISignInStorage, SignInStorage>()
     .AddScoped<IRegisterItemStorage, RegisterItemStorage>()
     .AddScoped<IUserItemsStorage, UserItemsStorage>()
     .AddScoped<IGetReportWarehouseStorage, GetReportWarehouseStorage>()
     .AddScoped<IOpenWarhouseStorage, OpenWarhouseStorage>()
     .AddScoped<IEditWarehouseStorage, EditWarehouseStorage>()
     .AddScoped<IAcceptRegisteredItemStorage, AcceptRegisteredItemStorage>()
     .AddScoped<ICheckoutItemStorage, CheckoutItemStorage>()
     .AddScoped<IConfirmPayItemStorage, ConfirmPayItemStorage>()
     .AddScoped<IUnpaidItemsStorage, UnpaidItemsStorage>()
     ;

builder.Services
    .AddScoped<ISignOnUseCase, SignOnUseCase>()
    .AddScoped<ISignInUseCase, SignInUseCase>()
    .AddScoped<IRegisterItemUseCase, RegisterItemUseCase>()
    .AddScoped<IUserItemsUseCase, UserItemsUseCase>()
    .AddScoped<IAcceptRegisteredItemUseCase, AcceptRegisteredItemUseCase>()
    .AddScoped<IEditWarehouseUseCase, EditWarehouseUseCase>()
    .AddScoped<IGetReportWarehouseUseCase, GetReportWarehouseUseCase>()
    .AddScoped<IOpenWarehouseUseCase, OpenWarehouseUseCase>()
    .AddScoped<ICheckoutItemUseCase, CheckoutItemUseCase>()
    .AddScoped<IConfirmPayItemUseCase, ConfirmPayItemUseCase>()
    .AddScoped<IUnpaidItemsUseCase, UnpaidItemsUseCase>()
    ;



builder.Services
           .AddScoped<IAuthTokenStorage, AuthTokenStorage>()
           .AddScoped<IIntentionManager, IntentionManager>()
           .AddScoped<IIdentityProvider, IdentityProvider>()
           .AddScoped<IIntentionResolver, ItemIntentionResolver>()
           .AddScoped<IIntentionResolver, WarehouseIntentionResolver>()
           ;

builder.Services.AddValidatorsFromAssemblyContaining<Warehouse.Domain.Models.Warehouse>(includeInternalTypes: true);

var app = builder.Build();

app.Services.GetRequiredService<WarehouseDbContext>().Database.Migrate();

app.UseSwagger();
app.UseSwaggerUI();

app.UseSerilogRequestLogging();

app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseMiddleware<RequestLoggingMiddleware>();
app.UseMiddleware<AuthenticationMiddleware>();

//app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
