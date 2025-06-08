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
    [Authorize]    public class SkillsController : ControllerBase
    {
        private readonly SkillSnapContext _context;
        private readonly IMemoryCache _cache;
        private const string SKILLS_CACHE_KEY = "all_skills";
        private readonly TimeSpan _cacheExpiration = TimeSpan.FromMinutes(10);

        public SkillsController(SkillSnapContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Skill>>> GetSkills()
        {
            // Try to get from cache first
            if (_cache.TryGetValue(SKILLS_CACHE_KEY, out List<Skill>? cachedSkills))
            {
                return cachedSkills!;
            }            // If not in cache, get from database with optimized query
            var skills = await _context.Skills
                .AsNoTracking() // Performance optimization for read-only queries
                .OrderBy(s => s.Name) // Add consistent ordering by name
                .ToListAsync();            // Store in cache
            _cache.Set(SKILLS_CACHE_KEY, skills, _cacheExpiration);

            return Ok(skills);
        }        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<Skill>> GetSkill(int id)
        {
            // Cache individual skills by ID
            string cacheKey = $"skill_{id}";
            
            if (_cache.TryGetValue(cacheKey, out Skill? cachedSkill))
            {
                return cachedSkill!;
            }

            var skill = await _context.Skills
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.Id == id);

            if (skill == null)
            {
                return NotFound();
            }

            // Cache the individual skill
            _cache.Set(cacheKey, skill, _cacheExpiration);

            return skill;
        }        [HttpPost]
        public async Task<ActionResult<Skill>> AddSkill(Skill skill)
        {
            _context.Skills.Add(skill);
            await _context.SaveChangesAsync();

            // Invalidate cache when data changes
            _cache.Remove(SKILLS_CACHE_KEY);

            return CreatedAtAction("GetSkill", new { id = skill.Id }, skill);
        }        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSkill(int id, Skill skill)
        {
            if (id != skill.Id)
            {
                return BadRequest();
            }

            _context.Entry(skill).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                
                // Invalidate cache when data changes
                _cache.Remove(SKILLS_CACHE_KEY);
                _cache.Remove($"skill_{id}");
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SkillExists(id))
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
        public async Task<IActionResult> DeleteSkill(int id)
        {
            var skill = await _context.Skills.FindAsync(id);
            if (skill == null)
            {
                return NotFound();
            }

            _context.Skills.Remove(skill);
            await _context.SaveChangesAsync();

            // Invalidate cache when data changes
            _cache.Remove(SKILLS_CACHE_KEY);
            _cache.Remove($"skill_{id}");

            return NoContent();
        }

        private bool SkillExists(int id)
        {
            return _context.Skills.Any(e => e.Id == id);
        }
    }
}
