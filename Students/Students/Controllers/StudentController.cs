using Microsoft.AspNetCore.Mvc;
using Students.Commons;
using Students.Models;
using Students.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Students.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private IStudentService _studentService;
        public StudentController(IStudentService service)
        {
            _studentService = service;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return new List<Student>();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public IActionResult Post([FromBody] Student value)
        {
            try
            {
                _studentService.New(value);

                string responseUrl = String.Format("/student/{0}", value.document);
                return Created(responseUrl, value);
            }
            catch (StudentInvalidException)
            {
                return BadRequest();
            }
            catch (StudentRepeteadException)
            {
                return BadRequest();
            }
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
}
