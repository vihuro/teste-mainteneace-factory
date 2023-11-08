namespace TestMainteneace.Api.Middlewares.Models
{
    public sealed class MiddlewareModel
    {
        public Guid TraceId { get; private set; }
        public string LineErro { get; private set; }
        public string ClassErro { get; set; }
        public List<ErrorDetailsModel> Erros { get; private set; }

        public MiddlewareModel(string logref, string lineErros, 
                                string classErro, List<string> message)
        {
            TraceId = Guid.NewGuid();
            ClassErro = classErro;
            LineErro = lineErros; 
            Erros = new List<ErrorDetailsModel>();
            AddErros(logref, message);
        }

        private void AddErros(string logref, List<string> message)
        {
            Erros.Add(new ErrorDetailsModel
            {
                Logref = logref,
                Message = message
            });
        }
    }
}
