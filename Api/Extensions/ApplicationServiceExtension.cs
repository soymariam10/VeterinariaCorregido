

using System.Text;
using AspNetCoreRateLimit;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace API.Extensions;
public static class ApplicationServiceExtension
{
    //configuracion de las politicas de las cors, es decir proteccion a los endpoints
    public static void ConfigureCors(this IServiceCollection services) =>
    services.AddCors(options =>
        {
            options.AddPolicy(
                "CorsPolicy", //Es un nombre de variable, a la cual nos referimos a la configuracion para hacer la inyeccion en el contenedor de dependencias program.cs
                builder =>
                    builder
                        .AllowAnyOrigin() //WithOrigins("https://domini.com")
                        .AllowAnyMethod()       //WithMethods(*GET ", "POST")
                        .AllowAnyHeader()      //WithHeaders(*accept*, "content-type")
            );

        }
    );


    //Configuracion para tener un limite de peticiones al endpoint 
    public static void ConfigureRateLimiting(this IServiceCollection services)
    {
        services.AddMemoryCache(); //permite adm memoria de chaché
        services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
        services.AddInMemoryRateLimiting();//metodo que permite almacenar info en memoria de forma temporal
        services.Configure<IpRateLimitOptions>(options => 
        {
            options.EnableEndpointRateLimiting = true;
            options.StackBlockedRequests = false;
            options.HttpStatusCode = 429;
            options.RealIpHeader = "X-Real-IP"; //esta expresion permite establecer cabezados cuantas posibles peticiones me quedan disponibles
            options.GeneralRules = new List<RateLimitRule>
            {
                new RateLimitRule
                {//configuracion
                    Endpoint = "*",
                    Period = "10s",
                    Limit = 2
                }
            };

        });
        
    }

/*   //Control de versiones de Appis (ver versiones de las apis creadas o Enpoint)
    public static void ConfigureApiVersioning(this IServiceCollection services)
    {
        services.AddApiVersioning(options => {

            options.DefaultApiVersion = new ApiVersion(1, 0);
            options.AssumeDefaultVersionWhenUnspecified = true;
            //options.ApiVersionReader = new QueryStringApiVersionReader("v");
            //options.ApiVersionReader = new HeaderApiVersionReader("X-Version");
            options.ApiVersionReader = ApiVersionReader.Combine(
                new QueryStringApiVersionReader("v"),
                new HeaderApiVersionReader("X-Version")
            );
            options.ReportApiVersions = true;

        });
    }
    //cargar los servicios de la unidades de trabajo a implementar
    public static void AddApplicationServices(this IServiceCollection services)
    {
        //services.AddScoped<IEstadoInterface, EstadoRepository>();
        //services.AddScoped<IJwtGeneradorInterface, JwtGenerador>();
        services.AddScoped<IPasswordHasher<Usuario>, PasswordHasher<Usuario>>();
        services.AddScoped<IUserServiceInterface, UserService>();
        services.AddScoped<IUnitOfWorkInterface, UnitOfWork>();
    }

    //Configuracion del token Personalizado, autenticacion y validacion del mismo
    public static void AddJwt(this IServiceCollection services, IConfiguration configuration)
    {
        //Configuration from AppSettings
        services.Configure<JWT>(configuration.GetSection("JWT"));

        //Adding Athentication - JWT
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
            .AddJwtBearer(o =>
            {
                o.RequireHttpsMetadata = false;
                o.SaveToken = false;
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                    ValidIssuer = configuration["JWT:Issuer"],
                    ValidAudience = configuration["JWT:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"]))
                };
            });
    }*/
        
}