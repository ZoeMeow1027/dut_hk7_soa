using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using MVC_CS_API.Data;
using MVC_CS_API.Data.Repositories;
using MVC_CS_API.Data.Seed;
using MVC_CS_API.Profiles;
using MVC_CS_API.Services;
using System.Text;

namespace MVC_CS_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connStr = builder.Configuration.GetConnectionString("Default");

            builder.Services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(connStr)
                );


            // Add services to the container
            builder.Services.AddControllers();

            builder.Services.AddHttpContextAccessor();

            builder.Services.AddCors(o =>
                o.AddPolicy("CorsPolicy", builder =>
                {
                    builder.WithOrigins("http://localhost:4200")
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                    builder.WithOrigins("https://localhost:4200")
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                }
                    )
                );

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(builder.Configuration["TokenKey"]))
                    };
                });
            
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<ITokenService, TokenService>();
            builder.Services.AddScoped<IMemberService, MemberService>();
            builder.Services.AddAutoMapper(typeof(UserMapperProfile).Assembly);

            var app = builder.Build();

            using var scope = app.Services.CreateScope();
            var serviceProvider = scope.ServiceProvider;
            try
            {
                var context = serviceProvider.GetRequiredService<DataContext>();
                context.Database.Migrate();
                Seed.SeedUsers(context);
            }
            catch (Exception ex) { serviceProvider.GetRequiredService<ILogger<Program>>().LogError(ex, "Seed temporary datas failed!"); }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("CorsPolicy");

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}