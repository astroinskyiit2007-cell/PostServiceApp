using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using PostService.Dtos;

namespace PostService.App
{
    public class PostServiceClient : IPostServiceClient
    {
        private readonly HttpClient _httpClient;

        public PostServiceClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<PostingGetDto>> GetAllAsync()
        {
            var response = await _httpClient.GetAsync("postings");
            await EnsureSuccessAsync(response);
            return await response.Content.ReadFromJsonAsync<List<PostingGetDto>>() ?? new List<PostingGetDto>();
        }

        public async Task<PostingGetDto?> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"postings/{id}");
            await EnsureSuccessAsync(response);
            return await response.Content.ReadFromJsonAsync<PostingGetDto>();
        }

        public async Task<PostingGetDto?> CreateAsync(PostingPostDto dto)
        {
            var response = await _httpClient.PostAsJsonAsync("postings", dto);
            await EnsureSuccessAsync(response);
            return await response.Content.ReadFromJsonAsync<PostingGetDto>();
        }

        public async Task UpdateAsync(int id, PostingPutDto dto)
        {
            var response = await _httpClient.PutAsJsonAsync($"postings/{id}", dto);
            await EnsureSuccessAsync(response);
        }

        public async Task DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"postings/{id}");
            await EnsureSuccessAsync(response);
        }

        private async Task EnsureSuccessAsync(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
                return;

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                var content = await response.Content.ReadAsStringAsync();
                var errors = new Dictionary<string, string[]>();

                try
                {
                    using var doc = JsonDocument.Parse(content);
                    if (doc.RootElement.TryGetProperty("errors", out var errorsElement))
                    {
                        errors = JsonSerializer.Deserialize<Dictionary<string, string[]>>(errorsElement.GetRawText())
                                 ?? new Dictionary<string, string[]>();
                    }
                }
                catch
                {
                }

                throw new PostingValidationException("Помилка валідації даних.", errors);
            }

            throw new HttpRequestException(
                $"Сервер повернув помилку {(int)response.StatusCode} ({response.ReasonPhrase}).",
                null,
                response.StatusCode);
        }
    }
}