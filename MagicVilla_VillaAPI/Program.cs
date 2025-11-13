using Microsoft.EntityFrameworkCore;
using Serilog;
using MagicVilla_VillaAPI.Data;
using MagicVilla_VillaAPI.Repository.IRepository;
using MagicVilla_VillaAPI.Repository;

namespace MagicVilla_VillaAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddDbContext<AppDbContext>(option =>
            {
                option.UseNpgsql(builder.Configuration.GetConnectionString("DefaultPostgreConnection"));
            });

            builder.Services.AddAutoMapper(typeof(MappingConfig));

            Log.Logger = new LoggerConfiguration().MinimumLevel.Debug()
                .WriteTo.File("log/villaLogs.txt", rollingInterval: RollingInterval.Day).CreateLogger();

            builder.Host.UseSerilog();

            builder.Services.AddScoped<IVillaRepository, VillaRepository>();
            builder.Services.AddScoped<IVillaNumberRepository, VillaNumberRepository>();

            builder.Services.AddControllers(option =>
            {
                //option.ReturnHttpNotAcceptable = true; //Default responses are not in Json anymore 
            }).AddNewtonsoftJson().AddXmlDataContractSerializerFormatters(); //Adds Json and Xml possible responses

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "MagicVilla_VillaAPI v1");
                });
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();

            
        }
    }
}
