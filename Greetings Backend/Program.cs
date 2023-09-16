using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Greetings_Backend.Data;
using Greetings_Backend.Repository;

namespace Greetings_Backend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<Greetings_BackendContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("Greetings_BackendContext") ?? throw new InvalidOperationException("Connection string 'Greetings_BackendContext' not found.")));

            // Add services to the container.
            builder.Services.AddTransient<IGreetingsRepo,GreetingsRepo>();

            var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";


            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                    policy =>
                    {
                        policy.WithOrigins("http://example.com", "http://www.contoso.com");
                    });
                options.AddPolicy(name: MyAllowSpecificOrigins,
                    policy =>
                    {
                        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                    });
            });


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors(MyAllowSpecificOrigins);
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}