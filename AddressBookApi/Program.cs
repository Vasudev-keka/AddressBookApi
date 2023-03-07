using API.Data.Models;
using Microsoft.EntityFrameworkCore;
using AddressBookApi.Controllers;
using API.Services.services;
using AutoMapper;
namespace AddressBookApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IServices, Service>();
           
            builder.Services.AddDbContext<Context>(options => options.UseSqlServer(
            builder.Configuration.GetConnectionString("Default")));
            builder.Services.AddCors(path =>
            {
                path.AddPolicy(MyAllowSpecificOrigins,
                                      builder =>
                                      {
                                          builder.WithOrigins("http://127.0.0.1:5502")
                                                              .AllowAnyHeader()
                                                              .AllowAnyMethod();
                                      });
            });
            var app = builder.Build();
            app.UseCors(MyAllowSpecificOrigins);
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.MapUserEndpoints();

            app.Run();
        }
    }
}