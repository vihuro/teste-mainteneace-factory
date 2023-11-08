namespace TesteMainteneace.Application.UseCases.UserAuthApiExternal.GetQueryUserApiAuth
{
    public sealed record GetQueryUserApiAuthResponse
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Apelido { get; set; }
        public bool Ativo { get; set; }
    }
}
