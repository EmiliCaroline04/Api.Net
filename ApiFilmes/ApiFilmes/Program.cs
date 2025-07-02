
using ApiFilmes.Services.Parsers;
using ApiFilmes.Services.Validations;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using FluentValidation;
using ApiFilmes.Services;
using ApiFilmes.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;

namespace ApiFilmes
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<FilmesContext>(options =>
    options.UseNpgsql("Host=localhost;Database=ApiFilmes;Username=postgres;Password=masterkey"));


            builder.Services.AddControllers().AddXmlSerializerFormatters(); // para suportar XML al�m de JSON
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

            builder.Services.AddValidatorsFromAssemblyContaining<FilmeValidators>();

            builder.Services.AddControllers();
            builder.Services.AddScoped<AtorService>();
            builder.Services.AddScoped<GeneroService>();
            builder.Services.AddScoped<FilmeService>();
            builder.Services.AddScoped<AvaliacaoService>();

            builder.Services.AddScoped<IFilmeService, FilmeService>();
            builder.Services.AddScoped<IGeneroService, GeneroService>();
            builder.Services.AddScoped<IDiretorService, DiretorService>();
            builder.Services.AddScoped<IAtorService, AtorService>();
            builder.Services.AddScoped<IAvaliacaoService, AvaliacaoService>();

            var app = builder.Build();

          
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();

            app.MapControllers();

            app.Run();

        }
    }
}
