using BuberDinner.Application;
using BuberDinner.Infrasctructure;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
{

    builder.Services
        .AddApplication()
        .AddInfrastructure();

    //Add Controllers and Swagger
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
}

WebApplication app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
