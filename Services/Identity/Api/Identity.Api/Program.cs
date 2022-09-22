using System.Reflection;
using System.Text;
using Identity.Domain;
using Identity.Persistence.Database;
using Identity.Service.Queries;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.IdentityModel.Tokens;
using Service.Common.Mapping;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
const string CONNECTIONNAME = "DefaultConnection";

var connectionString = builder.Configuration.GetConnectionString(CONNECTIONNAME);

builder.Services.AddDbContextPool<ApplicationDbContext>
            (
                dbContextOptionsBuilder =>
                {

                    dbContextOptionsBuilder.UseSqlServer(connectionString,
                        optionsSqlServer => { optionsSqlServer.MigrationsAssembly("Identity.Persistence.Database");
                        optionsSqlServer.MigrationsHistoryTable("__EFMigrationsHistory", "Identity");         
                        });

                }
            );

builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));


          /*   // Health check
            builder.Services.AddHealthChecks()
                        .AddCheck("self", () => HealthCheckResult.Healthy())
                        .AddDbContextCheck<ApplicationDbContext>(typeof(ApplicationDbContext).Name);

            builder.Services.AddHealthChecksUI(); */

            // Identity
            builder.Services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // Identity configuration
            builder.Services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;
            });

            // Event handlers
            builder.Services.AddMediatR(Assembly.Load("Identity.Service.EventHandlers"));

            // Query services
            builder.Services.AddTransient<IUserQueryService, UserQueryService>();

            // API Controllers
            builder.Services.AddControllers();

            // Add Authentication
            var secretKey = Encoding.ASCII.GetBytes(
                builder.Configuration.GetValue<string>("SecretKey")
            );

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(secretKey),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
