namespace TesteMainteneace.Domain.Entities
{
    public class UserAuthApi
    {
        public Guid UsuarioId { get; set; }
        public string Nome { get; set; }
        public string Apelido { get;set; }
        public bool Ativo { get; set; }
    }
    public class ResponseApiAuth
    {
        public int TotalUsers { get; set; }
        public List<UserAuthApi> DataUsers { get; set; }
    }
}
