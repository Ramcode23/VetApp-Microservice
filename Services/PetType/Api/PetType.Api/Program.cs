using PetType.Persistense.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PetType.Service.Queries;
using Service.Common.Mapping;
using AutoMapper;

using System.Reflection;

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
                        optionsSqlServer => { optionsSqlServer.MigrationsAssembly("PetType.Persistense.Database");
                        optionsSqlServer.MigrationsHistoryTable("__EFMigrationsHistory", "PetCategory");         
                        });

                }
            );

builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

builder.Services.AddMediatR(Assembly.Load("PetType.Service.EventHandlers"));
builder.Services.AddTransient<IPetCategoryQueryService, PetCategoryQueryService>();

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
