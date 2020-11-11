using System;
using System.Collections.Generic;

namespace SIMAS.Models
{
    public partial class Noticias
    {
        public Noticias()
        {
            Fotosnoticia = new HashSet<Fotosnoticia>();
        }

        public int IdNoticias { get; set; }
        public string Encabezado { get; set; }
        public DateTime Fecha { get; set; }
        public string Autor { get; set; }
        public string DescripcionCorta { get; set; }
        public string Cuerpo { get; set; }
        public string VideoUrl { get; set; }

        public ICollection<Fotosnoticia> Fotosnoticia { get; set; }
    }
}
