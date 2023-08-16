using API.Contexts;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ProductsController : ControllerBase
	{
		// Criando a variável de acesso ao contexto (banco de dados) StoreContext por meio de injeção de dependência
        private readonly StoreContext _context;

		public ProductsController(StoreContext context)
		{
            _context = context;
		}

		// Implementando métodos assincronos:
		// async na assinatura do método
		// Task<retorno do método>
		// await (no método de acesso ao banco de dados)
		[HttpGet]
		public async Task<ActionResult<List<Product>>> GetProducts()
		{
			var products = await _context.Products.ToListAsync();
			return Ok(products);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Product>> GetProduct(int id)
		{
			var product = await _context.Products.FindAsync(id);
			return Ok(product);
		}
	}
}