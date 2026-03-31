using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyApp.Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        [HttpGet("all")]
        public List<People> GetPeoples()
        {
            return Repository.People;
        }
        [HttpGet("{id}")]
        public ActionResult<People> GetPeopleById(int id)
        {
            var person = Repository.People.FirstOrDefault(p => p.Id == id);
            if (person == null)
            {
                return NotFound();
            }
            return Ok(person);
        }

        [HttpGet("search/{search}")]
        public List<People> Get(string search)
        {
            return Repository.People.Where(p => p.Name.ToUpper().Contains(search.ToUpper())).ToList();
        }

        [HttpPost]
        public IActionResult Add(People people)
        {
            if (people == null || string.IsNullOrEmpty(people.Name))
            {
                return BadRequest("El nombre es obligatorio.");
            }

            people.Id = Repository.People.Max(p => p.Id) + 1; // Genera un nuevo ID
            Repository.People.Add(people);
            return CreatedAtAction(nameof(GetPeopleById), new { id = people.Id }, people);
        }
    }

     public class Repository
    {
        public static List<People> People = new List<People>
        {
            new People { Id = 1, Name = "Alice", BirthDate = new DateTime(1990, 1, 1) },
            new People { Id = 2, Name = "Bob", BirthDate = new DateTime(1985, 5, 23) },
            new People { Id = 3, Name = "Charlie", BirthDate = new DateTime(2000, 12, 15) }
        };
    }
    public class People
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
    }



}
