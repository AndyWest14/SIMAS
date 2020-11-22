using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SIMAS.Repositories;
using SIMAS.Models;
namespace SIMAS.Services
{
    public class MenuService
    {

        public IEnumerable<Categorias> GetNombreCategorias()
        {
            CategoriasRepository categoriasRepository = new CategoriasRepository();
            var list = categoriasRepository.GetCategorias();
            return list;
        }

        public IEnumerable<Subcategorias> GetNombreSubcategorias()
        {
            SubcategoriasRepository subcategoriasRepository = new SubcategoriasRepository();
            var list = subcategoriasRepository.GetSubcategorias();
            return list;
        }

        public IEnumerable<Noticias> GetAllNoticias()
        {
            NoticiasRepository noticiasRepository = new NoticiasRepository();
            return noticiasRepository.GetAll();
        }

        public IEnumerable<string> GetAllNoticiasNombre()
        {
            NoticiasRepository noticiasRepository = new NoticiasRepository();
            return noticiasRepository.GetAll().Select(x => x.Encabezado);
        }

    }
}
