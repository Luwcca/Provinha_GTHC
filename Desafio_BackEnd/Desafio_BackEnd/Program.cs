using Desafio_BackEnd.Data;
using DesafioBackEnd_Api.Data.Interfaces;
using DesafioBackEnd_Api.Data.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

public class Program
{
    private static void Main(string[] args)
    {

        var builder = WebApplication.CreateBuilder(args);

        //Adição Serviços, Scope do Repositorio para injeção de dependecia, Sqlite3 e Automapper

        builder.Services.AddDbContext<UserContext>(options =>
                options.UseSqlite("Data Source=..\\Usuarios\\users.db;"));
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());



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
    }
}