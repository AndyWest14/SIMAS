using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.IO;
using SIMAS.Models;
using SIMAS.Areas.Administrador.Models;


namespace SIMAS.Repositories
{
    public class NoticiasRepository : Repository<Noticias>
    {   
        public IEnumerable<Noticias> GetNoticias()
        {
            return GetAll().OrderBy(x => x.Encabezado);      
        }

        public Noticias GetNoticiasByNombre (string encabezado)
        {
            return GetAll().FirstOrDefault(x => x.Encabezado == encabezado);
            //return Context.Noticias.FirstOrDefault(x => x.Encabezado.ToUpper() == encabezado.ToUpper());
        }

        public NoticiasViewModel NoticiaById(int Id)
        {
            return Context.Noticias.Where(x => x.IdNoticias == Id)
                .Select(x => new NoticiasViewModel
                {
                    idNoticias = x.IdNoticias,
                    Encabezado = x.Encabezado,
                    Fecha = x.Fecha,
                    Autor = x.Autor,
                    DescripcionCorta = x.DescripcionCorta,
                    Cuerpo = x.Cuerpo,
                    VideoURL = x.VideoUrl


                }).FirstOrDefault();
        }

        public NoticiasViewModel GetNoticiaByFecha(DateTime fecha)
        {
            return Context.Noticias.Where(x => x.Fecha == fecha)
                .Select(x => new NoticiasViewModel
                {
                    idNoticias = x.IdNoticias,
                    Encabezado = x.Encabezado,
                    Fecha = x.Fecha,
                    Autor = x.Autor,
                    DescripcionCorta = x.DescripcionCorta,
                    Cuerpo = x.Cuerpo,
                    VideoURL = x.VideoUrl

                }).FirstOrDefault();
        }

        public void Insert(NoticiasViewModel noticiasViewModel)
        {
            Noticias noticias = new Noticias
            {
                Encabezado = noticiasViewModel.Encabezado,
                Fecha = noticiasViewModel.Fecha,
                Autor = noticiasViewModel.Autor,
                DescripcionCorta = noticiasViewModel.DescripcionCorta,
                Cuerpo = noticiasViewModel.Cuerpo,
                VideoUrl = noticiasViewModel.VideoURL
            };

            Insert(noticias);
            noticiasViewModel.idNoticias = noticias.IdNoticias;
        }

        public void Update(NoticiasViewModel noticiasViewModel)
        {
            var noticiaResult = Context.Noticias.FirstOrDefault(x => x.IdNoticias == noticiasViewModel.idNoticias);
           // var noticiaResult = GetById(noticiasViewModel.idNoticias);
            if (noticiaResult != null)
            {
                noticiaResult.Encabezado = noticiasViewModel.Encabezado;
                noticiaResult.Fecha = DateTime.Now;
                noticiaResult.Autor = noticiasViewModel.Autor;
                noticiaResult.DescripcionCorta = noticiasViewModel.DescripcionCorta;
                noticiaResult.Cuerpo = noticiasViewModel.Cuerpo;
                noticiaResult.VideoUrl = noticiasViewModel.VideoURL;

                Update(noticiaResult);
            }
        }

        public void SetNoPhoto(int id, string path)
        {
            var origen = Path.Combine(path, "noticias", "Logosimas.jpg");
            var destino = Path.Combine(path, "noticias", $"{id}.jpg");
            File.Copy(origen, destino);
        }


        public void GuardarArchivo(int id, IFormFile archivo, string path)
        {
            var ruta = Path.Combine(path, "noticias", id + ".jpg");
            FileStream fs = File.Create(ruta);
            archivo.CopyTo(fs);
            fs.Close();
        }
    }
}
