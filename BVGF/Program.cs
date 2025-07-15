using BVGFRepository.Interfaces.MstCategary;
using BVGFRepository.Repository.MstCategary;
using BVGFServices.Interfaces.MstCategary;
using BVGFServices.Services.MstCategary;

namespace BVGF
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
            //register our repository
            builder.Services.AddScoped(typeof(IMstCategary<>),typeof(MstCategary<>));

            //register services
            builder.Services.AddScoped<IMstCategary, MstCategary>();

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
