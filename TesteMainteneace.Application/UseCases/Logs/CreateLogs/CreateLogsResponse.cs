using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteMainteneace.Application.UseCases.Logs.CreateLogs
{
    public sealed record CreateLogsResponse
    {
        public Guid Id { get; set; }
        public string LogRef { get; set; }
        public List<string> Message { get; set; }
    }
}
