using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Service.Catalogos.Application.Common.Behaviors;
using Service.Catalogos.Application.Interfaces;
using Service.Catalogos.Infrastructure.Database;
using Service.Catalogos.Infrastructure.Repositories;
using Service.Catalogos.Infrastructure.Services;
using Service.Catalogos.API.BackgroundServices;
using Service.Catalogos.API.Middleware;

namespace Service.Catalogos.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Fix for Npgsql DateTime issues
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();

        var allowedOrigins = builder.Configuration.GetSection("Cors:AllowedOrigins").Get<string[]>() ?? Array.Empty<string>();

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAngularApp",
                policy => policy.WithOrigins(allowedOrigins)
                                .AllowAnyMethod()
                                .AllowAnyHeader()
                                .AllowCredentials());
        });

        builder.Services.AddSwaggerGen(c =>
        {
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                Scheme = "bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "Ingrese el token JWT obtenido de Service.Seguridad"
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });
        });

        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.Authority = "http://localhost:5000";
                options.RequireHttpsMetadata = false;

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "Service.Seguridad",
                    ValidAudience = "Monocont"
                };
            });

        builder.Services.AddAuthorization();

        var connectionString = builder.Configuration.GetConnectionString("CatalogosDb");

        builder.Services.AddDbContext<CatalogosDbContext>(options =>
            options.UseNpgsql(connectionString));

        builder.Services.AddMemoryCache();

        builder.Services.AddScoped<IUbigeoRepository, UbigeoRepository>();
        builder.Services.AddScoped<IMonedaRepository, MonedaRepository>();
        builder.Services.AddScoped<ITipoCambioRepository, TipoCambioRepository>();
        builder.Services.AddScoped<ITipoRelacionRepository, TipoRelacionRepository>();
        builder.Services.AddScoped<IEstadoComprobanteRepository, EstadoComprobanteRepository>();
        builder.Services.AddScoped<ITipoDocIdentidadRepository, TipoDocIdentidadRepository>();
        builder.Services.AddScoped<ITipoDocumentoModifRepository, TipoDocumentoModifRepository>();
        builder.Services.AddScoped<ITipoCpRepository, TipoCpRepository>();
        builder.Services.AddScoped<ITipoNotaRepository, TipoNotaRepository>();
        builder.Services.AddScoped<ITipoOperacionRepository, TipoOperacionRepository>();
        builder.Services.AddScoped<IClasifBssSssRepository, ClasifBssSssRepository>();
        builder.Services.AddScoped<IUnidadMedidaRepository, UnidadMedidaRepository>();
        builder.Services.AddScoped<IProyectoInversionRepository, ProyectoInversionRepository>();
        builder.Services.AddScoped<IDetraccionServicioRepository, DetraccionServicioRepository>();

        builder.Services.AddHttpClient<ISunatTipoCambioService, SunatTipoCambioService>(client =>
        {
            client.Timeout = TimeSpan.FromSeconds(30);
        });

        builder.Services.AddScoped<ITipoCambioProveedor, SunatTipoCambioProveedor>();
        builder.Services.AddScoped<ITipoCambioProveedorFactory, TipoCambioProveedorFactory>();

        builder.Services.AddHostedService<TipoCambioDiarioBackgroundService>();

        builder.Services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(Service.Catalogos.Application.Common.Behaviors.ValidationBehavior<,>).Assembly);
        });

        builder.Services.AddValidatorsFromAssembly(typeof(Service.Catalogos.Application.Common.Behaviors.ValidationBehavior<,>).Assembly);
        builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        var app = builder.Build();

        app.UseMiddleware<ErrorHandlingMiddleware>();
        app.UseMiddleware<ResponseFormattingMiddleware>();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseCors("AllowAngularApp");

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}