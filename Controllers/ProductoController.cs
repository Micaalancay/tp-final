using Microsoft.AspNetCore.Mvc;
using tp_final.Repository;
using tp_final.ResponseQuery;
using tp_final.Modelo;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace tp_final.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly INorthwindRepository _repository;

        public ProductoController(INorthwindRepository repository)
        {
            this._repository = repository;
        }


        /// <summary>
        /// Obtiene todos los productos junto con su categoría.
        /// </summary>
        /// <returns>Lista de productos con su categoría.</returns>
        [HttpGet("ObtenerProductosConCategoria")]
        public async Task<ActionResult<List<ProductoCategoriaResponse>>> ObtenerProductosConCategoria()
        {
            return await _repository.ObtenerProductosyCategorias();
        }

        /// <summary>
        /// Obtiene todos los productos que contienen una palabra en su nombre.
        /// </summary>
        /// <param name="palabra">Palabra a buscar dentro del nombre del producto.</param>
        /// <returns>Lista de productos que coinciden con la palabra.</returns>

        [HttpGet("ObtenerProductosQueContienen")]
        public async Task<ActionResult<List<Products>>> GetProductsThatContain([FromQuery] string palabra)
        {
            var productos = await _repository.ObtenerProductosQueContienen(palabra);
            if (productos == null || productos.Count == 0)
                return NotFound($"No se encontró ningún producto que contenga la palabra {palabra}");

            return Ok(productos);
           
        }
    }
}
