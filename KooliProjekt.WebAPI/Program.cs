using FluentValidation;
using KooliProjekt.Application.Behaviors;
using KooliProjekt.Application.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using KooliProjekt.Application.Infrastructure.Files;
using KooliProjekt.Application.Authentication.Jwt;
using KooliProjekt.Application.Infrastructure;

namespace KooliProjekt.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString =
                builder.Configuration.GetConnectionString("DefaultConnection");

            var filesRoot = builder.Configuration["FilesRoot"];
            var fileClient = new LocalFileClient(filesRoot);

            builder.Services.AddSingleton<IFileClient>(fileClient);

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            builder.Services.AddControllers();

            builder.Services.AddSingleton<JwtSettings>();
builder.Services.AddSingleton<JwtTokenBuilder>();

            builder.Services.AddHttpContextAccessor();
            builder.Services.AddScoped<IUserProvider, WebUserProvider>();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var applicationAssembly =
                typeof(ErrorHandlingBehavior<,>).Assembly;

            builder.Services.AddValidatorsFromAssembly(applicationAssembly);

            builder.Services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(applicationAssembly);
                config.AddOpenBehavior(typeof(ErrorHandlingBehavior<,>));
                config.AddOpenBehavior(typeof(ValidationBehavior<,>));
                config.AddOpenBehavior(typeof(TransactionalBehavior<,>));
            });

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var dbContext =
                    scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                SeedData.Initialize(dbContext);
            }

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}