namespace Repositorio.Entidades
{
    public class Usuario
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string UrlImagem { get; set; }
        public string Cnpj { get; set; }
        public bool IsFornecedor { get; set; }
    }
}