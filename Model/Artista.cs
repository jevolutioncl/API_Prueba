using System.ComponentModel.DataAnnotations;

namespace API_Prueba.Model
{
    public class Artista
    {
        [Key]
        public int IdArtista { get; set; }
        public string NombreArtista { get; set; }
        public string GeneroMusical { get; set; }
    }
}
