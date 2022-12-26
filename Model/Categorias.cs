using System.ComponentModel.DataAnnotations;

namespace API_Prueba.Model
{
    public class categorias
    {
        [Key]
        public int CategoriaId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }
}
