using System.Reflection;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pet.Persistence.Database;
using Pet.Service.Queries;
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
                        optionsSqlServer => { optionsSqlServer.MigrationsAssembly("Pet.Persistence.Database");
                        optionsSqlServer.MigrationsHistoryTable("__EFMigrationsHistory", "Pet");         
                        });

                }
            );

builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

builder.Services.AddMediatR(Assembly.Load("Pet.Service.EventHandlers"));
builder.Services.AddTransient<IPetQueryService, PetQueryService>();


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
