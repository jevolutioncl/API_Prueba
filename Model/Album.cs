using System.ComponentModel.DataAnnotations;

namespace API_Prueba.Model
{
    public class Album
    {
        [Key]
        public int IdAlbum { get; set; }
        public string NombreAlbum { get; set; }
        public string Año { get; set; }
        public string Nota { get; set; }
        public Artista? Artista { get; set; }

    }
}
