using Makarov_Mikhail_Kt_31_20_Lab1.Database;
using Makarov_Mikhail_Kt_31_20_Lab1.interfaces.StudentInterfaces;
using Makarov_Mikhail_Kt_31_20_Lab1.Middlewares;
using Makarov_Mikhail_Kt_31_20_Lab1.ServiceExtensions;
using Microsoft.EntityFrameworkCore;
using NLog;
using NLog.Web;
using static Makarov_Mikhail_Kt_31_20_Lab1.ServiceExtensions.ServiceExtensions;

var builder = WebApplication.CreateBuilder(args);

var logger=LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
// Add services to the container.

try
{
    builder.Logging.ClearProviders();
    builder.Host.UseNLog();
    builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.Configure<MakarovDbContext>(
    builder.Configuration.GetSection(nameof(MakarovDbContext)));
    IServiceCollection serviceCollection = builder.Services.AddDbContext<MakarovDbContext>(options =>
options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
    //  builder.Services.AddScoped<IDataAccessProvider, DataAccessProvider>();
    // builder.Services.AddDbContext<MakarovDbContext>(options => 
    //options.UseNpgsql(builder.Configuration.GetConnectionString("DefultConnection")));
    builder.Services.AddScoped<IStudentService, StudentFilterService>();
    builder.Services.AddService();
    var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

    app.UseMiddleware<ExceptionHandlerMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();

}

catch(Exception ex)
{
    logger.Error(ex, "Stopped program because of exception");
}
finally
{
    LogManager.Shutdown();
}
