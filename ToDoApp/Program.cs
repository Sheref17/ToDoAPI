
using DomainLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistance;
using Persistance.Data;
using ServiceAbstraction;
using ServiceLayer;

namespace ToDoApp
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

            builder.Services.AddDbContext<ToDoContext>(opt =>
            {
                opt.UseSqlServer(builder.Configuration.GetConnectionString("Database"));
            });

        
            builder.Services.AddScoped<IToDoRepo, ToDoRepo>();
            builder.Services.AddAutoMapper(X => X.AddProfile(new ToDoProfile()));
            builder.Services.AddScoped<IToDoService, ToDoService>();
            builder.Services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    var errors = context.ModelState
                        .Where(e => e.Value.Errors.Count > 0)
                        .Select(e => new
                        {
                            Field = string.IsNullOrEmpty(e.Key) ? "RequestBody" : e.Key,
                            Errors = e.Value.Errors.Select(x =>
                                string.IsNullOrEmpty(x.ErrorMessage)
                                    ? "Invalid value"
                                    : x.ErrorMessage)
                        });

                    return new BadRequestObjectResult(new
                    {
                        Message = "Validation failed",
                        Errors = errors
                    });
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
        }
    }
}
