using Microsoft.EntityFrameworkCore;
using SistemaPub.Database;
using SistemaPub.Repository;
using SistemaPub.Repository.Interfaces;
using System.Reflection;
using System.Text.Json.Serialization;

namespace SistemaPub
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "GastroBar API",
                    Version = "1.0",
                    Description = "Esta API tem como objetivo gerenciar Restaurantes/Bares.",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact
                    {
                        Name = "Esdras Lima - Linkedin",
                        Email = "esdraslimaf@gmail.com",
                        Url = new Uri("https://www.linkedin.com/in/esdrasdev/")
                    }
                });

                // Habilitar comentários XML do Swagger
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);
            });
            builder.Services.AddScoped<IComandaRepository,ComandaRepository>();
            builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
            builder.Services.AddScoped<IComandaProdutoRepository, ComandaProdutoRepository>();
            builder.Services.AddDbContext<PubContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MyConnection")));

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