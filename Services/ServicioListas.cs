using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SIMAS.Repositories;
using SIMAS.Models;

namespace SIMAS.Services
{
    public class ServicioListas
    {
        public IEnumerable<Noticias> GetAllNoticias()
        {
            NoticiasRepository noticiasRepository = new NoticiasRepository();
            return noticiasRepository.GetAll();
        }

        public IEnumerable<string> GetAllNoticias_Encabezado()
        {
            NoticiasRepository noticiasRepository = new NoticiasRepository();
            return noticiasRepository.GetAll().Select(x => x.Encabezado);
        }
    }
}
