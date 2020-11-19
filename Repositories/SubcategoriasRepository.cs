using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SIMAS.Areas.Administrador.Models;
using SIMAS.Models;
using SIMAS.Repositories;

namespace SIMAS.Repositories
{
    public class SubcategoriasRepository:Repository<Subcategorias>
    {
        public IEnumerable<Subcategorias> GetSubcategorias()
        {
            return GetAll().OrderBy(x => x.Nombre);
        }

        public Subcategorias GetSubcategoriasByNombre(string nombre)
        {
            return Context.Subcategorias.FirstOrDefault(x => x.Nombre.ToUpper() == nombre.ToUpper());
        }

        public IEnumerable<Subcategorias> GetSubcategoriasByCategoria(string categoria)
        {
            return Context.Subcategorias.Include( x => x.IdCategoriaNavigation)
                .Where(x => x.IdCategoriaNavigation.Nombre == categoria);
        }

    }
}
