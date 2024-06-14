using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Number20server.Model;
using System.Net.Http;
using System.Text.Json;

namespace Number20client.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DataController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DataController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> GetData()
        {
            var httpClient = _httpClientFactory.CreateClient();
            var response = await httpClient.GetAsync("https://localhost:7168/api/Values"); // Замените на адрес App1

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var items = JsonSerializer.Deserialize<List<Item>>(content);
                return Ok(items);
            }
            else
            {
                return BadRequest("Не удалось получить данные.");
            }
        }
    }
}
