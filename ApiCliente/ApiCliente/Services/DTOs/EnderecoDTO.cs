namespace ApiClientes.Services.DTOs
{


    public class EnderecoDTO
    {
        public int Id { get; set; }
        public int Cep { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public int Clienteid { get; set; }
    }
    public class CriarEnderecoDTO
    {
        public string Logradouro { get; internal set; }
        public string Cep { get; internal set; }
        public string Numero { get; internal set; }
        public string Bairro { get; internal set; }
        public string Cidade { get; internal set; }
        public string Uf { get; internal set; }
        public string Complemento { get; internal set; }
    }
}