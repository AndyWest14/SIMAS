using System;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace SIMAS.Models
{
    public class Categorias
    {
        public Categorias()
        {
            Documento = new HashSet<Documento>();
            Subcategorias = new HashSet<Subcategorias>();
        }

        public int IdCategoria { get; set; }
        public string Nombre { get; set; }

        public ICollection<Documento> Documento { get; set; }
        public ICollection<Subcategorias> Subcategorias { get; set; }
    }
}
