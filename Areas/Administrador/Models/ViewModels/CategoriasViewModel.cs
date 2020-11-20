using System;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SIMAS.Areas.Administrador.Models
{
    public class CategoriasViewModel
    {
        public int IdCategoria { get; set; }

        [Required(ErrorMessage = "El nombre de la categoria es obligatorio")]
        [MaxLength(45, ErrorMessage = "El Nombre del documento no puede sobrepasar los 45 caracteres")]
        public string Nombre { get; set; }
    }
}
