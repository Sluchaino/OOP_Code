using Microsoft.AspNetCore.Mvc;
using Number20server.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Number20server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ValuesController : ControllerBase
    {
        // GET: api/<ValuesController>
        private readonly List<Item> _items = new List<Item>
        {
            new Item { Id = 1, Name = "Item 1", Description = "Description 1" },
            new Item { Id = 2, Name = "Item 2", Description = "Description 2" },
            new Item { Id = 3, Name = "Item 3", Description = "Description 3" }
        };
        [HttpGet]
        public IActionResult GetItems()
        {
            return Ok(_items);
        }
    }
}
