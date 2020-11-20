using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SIMAS.Areas.Administrador.Models
{
    public class SubcategoriasViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre de la subcategoria es obligatorio")]
        [MaxLength(100, ErrorMessage = "El Nombre de la subcategoria no puede sobrepasar los 100 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La categoria es obligatorio")]
        public int IdCategoria { get; set; }
    }
}
