using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.IO;
using ApiCsv.DataBase.Models;
using System.Security.Cryptography.X509Certificates;

namespace ApiCsv.DataBase
{
    public class DBContext
    {
        private const string PathNome =
          "C:\\Users\\emili\\OneDrive\\Área de Trabalho\\PARADIGMAS DE LINGUAGENS DE PROGRAMAÇÃO\\Api.Net\\ApiCsv\\animais.txt";

        private readonly List<Animal> _animais = new();


        public DBContext()
        {
        
            string[] lines = 
            File.ReadAllLines(PathNome);
            for (int i = 1; i < lines.Length; i++) 

            {
                string[] coluns =
                lines[i].Split(';');
                Animal animal = new();
                animal.Id = int.Parse(coluns[0]);
                animal.Nome = coluns[1];
                animal.Classification = coluns[2];
                animal.Origin = coluns[3];
                animal.Reproduction = coluns[4];
                animal.Feeding = coluns[5];

               _animais.Add(animal);

            }
        }

      public List<Animal> Animals => _animais; // propriedade 
    }
}
