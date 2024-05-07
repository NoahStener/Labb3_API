
using Labb3_API.Data;
using Labb3_API.Services;
using Microsoft.EntityFrameworkCore;
using System;

namespace Labb3_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Noah Stener första egna REST API


            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<IUser, UserRepository>();


            builder.Services.AddDbContext<Labb3DbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("Connection")));

            


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
}
