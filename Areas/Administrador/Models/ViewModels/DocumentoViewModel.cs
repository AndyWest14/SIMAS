
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SIMAS.Models.ViewModels
{
    public class DocumentoViewModel
    {
        public int IdDocumento { get; set; }

        [Required(ErrorMessage = "El nombre del es obligatorio")]
        [MaxLength(200, ErrorMessage = "El Nombre del documento no puede sobrepasar los 200 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La categoria es obligatoria")]
        public int IdCategoria { get; set; }

        [Required(ErrorMessage = "La subcategoria es obligatoria")]
        public int IdSubCategoria { get; set; }

    }
}
