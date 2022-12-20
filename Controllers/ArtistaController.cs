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
    }
}
