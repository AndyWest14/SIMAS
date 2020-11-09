using System;
using System.Collections.Generic;

namespace SIMAS.Models
{
    public partial class Documento
    {
        public int IdDocumento { get; set; }
        public string Nombre { get; set; }
        public int IdCategoria { get; set; }
        public int IdSubCategoria { get; set; }

        public Categorias IdCategoriaNavigation { get; set; }
        public Subcategorias IdSubCategoriaNavigation { get; set; }
    }
}
