using Microsoft.EntityFrameworkCore;
using Serilog;
using MagicVilla_VillaAPI.Data;
using MagicVilla_VillaAPI.Repository.IRepository;
using MagicVilla_VillaAPI.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using MagicVilla_VillaAPI.Models;

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

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();
            builder.Services.AddResponseCaching();

            builder.Services.AddAutoMapper(typeof(MappingConfig));

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File("log/villaLogs.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            builder.Host.UseSerilog();

            builder.Services.AddScoped<IVillaRepository, VillaRepository>();
            builder.Services.AddScoped<IVillaNumberRepository, VillaNumberRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();

            var key = builder.Configuration.GetValue<string>("ApiSettings:Secret");
            builder.Services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            builder.Services.AddControllers(option =>
            {
                option.CacheProfiles.Add("Default30", new CacheProfile()
                {
                    Duration = 30
                });
                //option.ReturnHttpNotAcceptable = true; //Default responses are not in Json anymore 
            }).AddNewtonsoftJson().AddXmlDataContractSerializerFormatters(); //Adds Json and Xml possible responses

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description =
                        "JWT Authorization using the Bearer scheme. \r\n\r\n" +
                        "Enter 'Bearer' [space] and thenyour token in the text input below. \r\n\r\n" +
                        "Example: \"Bearer 12345qwerty\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Scheme = "Bearer"
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header
                        },
                        new List<string>()
                    }
                });
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "MagicVilla API 1 - The rise of the titan",
                    Version = "v1",
                    Description = "A lot of luxury villas for people who make like super big money???",
                    TermsOfService = new Uri("https://www.thegameawards.com"),
                    Contact = new OpenApiContact()
                    {
                        Name = "Super Gundam",
                        Url = new Uri("https://www.lucadirisio.com")
                    },
                    License = new OpenApiLicense()
                    {
                        Name = "Dragon Ball GP",
                        Url = new Uri("https://www.motogp.com")
                    }
                });
                options.SwaggerDoc("v2", new OpenApiInfo
                {
                    Title = "MagicVilla API 2 - The revenge of my grandma",
                    Version = "v2",
                    Description = "My grandma woke up, somebody help me, I'm gonna be trapped inside her new ponzi scheme!!!!!!!!",
                    TermsOfService = new Uri("https://www.thegameawards.com"),
                    Contact = new OpenApiContact()
                    {
                        Name = "Super Gundam",
                        Url = new Uri("https://www.lucadirisio.com")
                    },
                    License = new OpenApiLicense()
                    {
                        Name = "Dragon Ball GP",
                        Url = new Uri("https://www.motogp.com")
                    }
                });
            });

            builder.Services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ReportApiVersions = true;
            });
            builder.Services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "MagicVilla_VillaAPI v1");
                    options.SwaggerEndpoint("/swagger/v2/swagger.json", "MagicVilla_VillaAPI v2");
                });
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();


        }
    }
}
