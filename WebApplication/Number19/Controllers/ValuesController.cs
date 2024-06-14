using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Mvc;
using Number19.Interface;
using Number19.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Number19.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IMyManager _myManager;
        // POST api/<ValuesController>
        public ValuesController(IMyManager myManager)
        {
            _myManager = myManager;
        }
        [HttpPost]
        public IActionResult Post([FromBody] MyData data)
        {
            // Вызов метода менеджера
            var result = _myManager.ProcessData(data);

            // Возврат результата
            return Ok(result);
        }
    }
}
