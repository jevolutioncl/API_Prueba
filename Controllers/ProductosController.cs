using API_Prueba.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Prueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly ApiDbContext _apiDbcontext;

        public ProductosController(ApiDbContext apiDbcontext)
        {
            _apiDbcontext = apiDbcontext;
        }

        [HttpPost]
        [Route("GuardarNuevoProducto")]
        public async Task<IActionResult> GuardarNuevoProducto(ProductosDTO Cdto)
        {
            Productos C = new Productos()
            {
                ProductoId = Cdto.ProductoId,
                Nombre = Cdto.Nombre,
                Descripcion = Cdto.Descripcion,
                Precio = Cdto.Precio,
                Stock = Cdto.Stock,
                Imagen = Cdto.Imagen,
                CategoriaId = Cdto.CategoriaId
            };

            _apiDbcontext.Add(C);
            await _apiDbcontext.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        [Route("LeerProducto")]
        public async Task<IActionResult> LeerProducto()
        {
            var producto = await _apiDbcontext.Productos.ToListAsync();
            return Ok(producto);
        }

        [HttpPut]
        [Route("uptProducto")]
        public async Task<IActionResult> uptProducto(int ProductoId, ProductosDTO B)
        {
            var producto = await _apiDbcontext.Productos.FindAsync(ProductoId);
            if (producto != null && B != null)
            {
                producto.Nombre = B.Nombre;
                producto.Descripcion = B.Descripcion;
                producto.Precio = B.Precio;
                producto.Stock = B.Stock;
                producto.Imagen = B.Imagen;
                producto.CategoriaId = B.CategoriaId;
                await _apiDbcontext.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete]
        [Route("delProducto")]
        public async Task<IActionResult> delProducto(int ProductoId)
        {
            var producto = await _apiDbcontext.Productos.FindAsync(ProductoId);
            if (producto != null)
            {
                _apiDbcontext.Remove(producto);
                await _apiDbcontext.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("getProductoById")]
        public async Task<IActionResult> getProductoById(int ProductosId)
        {
            var producto = await _apiDbcontext.Productos.FindAsync(ProductosId);
            if (producto != null)
            {
                return Ok(producto);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpGet]
        [Route("getProductoByCategoria")]
        public async Task<IActionResult> getProductoByCategoria(int CategoriaId)
        {
            var producto = await _apiDbcontext.Productos.FindAsync(CategoriaId);
            if (producto != null)
            {
                return Ok(producto);
            }
            else
            {
                return NotFound();
            }
        }
    }
}