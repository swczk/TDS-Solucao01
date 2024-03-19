using Projeto02.Data;
using Projeto02.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Projeto02.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProdutoController : ControllerBase
{
   private readonly ProdutoContext _context;

   public ProdutoController(ProdutoContext context)
   {
      _context = context;
   }

   [HttpGet]
   public ActionResult<List<ProdutoModel>> Produtos()
   {
      return _context.Produtos.ToList();
   }

   [HttpGet("{id}")]
   public async Task<ActionResult<ProdutoModel?>> ProdutoByID(long id)
   {
      return await _context.Produtos.Where(p => p.ProdutoID.Equals(id)).FirstAsync();
   }

   [HttpPost]
   public async Task<ActionResult<ProdutoModel>> ProdutoAdd(ProdutoModel produto)
   {
      _context.Add(produto);
      await _context.SaveChangesAsync();

      return CreatedAtAction("Produto", produto);
   }

   [HttpPut("{id}")]
   public async Task<ActionResult<ProdutoModel>> ProdutoUpdate(long id, ProdutoModel produto)
   {
      if (id != produto.ProdutoID)
         return BadRequest();
      
      _context.Entry(produto).State = EntityState.Modified;

      await _context.SaveChangesAsync();

      return NoContent();
   }

   [HttpDelete("{id}")]
   public async Task<ActionResult<ProdutoModel>> ProdutoDelete(long id) {
      var produto = await ProdutoByID(id);
      _context.Remove<ProdutoModel>(produto.Value!);
      await _context.SaveChangesAsync();

      return Ok();
   }

}
