﻿using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WpfTutorial.Models;

namespace WpfTutorial.Service
{
    public class ChuckNorrisFactsService : IChuckNorrisFactsService
    {
        private readonly HttpClient _httpClient;
        private const string API_URL = "https://api.chucknorris.io/jokes/random";

        public ChuckNorrisFactsService(HttpClient httpClient = null)
        {
            _httpClient = httpClient ?? new HttpClient();
        }

        public async Task<ChuckNorrisFact> GetOneFactAsync()
        {
            using (var response = await _httpClient.SendAsync(CreateHttpRequest()))
            {
                var responseString = await response.Content.ReadAsStringAsync();
	            try
	            {
		            return JsonConvert.DeserializeObject<ChuckNorrisFact>(responseString);
	            }
	            catch (Exception ex)
	            {
		            Debug.WriteLine(ex);
	            }
	            return null;
            }
        }

        private static HttpRequestMessage CreateHttpRequest()
        {
            return new HttpRequestMessage
            {
                RequestUri = new Uri(API_URL),
                Method = HttpMethod.Get
            };
        }
    }
}
