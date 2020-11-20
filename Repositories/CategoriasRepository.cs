using SIMAS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SIMAS.Areas.Administrador.Models;

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

        public CategoriasViewModel GetCategoriaById(int Id)
        {
            return Context.Categorias.Where(x => x.IdCategoria == Id)
                .Select(x => new CategoriasViewModel
                {
                    IdCategoria = x.IdCategoria,
                    Nombre = x.Nombre
                }).FirstOrDefault();
        }

        public void Insert(CategoriasViewModel vm)
        {
            Categorias categorias = new Categorias
            {
                IdCategoria = vm.IdCategoria,
                Nombre = vm.Nombre
            };
            Insert(categorias);
            vm.IdCategoria = categorias.IdCategoria;
        }

        public void Update(CategoriasViewModel vm)
        {
            var a = Context.Categorias.FirstOrDefault(x => x.IdCategoria == vm.IdCategoria);
            if (a != null)
            {
                a.IdCategoria = vm.IdCategoria;
                a.Nombre = vm.Nombre;
                Update(a);
            }
        }
    }

}
