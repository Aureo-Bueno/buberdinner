using BuberDinner.API.Filters;
using BuberDinner.API.Middleware;
using BuberDinner.Application;
using BuberDinner.Infrasctructure;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
{

    builder.Services
        .AddApplication()
        .AddInfrastructure(builder.Configuration);

    //Add Controllers and Swagger
    // builder.Services.AddControllers(options => options.Filters.Add<ErrorHandlingFilterAttributes>());
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
    app.UseExceptionHandler("/error");
    // app.UseMiddleware<ErrorHandlingMiddleware>();
    app.MapControllers();

    app.Run();
}
