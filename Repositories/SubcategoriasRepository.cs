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
        public IEnumerable<Subcategorias> GetSubcategoriasConNavigation()
        {
            return Context.Subcategorias.Include(x => x.IdCategoriaNavigation);
        }
        public Subcategorias GetSubcategoriasByNombreConNavigation(string nombre)
        {
            return Context.Subcategorias.Include(x => x.IdCategoriaNavigation)
                .FirstOrDefault(x => x.Nombre == nombre);
        }

        public SubcategoriasViewModel GetSubcategoriasById(int id)
        {
            return Context.Subcategorias.Where(x => x.Idsubcategorias == id)
                .Select(x => new SubcategoriasViewModel
                {
                    Id = x.Idsubcategorias,
                    Nombre = x.Nombre,
                    IdCategoria = x.IdCategoria
                }).FirstOrDefault();
        }

        public void Insert(SubcategoriasViewModel vm)
        {
            Subcategorias subcategorias = new Subcategorias
            {
                Nombre = vm.Nombre,
                IdCategoria = vm.IdCategoria
            };
            Insert(subcategorias);
            vm.Id = subcategorias.Idsubcategorias;
        }

        public void Update(SubcategoriasViewModel vm)
        {
            var s = Context.Subcategorias.FirstOrDefault(x => x.Idsubcategorias == vm.Id);
            if (s != null)
            {
                s.Idsubcategorias = vm.Id;
                s.Nombre = vm.Nombre;
                s.IdCategoria = vm.IdCategoria;
                Update(s);
            }
        }

    }
}
