using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using SkillSnap.Api.Models;
using System.Security.Claims;

namespace SkillSnap.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]    public class ProjectsController : ControllerBase
    {
        private readonly SkillSnapContext _context;
        private readonly IMemoryCache _cache;
        private const string PROJECTS_CACHE_KEY = "all_projects";
        private readonly TimeSpan _cacheExpiration = TimeSpan.FromMinutes(10);

        public ProjectsController(SkillSnapContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Project>>> GetProjects()
        {
            // Try to get from cache first
            if (_cache.TryGetValue(PROJECTS_CACHE_KEY, out List<Project>? cachedProjects))
            {
                return cachedProjects!;
            }

            // If not in cache, get from database with optimized query
            var projects = await _context.Projects
                .AsNoTracking() // Performance optimization for read-only queries
                .OrderBy(p => p.Title) // Add consistent ordering
                .ToListAsync();

            // Store in cache
            _cache.Set(PROJECTS_CACHE_KEY, projects, _cacheExpiration);

            return projects;
        }        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<Project>> GetProject(int id)
        {
            // Cache individual projects by ID
            string cacheKey = $"project_{id}";
            
            if (_cache.TryGetValue(cacheKey, out Project? cachedProject))
            {
                return cachedProject!;
            }

            var project = await _context.Projects
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);

            if (project == null)
            {
                return NotFound();
            }

            // Cache the individual project
            _cache.Set(cacheKey, project, _cacheExpiration);

            return project;
        }        [HttpPost]
        public async Task<ActionResult<Project>> AddProject(Project project)
        {
            _context.Projects.Add(project);
            await _context.SaveChangesAsync();

            // Invalidate cache when data changes
            _cache.Remove(PROJECTS_CACHE_KEY);

            return CreatedAtAction("GetProject", new { id = project.Id }, project);
        }        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProject(int id, Project project)
        {
            if (id != project.Id)
            {
                return BadRequest();
            }

            _context.Entry(project).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                
                // Invalidate cache when data changes
                _cache.Remove(PROJECTS_CACHE_KEY);
                _cache.Remove($"project_{id}");
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }

            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();

            // Invalidate cache when data changes
            _cache.Remove(PROJECTS_CACHE_KEY);
            _cache.Remove($"project_{id}");

            return NoContent();
        }

        private bool ProjectExists(int id)
        {
            return _context.Projects.Any(e => e.Id == id);
        }
    }
}
