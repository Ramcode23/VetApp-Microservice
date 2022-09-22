using System.Reflection;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Service.Common.Mapping;
using ServiceType.Persistese.Database;
using ServiceType.Service.Queries;

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
                        optionsSqlServer => { optionsSqlServer.MigrationsAssembly("ServiceType.Persistese.Database");
                        optionsSqlServer.MigrationsHistoryTable("__EFMigrationsHistory", "ServiceCategory");         
                        });

                }
            );

builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

builder.Services.AddMediatR(Assembly.Load("ServiceType.Service.EventHandlers"));
builder.Services.AddTransient<IServiceTypeQueryService, ServiceTypeQueryService>();


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
