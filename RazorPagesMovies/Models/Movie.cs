using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesMovies.Models
{
    public class Movie
    {
        public int ID { get; set; } //identificador para cada pelicula
        public string Title { get; set; } //nombre de la pelicula
        [Display(Name = "Release Date")]

        [DataType(DataType.Date)] //tipo de dato que utilizara la variable ReleaseDate(si es de tipo date solo se verá la fecha)
        public DateTime ReleaseDate { get; set; } //fecha de lanzamiento
        public string Genre { get; set; } //genero
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; } //precio de la pelicula

    }
}
