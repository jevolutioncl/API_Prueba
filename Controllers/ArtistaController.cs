using API_Prueba.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Prueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistaController : ControllerBase
    {

        private readonly ApiDbContext _apiDbContext;
        public ArtistaController(ApiDbContext apiDbContext)
        {
            _apiDbContext = apiDbContext;
        }

        [HttpGet]
        [Route("getAllArtistas")]
        public async Task<IActionResult> getAllArtistas()
        {
            var allArtistas = await _apiDbContext.Artistas.ToListAsync();
            return Ok(allArtistas);
        }

        [HttpPost]
        [Route("addArtistas")]

        public async Task<IActionResult> addArtistas(Artista A)
        {
            if(A != null)
            {
                _apiDbContext.Artistas.Add(A);
                await _apiDbContext.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("uptArtista")]
        public async Task<IActionResult> uptArtista(int IdArtista, Artista A)
        {
            var artista = await _apiDbContext.Artistas.FindAsync(IdArtista);
            if(artista != null && A != null)
            {
                artista.NombreArtista = A.NombreArtista;
                artista.GeneroMusical = A.GeneroMusical;
                await _apiDbContext.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete]
        [Route("delArtista")]
        public async Task<IActionResult> delArtista(int IdArtista)
        {
            var artista = await _apiDbContext.Artistas.FindAsync(IdArtista);
            if(artista != null)
            {
                _apiDbContext.Remove(artista);
                await _apiDbContext.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("getArtistaById")]
        public async Task<IActionResult> getArtistaById(int IdArtista)
        {
            var artista = await _apiDbContext.Artistas.FindAsync(IdArtista);
            if(artista != null)
            {
                return Ok(artista);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
