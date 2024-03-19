using Projeto02.Model;
using Microsoft.EntityFrameworkCore;

namespace Projeto02.Data;

public class ProdutoContext : DbContext
{
  public ProdutoContext(DbContextOptions<ProdutoContext> options) : base(options) {

  }

  public DbSet<ProdutoModel> Produtos { get; set; }
}
