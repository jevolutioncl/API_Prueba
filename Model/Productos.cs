using System.ComponentModel.DataAnnotations;

namespace API_Prueba.Model
{
    public class Productos
    {
        [Key]
        public int ProductoId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Precio { get; set; }
        public int Stock { get; set; }
        public string Imagen { get; set; }
        
        public int CategoriaId { get; set; } 
        public categorias? Categorias { get; set; }

    }
}
