using Microsoft.AspNetCore.Mvc;
using RegisterPeople.Application.Dto;
using RegisterPeople.Application.Interface;

// Temas que quedaron pendientes 
//*realizar la construccion de los unitest aunque se realizo la creacion inicial para el uso de una bd en memoria para ser utilizado por los unittest
//*realizar el uso del modelado de datos mediante el automapper y realizar implementacion en el dominio
//*realizar la dockerizacion del proyecto
//* se puede realizar la pruebas mediante swagger
//*la conexion a la bd se encuentra en appsettings
//* la conexion se podria trabajar mediante keyvault azure o en su defecto las credenciales asi como un certificado de seguridad  

namespace RegisterPeople.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IPeopleApplication _people;
        public PeopleController(IPeopleApplication people)
        {
            _people = people;
        }

        // GET: api/<PeopleController>
        [HttpGet]
        public async Task<IActionResult> GetAllPeople()
        {
            var response = await _people.GetAllPeople();

            if (response.Response == StatusCodes.Status200OK.ToString())
            {
                return Ok(response);
            }
            if (response.Response == StatusCodes.Status404NotFound.ToString())
            {
                return NotFound(response);
            }
            if (response.Response == StatusCodes.Status500InternalServerError.ToString())
            {
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
            else
            {
                return BadRequest(response);
            }
        }

        // GET api/<PeopleController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await _people.GetPeople(id);

            if (response.Response == StatusCodes.Status200OK.ToString())
            {
                return Ok(response);
            }
            if (response.Response == StatusCodes.Status404NotFound.ToString())
            {
                return NotFound(response);
            }
            if (response.Response == StatusCodes.Status500InternalServerError.ToString())
            {
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
            else
            {
                return BadRequest(response);
            }
        }

        // POST api/<PeopleController>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePeopleDto input)
        {
            var response = await _people.Create(input);

            if (response.Response == StatusCodes.Status201Created.ToString())
            {
                return Created("Ok", response);
            }
            if (response.Response == StatusCodes.Status500InternalServerError.ToString())
            {
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
            else
            {
                return BadRequest(response);
            }
        }

        // PUT api/<PeopleController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(UpdatePeopleDto input)
        {
            var response = await _people.UpdateAsync(input);

            if (response.Response == StatusCodes.Status201Created.ToString())
            {
                return Created("Ok", response);
            }
            if (response.Response == StatusCodes.Status404NotFound.ToString())
            {
                return NotFound(response);
            }
            if (response.Response == StatusCodes.Status500InternalServerError.ToString())
            {
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
            else
            {
                return BadRequest(response);
            }
        }

        // DELETE api/<PeopleController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _people.DeleteAsync(id);

            if (response.Response == StatusCodes.Status201Created.ToString())
            {
                return Created("Ok", response);
            }
            if (response.Response == StatusCodes.Status404NotFound.ToString())
            {
                return NotFound(response);
            }
            if (response.Response == StatusCodes.Status500InternalServerError.ToString())
            {
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
            else
            {
                return BadRequest(response);
            }
        }
    }
}
