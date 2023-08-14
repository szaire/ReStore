using API.Contexts;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ProductsController : ControllerBase
	{
		// Criando a variável de acesso ao contexto (banco de dados) StoreContext
		private readonly StoreContext context;

		public ProductsController(StoreContext context)
		{
			this.context = context;
		}

		[HttpGet]
		public ActionResult<List<Product>> GetProducts()
		{
			var products = context.Products.ToList();
			return Ok(products);
		}

		[HttpGet("{id}")]
		public ActionResult<Product> GetProduct(int id)
		{
			var product = context.Products.Find(id);

			return Ok(product);
		}
	}
}