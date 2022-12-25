using API_Prueba.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Prueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        private readonly ApiDbContext _apiDbcontext;

        public AlbumController(ApiDbContext apiDbcontext)
        {
            _apiDbcontext = apiDbcontext;
        }

        [HttpPost]
        [Route("GuardarNuevoAlbum")]
        public async Task<IActionResult> GuardarNuevoAlbum(AlbumDTO Cdto)
        {
            Album C = new Album()
            {
                IdAlbum = Cdto.IdAlbum,
                NombreAlbum = Cdto.NombreAlbum,
                Año = Cdto.Año,
                Nota = Cdto.Nota,
                IdArtista = Cdto.IdArtista
            };

            _apiDbcontext.Add(C);
            await _apiDbcontext.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        [Route("LeerAlbum")]
        public async Task<IActionResult> LeerAlbum()
        {
            var album = await _apiDbcontext.Albums.ToListAsync();
            return Ok(album);
        }

        [HttpPut]
        [Route("uptAlbum")]
        public async Task<IActionResult> uptAlbum(int IdAlbum, AlbumDTO B)
        {
            var album = await _apiDbcontext.Albums.FindAsync(IdAlbum);
            if (album != null && B != null)
            {
                album.NombreAlbum = B.NombreAlbum;
                album.Año = B.Año;
                album.Nota = B.Nota;
                album.IdArtista = B.IdArtista;
                await _apiDbcontext.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete]
        [Route("delAlbum")]
        public async Task<IActionResult> delAlbum(int IdAlbum)
        {
            var album = await _apiDbcontext.Albums.FindAsync(IdAlbum);
            if (album != null)
            {
                _apiDbcontext.Remove(album);
                await _apiDbcontext.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
