using System;
using System.Collections.Generic;

namespace SIMAS.Models
{
    public partial class Fotosnoticia
    {
        public int IdFoto { get; set; }
        public int IdNoticia { get; set; }

        public Noticias IdNoticiaNavigation { get; set; }
    }
}
