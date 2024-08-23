using GymManagement.Application;
using GymManagement.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();

    builder.Services
        .AddApplication()
        .AddInfrastructure();
}

var app = builder.Build();
{
    app.MapControllers();
    app.Run();
}