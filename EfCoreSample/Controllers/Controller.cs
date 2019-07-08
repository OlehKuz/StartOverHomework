using AutoMapper;
using EfCoreSample.Doman.DTO;
using EfCoreSample.Doman.Entities;
using EfCoreSample.Infrastructure.Abstraction;
using EfCoreSample.Infrastructure.Extensions;
using EfCoreSample.Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
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
        private readonly IService<Project, ProjectDTO, long> _dbService;
        private readonly LinkGenerator _link;
        private readonly IMapper _mapper;


        public ProjectController(IService<Project, ProjectDTO, long> dbService, IMapper mapper, LinkGenerator link)
        {
            _dbService = dbService;
            _link = link;
            _mapper = mapper;
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<List<ProjectDTO>>> Get()
        {
            try
            {
                return await _dbService.GetAsync<List<ProjectDTO>>(s => s.Id.Equals(condit));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Database Failure");
            }
        }

        // GET api/values/5
        [HttpGet("{id:long}")]
        public async Task<ActionResult<ProjectDTO>> Get(long id)
        {
            try
            {
                var entity = await _dbService.FindAsync(id);
                if (entity == null) return NotFound();
                return _mapper.Map<ProjectDTO>(entity);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Database Failure");
            }
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<ProjectDTO>> Post(SaveProjectDTO saveDto)
        {
            if (saveDto == null) return BadRequest("No entity provided");
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var entity = _mapper.Map<Project>(saveDto);
            try
            {
                var id = await _dbService.InsertAsync(entity);
                if (id < 1) return BadRequest("Unable to add the entity");
                return Created(_link.GetPathByAction("Get", "Project", new { id }), entity);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Failed to add the entity");
            }
        }

        // PUT api/values/5
        [HttpPut("{id:long}")]
        public async Task<ActionResult> Put(long id, ProjectDTO projectDTO)
        {
            if (projectDTO == null) return BadRequest("No entity provided");
            if (!id.Equals(projectDTO.Id)) return BadRequest("Differing ids");
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            try
            {
                var entity = await _dbService.FindAsync(id);
                if (entity == null) return NotFound();
                if (_dbService.Update(entity).Result) return NoContent();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Failed to update the entity");
            }
            return BadRequest("Unable to update the entity");
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            try
            {
                var entity = await _dbService.FindAsync(id);
                if (entity == null) return NotFound();
                if (await _dbService.DeleteAsync(id)) return NoContent();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Failed to delete the entity");
            }
            return BadRequest("Unable to delete the entity");
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(ProjectDTO projectDTO)
        {           
            try
            {
                var entity = await _dbService.FindAsync(projectDTO.Id);
                if (entity == null) return NotFound();
                if (await _dbService.DeleteAsync(entity)) return NoContent();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Failed to delete the entity");
            }
            return BadRequest("Unable to delete the entity");
        }
    }
}
