
using ApiCsv.DataBase;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Hosting;

namespace ApiCsv // endereçamento
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //builder construtor da aplicação e gerencia a criação (automatizar a criação de classes)

            // classe se inicia smp com Letra Maiuscula 
            // para se criar um objeto primeiro coloca o tipo e o nome da variavel que recebe new();
            // Produto produto[esse é o objeto] = new ();

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();  
            builder.Services.AddSingleton<DBContext>(); ;// dbcontext representa a conecção com o banco. 
            // o Singleton que toda aplicação seja criada apenas uma vez não deixa dar new novamente
            var app = builder.Build(); 

            // Configure the HTTP request pipeline. verifica em que ambiente está ex: produção
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
