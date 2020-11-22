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

        public DocumentoViewModel GetDocumentoById(int Id)
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

        public IEnumerable<Documento> GetDocumentoConNavigationCategoria()
        {
            return Context.Documento.Include(x => x.IdCategoriaNavigation);
        }

        public IEnumerable<Documento> GetDocumentoConNavigationSubcategoria()
        {
            return Context.Documento.Include(x => x.IdSubCategoriaNavigation);
        }


        public void Insert(DocumentoViewModel vm)
        {
            Documento d = new Documento
            {
                IdDocumento = vm.IdDocumento,
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
                d.IdDocumento = vm.IdDocumento;
                d.Nombre = vm.Nombre;
                d.IdCategoria = vm.IdCategoria;
                d.IdSubCategoria = vm.IdSubCategoria;
                Update(d);
            }
        }

        public void GuardarArchivo(int id, IFormFile documento, string path)
        {
            var ruta = Path.Combine(path, "DocumentosLGCG", id + ".pdf");
            FileStream fs = File.Create(ruta);
            documento.CopyTo(fs);
            fs.Close();
        }

    }
}
