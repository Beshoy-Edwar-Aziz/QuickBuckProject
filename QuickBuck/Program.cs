using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using QuickBuck.Core.Repositories;
using QuickBuck.Extensions;
using QuickBuck.Helpers;
using QuickBuck.Repository;
using QuickBuck.Repository.Data;
using System.Text.Json.Serialization;

namespace QuickBuck
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<QuickBuckContext>(options=>options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));
            builder.Services.AddAutoMapper(typeof(MappingProfiles));
            builder.Services.IdentitServices(builder.Configuration);
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.WithOrigins("https://localhost:7156")
                            .AllowAnyOrigin()
                            .AllowAnyHeader();
                });
            });
            builder.Services.AddControllers()
        .AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        });
            var app = builder.Build();
            #region UpdateDatabase
            using var Scope = app.Services.CreateScope();
            var Services = Scope.ServiceProvider;
            var Logger = Services.GetRequiredService<ILoggerFactory>();
            try
            {
                var DbContext = Services.GetRequiredService<QuickBuckContext>();
                await DbContext.Database.MigrateAsync();
             
            }
            catch (Exception ex) 
            {
                var LoggerFac = Logger.CreateLogger<Program>();
                LoggerFac.LogError(ex,"Unexpected Error Occured");
            }
            #endregion
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCors();
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
