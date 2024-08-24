using Microsoft.EntityFrameworkCore;
using Tunify_Platform.Data;
using Tunify_Platform.Repositories.Interfaces;
using Tunify_Platform.Repositories.Services;

namespace Tunify_Platform
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();

            // Get the connection string settings 
            //
            string ConnectionStringVar = builder.Configuration.GetConnectionString("DefaultConnection");
                
            builder.Services.AddDbContext<TunifyDbContext>(optionsX => optionsX.UseSqlServer(ConnectionStringVar));

            builder.Services.AddScoped<IPlayList, PlaylistService>();
            builder.Services.AddScoped<IUser, UserService>();
            builder.Services.AddScoped<ISong, SongService>();
            builder.Services.AddScoped<IArtist, ArtistService>();
            
            //swagger configuration
            builder.Services.AddSwaggerGen
                (

                option =>
                {
                    option.SwaggerDoc("tunifyApi", new Microsoft.OpenApi.Models.OpenApiInfo()
                    {
                        Title = "Tunify Platmform Api Doc",
                        Version = "v1",
                        Description = "Api for managing all tunify platform"
                    });
                }
                );

            var app = builder.Build();

            // call swagger service
            app.UseSwagger
                (
                options =>
                {
                    options.RouteTemplate = "api/{documentName}/swagger.json";
                }
                );

            // call swagger UI
            app.UseSwaggerUI
                (
                options =>
                {
                    options.SwaggerEndpoint("/api/tunifyApi/swagger.json", "Tunify Api");
                    options.RoutePrefix = "";
                }
                );
            app.MapControllers();

           // app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }
}
