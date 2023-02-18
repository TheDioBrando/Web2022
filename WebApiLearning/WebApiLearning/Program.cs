using WebApiLearning.Data;
using WebApiLearning.Interfaces;
using WebApiLearning.Models;
using WebApiLearning.Repositories;
using WebApiLearning.UnitsOfWork;

namespace WebApiLearning
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddDbContext<LibraryContext>();
            builder.Services.AddCors();
            builder.Services.AddScoped<IGenericRepository<Books>, BooksRepository>();
            builder.Services.AddScoped<IGenericRepository<Users>, UsersRepository>();
            builder.Services.AddScoped<IGenericRepository<Orders>, OrdersRepository>();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            //builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();

            app.UseCors(builder => builder.AllowAnyOrigin()
                                        .AllowAnyHeader()
                                        .AllowAnyMethod());

            app.MapControllers();

            app.Run();
        }
    }
}