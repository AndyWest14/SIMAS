using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIMAS.Areas.Administrador.Models.ViewModels
{
    public class SubcategoriasViewModel
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public int IdCategoria { get; set; }
    }
}
