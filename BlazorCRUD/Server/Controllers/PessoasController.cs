using BlazorCRUD.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorCRUD.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PessoasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public PessoasController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Pessoa>>> Get()
        {
            return await _context.Pessoas.ToListAsync();
        }

        [HttpGet("{id}", Name = "obterPessoa")]
        public async Task<ActionResult<Pessoa>> Get(int id)
        {
            return await _context.Pessoas.FirstOrDefaultAsync(p => p.Id == id);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Pessoa pessoa)
        {
            _context.Add(pessoa);
            await _context.SaveChangesAsync();
            return new CreatedAtRouteResult("obterPessoa", new { id = pessoa.Id }, pessoa);
        }

        [HttpPut]
        public async Task<ActionResult> Put(Pessoa pessoa)
        {
            _context.Entry(pessoa).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var pessoa = new Pessoa { Id = id };
            _context.Remove(pessoa);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
