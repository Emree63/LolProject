﻿using DTO;
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
        private const string UrlApiChampions = "/api/v3/champions";
        private readonly HttpClient _httpClient;
        public ChampionHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
            httpClient.BaseAddress = new Uri("https://localhost:7252");
        }

        public async Task<IEnumerable<ChampionDto>> GetChampion(int index, int count)
        {
            var url = $"{UrlApiChampions}?index={index}&count={count}";
            var Response = await _httpClient.GetFromJsonAsync<PageResponse<ChampionDto>>(url);
            return Response.Data;
        }
        /*        public async void Add(ChampionDto champion)
                {
                    await _httpClient.PostAsJsonAsync<ChampionDto>(ApiChampions, champion);
                }*/

        /*        public async void Delete(ChampionDto champion)
                {
                    await _httpClient.DeleteAsync(champion.Name);
                }

                public async void Update(ChampionDto champion)
                {
                    await _httpClient.PutAsJsonAsync<ChampionDto>(ApiChampions, champion);
                }*/

    }
}
