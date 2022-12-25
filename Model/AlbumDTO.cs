using System.ComponentModel.DataAnnotations;

namespace API_Prueba.Model
{
    public class AlbumDTO
    {
        [Key]
        public int IdAlbum { get; set; }
        public string NombreAlbum { get; set; }
        public string Año { get; set; }
        public string Nota { get; set; }
        public int IdArtista { get; set; }
    }
}
