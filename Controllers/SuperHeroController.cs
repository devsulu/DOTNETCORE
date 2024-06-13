using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperHero.API.Data;

namespace SuperHero.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly DataDbContext _context;

        public SuperHeroController(DataDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> ListSuperHero()
        {
            return Ok(await _context.superHeroes.ToListAsync());
        }
        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> CreateSuperHero(SuperHero hero)
        {
            _context.superHeroes.Add(hero);
            await _context.SaveChangesAsync();
            return Ok(await _context.superHeroes.ToListAsync());
        }
        [HttpPut]
        public async Task<ActionResult<List<SuperHero>>> UpdateSuperHero(SuperHero hero)
        {
            var dbHero = await _context.superHeroes.FindAsync(hero.Id);
            if (dbHero == null)
                return BadRequest("Hero not found");

            dbHero.Name = hero.Name;
            dbHero.FirstName = hero.FirstName;
            dbHero.LastName = hero.LastName;
            dbHero.Place = hero.Place;
            await _context.SaveChangesAsync();
            return Ok(await _context.superHeroes.ToListAsync());
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> DeleteSuperHero(int id)
        {
            var dbHero =await _context.superHeroes.FindAsync(id);
            if (dbHero == null)
                return BadRequest("Hero not found");
             _context.superHeroes.Remove(dbHero);
            await _context.SaveChangesAsync();
            return Ok(await _context.superHeroes.ToListAsync());
        }
    }
}
