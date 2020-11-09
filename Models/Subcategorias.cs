using System;
using System.Collections.Generic;

namespace SIMAS.Models
{
    public partial class Subcategorias
    {
        public Subcategorias()
        {
            Documento = new HashSet<Documento>();
        }

        public int Idsubcategorias { get; set; }
        public string Nombre { get; set; }
        public int IdCategoria { get; set; }

        public Categorias IdCategoriaNavigation { get; set; }
        public ICollection<Documento> Documento { get; set; }
    }
}
