using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SIMAS.Repositories;
using SIMAS.Models;
using SIMAS.Areas.Administrador.Models.ViewModels;

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

    }
}
