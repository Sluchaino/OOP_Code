using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Number20client.Model;
using System.Net.Http;
using System.Text.Json;

namespace Number20client.Controllers
{
    [ApiController]
    [Route("api/Values")]
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
            var response = await httpClient.GetFromJsonAsync<List<Item>>("http://localhost:5024/api/Values");

            if (response != null)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest("Не удалось получить данные.");
            }
        }
    }
}
