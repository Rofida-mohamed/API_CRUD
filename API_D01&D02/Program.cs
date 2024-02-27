
using Api_D01.Models;
using Api_D01.Service;
using Microsoft.EntityFrameworkCore;

namespace API_D01_D02
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddTransient<IStudentRepo, StudentRepo>();
            builder.Services.AddTransient<IDepartmentRepo, DepartmentRepo>();


            //////
            ///
            builder.Services.AddDbContext<ApiDbContext>(
                op => op.UseSqlServer(builder.Configuration.GetConnectionString("con1"))
                );
            builder.Services.AddCors( option =>
            {
                option.AddPolicy("MyPolicy", crosPolicy =>
                {
                    crosPolicy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                });
            } );
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();
            app.UseStaticFiles();

            app.MapControllers();
            app.UseCors("MyPolicy");
            app.Run();
        }
    }
}
