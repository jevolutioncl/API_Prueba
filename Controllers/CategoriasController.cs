using API_Prueba.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Prueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {

        private readonly ApiDbContext _apiDbContext;
        public CategoriasController(ApiDbContext apiDbContext)
        {
            _apiDbContext = apiDbContext;
        }

        [HttpGet]
        [Route("getAllCategorias")]
        public async Task<IActionResult> getAllCategorias()
        {
            var allCategorias = await _apiDbContext.Categorias.ToListAsync();
            return Ok(allCategorias);
        }

        [HttpPost]
        [Route("addCategorias")]

        public async Task<IActionResult> addCategorias(categorias A)
        {
            if(A != null)
            {
                _apiDbContext.Categorias.Add(A);
                await _apiDbContext.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("uptCategorias")]
        public async Task<IActionResult> uptCategorias(int CategoriaId, categorias A)
        {
            var categoria = await _apiDbContext.Categorias.FindAsync(CategoriaId);
            if(categoria != null && A != null)
            {
                categoria.Nombre = A.Nombre;
                categoria.Descripcion = A.Descripcion;
                await _apiDbContext.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete]
        [Route("delCategorias")]
        public async Task<IActionResult> delCategorias(int CategoriaId)
        {
            var categoria = await _apiDbContext.Categorias.FindAsync(CategoriaId);
            if(categoria != null)
            {
                _apiDbContext.Remove(categoria);
                await _apiDbContext.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("getCategoriasById")]
        public async Task<IActionResult> getCategoriasById(int CategoriaId)
        {
            var categoria = await _apiDbContext.Categorias.FindAsync(CategoriaId);
            if(categoria != null)
            {
                return Ok(categoria);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("getCategoriasByName")]

        public async Task<IActionResult> getCategoriasByName(string Nombre)
        {
            var categoria = await _apiDbContext.Categorias.FindAsync(Nombre);
            if (categoria != null)
            {
                return Ok(categoria);
            }
            else
            {
                return NotFound();
            }
        }
    }
}