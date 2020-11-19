using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SIMAS.Repositories;
using SIMAS.Models;
using SIMAS.Areas.Administrador.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace SIMAS.Repositories
{
    public class DocumentosRepository : Repository<Documento>
    {
        public IEnumerable<Documento> GetDocumentos()
        {
            return GetAll().OrderBy(x => x.Nombre);
        }

        public Documento GetDocumentoByNombre(string nombre)
        {
            return Context.Documento.FirstOrDefault(x => x.Nombre.ToUpper() == nombre.ToUpper());
        }

        public DocumentoViewModel DocumentoById(int Id)
        {
            return Context.Documento.Where(x => x.IdDocumento == Id)
                .Select(x => new DocumentoViewModel
                {
                    IdDocumento = x.IdDocumento,
                    Nombre = x.Nombre,
                    IdCategoria = x.IdCategoria,
                    IdSubCategoria = x.IdSubCategoria

                }).FirstOrDefault();
        }

        public IEnumerable<Documento> GetDocumentosByCategoria(string categoria)
        {
            categoria = categoria.Replace("-", " ");
            return Context.Documento.Include(x => x.IdCategoriaNavigation).Where(x => x.IdCategoriaNavigation.Nombre == categoria);
        }

        public IEnumerable<Documento> GetDocumentoBySubCategoria(string subcategoria)
        {
            subcategoria = subcategoria.Replace("-", " ");
            return Context.Documento.Include(x => x.IdSubCategoriaNavigation).Where(x => x.IdSubCategoriaNavigation.Nombre == subcategoria);
        }

        public void Insert(DocumentoViewModel vm)
        {
            Documento d = new Documento
            {
                Nombre = vm.Nombre,
                IdCategoria = vm.IdCategoria,
                IdSubCategoria = vm.IdSubCategoria
            };
            Insert(d);
            vm.IdDocumento = d.IdDocumento;
        }

        public void Update(DocumentoViewModel vm)
        {
            var d = Context.Documento.FirstOrDefault(x => x.IdDocumento == vm.IdDocumento);
            if (d != null)
            {
                d.Nombre = vm.Nombre;
                d.IdCategoria = vm.IdCategoria;
                d.IdSubCategoria = vm.IdSubCategoria;
            }
        }

     
    }
}
