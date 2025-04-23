
using ApiCsv.DataBase;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Hosting;

namespace ApiCsv // endere�amento
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //builder construtor da aplica��o e gerencia a cria��o (automatizar a cria��o de classes)

            // classe se inicia smp com Letra Maiuscula 
            // para se criar um objeto primeiro coloca o tipo e o nome da variavel que recebe new();
            // Produto produto[esse � o objeto] = new ();

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();  
            builder.Services.AddSingleton<DBContext>(); ;// dbcontext representa a conec��o com o banco. 
            // o Singleton que toda aplica��o seja criada apenas uma vez n�o deixa dar new novamente
            var app = builder.Build(); 

            // Configure the HTTP request pipeline. verifica em que ambiente est� ex: produ��o
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
