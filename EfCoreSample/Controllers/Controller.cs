using EfCoreSample.Doman.DTO;
using EfCoreSample.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EfCoreSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly ProjectService _db;

        public ProjectController(ProjectService db)
        {
            _db = db;
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<List<ProjectDTO>>> Get()
        {
            try
            {
                return await _db.GetAsync<List<ProjectDTO>>(s => s.Id.Equals(condit));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Database Failure");
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectDTO>> Get(long id)
        {
            try
            {
                var dto = await _db.FindAsync<ProjectDTO>(id);
                if (dto == null) return NotFound();
                return dto;
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Database Failure");
            }
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<ProjectDTO>> Post(ProjectDTO dto)
        {
            if (dto == null) return BadRequest("No entity provided");
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                var id = await _db.CreateAsync<CourseDTO, Course>(model);
                if (id < 1) return BadRequest("Unable to add the entity");
                var entity = await _db.SingleAsync<Course, CourseDTO>(s =>
                s.Id.Equals(id));
                if (dto == null) return BadRequest(
                "Unable to add the entity");
                return CreatedAtRoute("FindAsync",
                new { publisherId = entity.Id}, bookToAdd);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Failed to add the entity");
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            if (book == null) return BadRequest();
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var bookToUpdate = _repository.GetBook(publisherId, bookId);
            if (bookToUpdate == null) return NotFound();
            _repository.UpdateBook(publisherId, bookId, book);
            _repository.Save();
            return NoContent();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var bookToDelete = _repository.GetBook(publisherId, bookId);
            if (bookToDelete == null) return NotFound();
            _repository.DeleteBook(bookToDelete);
            _repository.Save();
            return NoContent();
        }
    }
}
