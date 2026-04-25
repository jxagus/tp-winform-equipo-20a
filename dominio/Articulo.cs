using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Articulo
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public Marca Marca { get; set; }
        public Categoria Categoria { get; set; }
        public decimal Precio { get; set; }

        //public string ImagenUrl { get; set; }
        public List<Imagen> Imagenes { get; set; } = new List<Imagen>();

        [DisplayName("Descripción")] 
        public string Descripcion { get; set; }
        [DisplayName("Categoría")]
        public string NombreCategoria
        {
            get { return (Categoria != null && Categoria.Descripcion != null) ? Categoria.Descripcion : "Sin Categoría"; }
        }

        [DisplayName("Marca")]
        public string NombreMarca
        {
            get { return (Marca != null && Marca.Descripcion != null) ? Marca.Descripcion : "Sin Marca"; }
        }




    }
}
