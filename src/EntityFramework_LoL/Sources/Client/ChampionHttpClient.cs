using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class ChampionHttpClient
    {
        private const string ApiChampions = "api/champions";
        private readonly HttpClient _httpClient;
        public ChampionHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
            httpClient.BaseAddress = new Uri("https://localhost:7252;http://localhost:5252");
        }

        public async Task<IEnumerable<ChampionDto>> GetChampion()
        {
            var champions = await _httpClient.GetFromJsonAsync<IEnumerable<ChampionDto>>(ApiChampions);
            return champions;
        }
        public async void Add(ChampionDto champion)
        {
            await _httpClient.PostAsJsonAsync<ChampionDto>(ApiChampions, champion);
        }

        public async void Delete(ChampionDto champion)
        {
            await _httpClient.DeleteAsync(champion);
        }

        public async void Update(ChampionDto champion)
        {
            await _httpClient.PutAsJsonAsync<ChampionDto>(ApiChampions, champion);
        }

    }
}
