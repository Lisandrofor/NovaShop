using NovaShop.Data;
using NovaShop.Extensions;
using NovaShop.Interfaces.Repositorios;
using NovaShop.Repositories;



public partial class Program
{
    private static void Main(string[] args)
    {

        var builder = WebApplication.CreateBuilder(args);

        // REGISTRAR SERVICIOS
        builder.Services.AddScoped<DatabaseInitializer>();

        builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();


        var app = builder.Build();


        // CREAR BASE Y TABLAS
        using (var scope = app.Services.CreateScope())
        {
            scope.ServiceProvider
                .GetRequiredService<DatabaseInitializer>()
                .Initialize();
        }







        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        

        // Swagger UI
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        // Endpoints
        app.MapUserEndpoints();

        app.Run();
    }
}
