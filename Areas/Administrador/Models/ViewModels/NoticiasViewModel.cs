using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SIMAS.Areas.Administrador.Models
{
    public class NoticiasViewModel
    {
        public int idNoticias { get; set; }

        [Required(ErrorMessage = "El Titulo de la noticia es obligatorio")]
        [MaxLength(100, ErrorMessage = "El Titulo de la noticia no debe sobrepasar los 100 caracteres")]
        public string Encabezado { get; set; }

        [Required(ErrorMessage = "La Fecha de la noticia es obligatoria")]
        public DateTime Fecha { get; set; }

        [MaxLength(45, ErrorMessage = "El autor de la noticia no debe sobrepasar los 45 caracteres")]
        public string Autor { get; set; }

        [Required(ErrorMessage = "La descripción corta de la noticia es obligatorio")]
        public string DescripcionCorta { get; set; }

        [Required(ErrorMessage = "El cuerpo o contenido de la noticia es obligatorio")]
        public string Cuerpo { get; set; }

        [Url]
        public string VideoURL { get; set; }

        [NotMapped]
        public IFormFile Foto { get; set; }

        public List<IFormFile> Fotos { get; set; }
    }
}

