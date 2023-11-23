using Microsoft.Extensions.Options;
using SharpCifs.Util.Sharpen;
using System.Text;
using TesteMainteneace.Domain.Entities.Reports;
using TesteMainteneace.Domain.Interfaces.Reports;
using TesteMainteneace.Persistence.Utils;


namespace TesteMainteneace.Persistence.Repositories
{
    public class ReportsStorage : IReportsStorage
    {
        private readonly AndressReportRadar _andress;

        public ReportsStorage(IOptions<AndressReportRadar> options)
        {
            _andress = options.Value;
        }

        public async Task<List<ReportsStorageEntity>> GetAll()
        {
            var myString = _andress.Andress.Replace("\\", "//").ReplaceAll("//", "/");
            using var reading = new StreamReader(myString, Encoding.GetEncoding("ISO-8859-1"), true);

            await reading.ReadLineAsync();
            var list = new List<ReportsStorageEntity>();
            while (!reading.EndOfStream)
            {
                string line = await reading.ReadLineAsync();
                string[] value = line.Split(";");

                list.Add(new ReportsStorageEntity
                {
                    Codigo = CustomReplace(value[0]),
                    Descricao = CustomReplace(value[1]),
                    Unidade = CustomReplace(value[2])
                });
            }

            return list;

        }
        private static string CustomReplace(string value)
        {
            return value.Replace("\"","");
        }

    }
}
