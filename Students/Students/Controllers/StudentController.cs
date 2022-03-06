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
        public IActionResult Get()
        {
            return Ok(_studentService.GetAll());
        }

        // GET api/<ValuesController>/5
        [HttpGet("{document}")]
        public IActionResult Get(string document)
        {
            try
            {
                var result = _studentService.Get(document);
                return Ok(result);
            }
            catch (StudentNotFoundException)
            {
                return NotFound();
            }
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
    }
}
