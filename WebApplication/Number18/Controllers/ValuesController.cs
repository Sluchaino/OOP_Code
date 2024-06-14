using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using static System.Net.WebRequestMethods;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Number18.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        //Цель: Запрашивает ресурс.
        //Использование: Для получения данных с сервера.Например, получение списка продуктов, детальной информации о продукте или данных пользователя.

        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
        //    Этот код представляет собой контроллер API в ASP.NET Core, который демонстрирует базовые операции CRUD (Create, Read, Update, Delete) для ресурсов типа string. Давайте разберем его по частям:

        //1. [ApiController] атрибут:

        //Обозначает, что этот класс является контроллером API. Это означает, что он будет обрабатывать HTTP-запросы и возвращать ответы в формате, подходящем для API (например, JSON).
        //2. [Route("api/[controller]")] атрибут:

        //Определяет маршрут для контроллера. В этом случае маршрут будет /api/Values. [controller] - это заполнитель, который автоматически заменяется на имя контроллера (ValuesController).
        //3. Get() метод:

        //[HttpGet] атрибут: Указывает, что этот метод обрабатывает HTTP-запрос типа GET.
        //IEnumerable<string> Get(): Метод возвращает коллекцию строк, в данном случае { "value1", "value2"}.
        //Использование: Этот метод будет вызван при отправке запроса GET /api/Values.
        //4. Get(int id) метод:

        //[HttpGet("{id}")] атрибут: Указывает, что этот метод обрабатывает HTTP-запрос типа GET с параметром id в маршруте.
        //string Get(int id): Метод принимает id в качестве параметра и возвращает строку.
        //Использование: Этот метод будет вызван при отправке запроса GET /api/Values/5.
        //5. Post([FromBody] string value) метод:

        //[HttpPost] атрибут: Указывает, что этот метод обрабатывает HTTP-запрос типа POST.
        //void Post([FromBody] string value): Метод принимает строку value из тела запроса.
        //Использование: Этот метод будет вызван при отправке запроса POST /api/Values с JSON-данными в теле запроса.
        //6. Put(int id, [FromBody] string value) метод:

        //[HttpPut("{id}")] атрибут: Указывает, что этот метод обрабатывает HTTP-запрос типа PUT с параметром id в маршруте.
        //void Put(int id, [FromBody] string value): Метод принимает id из маршрута и строку value из тела запроса.
        //Использование: Этот метод будет вызван при отправке запроса PUT /api/Values/5 с JSON-данными в теле запроса.
        //7. Delete(int id) метод:

        //[HttpDelete("{id}")] атрибут: Указывает, что этот метод обрабатывает HTTP-запрос типа DELETE с параметром id в маршруте.
        //void Delete(int id): Метод принимает id из маршрута.
        //Использование: Этот метод будет вызван при отправке запроса DELETE /api/Values/5.
        //Важно:

        //В этом коде не реализована реальная логика работы с данными. Он просто демонстрирует, как контроллер API может обрабатывать запросы разных типов.
        //В реальных приложениях вы бы использовали базу данных или другой источник данных для хранения и управления данными, а также реализовали логику для обработки запросов и возврата ответов.
        //Для более сложных API, вы можете использовать более сложные типы данных, атрибуты и методы, чтобы создать более мощные и функциональные API.
        //Надеюсь, это разъяснение было полезным!
}
