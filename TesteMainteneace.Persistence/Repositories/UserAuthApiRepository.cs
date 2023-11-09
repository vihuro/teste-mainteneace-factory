using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using TesteMainteneace.Domain.Entities.User;
using TesteMainteneace.Domain.Interfaces.User;
using TesteMainteneace.Persistence.Utils;

namespace TesteMainteneace.Persistence.Repositories
{
    public class UserAuthApiRepository : IUserAuthApiRepository
    {
        private readonly IConfiguration _configuration;
        private static AndressApiAuth Andress;

        public UserAuthApiRepository(IConfiguration configuration,
                                    IOptions<AndressApiAuth> andress)
        {
            _configuration = configuration;
            Andress = andress.Value;
        }

        public async Task<List<UserAuthApi>> GetList(CancellationToken cancellationToken)
        {
            using var client = new HttpClient();
            var responseApi = await client.GetAsync(Andress.Andress, cancellationToken);
            if (responseApi.IsSuccessStatusCode)
            {
                var content = await responseApi.Content.ReadAsStringAsync(cancellationToken);
                var objResponse = JsonConvert.DeserializeObject<ResponseApiAuth>(content);

                return objResponse.DataUsers;
            }
            throw new Exception("Fail in search users api auth!");
        }
    }
}
