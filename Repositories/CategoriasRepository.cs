using SIMAS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SIMAS.Areas.Administrador.Models.ViewModels;

namespace SIMAS.Repositories
{
    public class CategoriasRepository: Repository<Categorias>
    {
        public IEnumerable<Categorias> GetCategorias()
        {
            return GetAll().OrderBy(x => x.Nombre);
        }

        public Categorias GetCategoriasByNombre(string nombre)
        {
           return Context.Categorias.FirstOrDefault(x => x.Nombre.ToUpper() == nombre.ToUpper());
        }
    }
}
