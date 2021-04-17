using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontEnd.DAL
{
    public class PeliculasRepository
    {
        public List<Pelicula> GetPeliculas()
        {
            var list = new List<Pelicula>();
            Pelicula pelicula = new Pelicula { Titulo = "Dragon Ball", Cartelera = false, Genero = "Anime" };
            list.Add(pelicula);
            pelicula = new Pelicula { Titulo = "Shazam", Cartelera = true, Genero = "DC" };
            list.Add(pelicula);
            pelicula = new Pelicula { Titulo = "<b>Movie WWE</b>", Cartelera = true, Genero = "Acccion" };
            list.Add(pelicula);

            return list;
        }

        public List<SelectListItem> GetData()
        {

            var listado = new List<SelectListItem>() {
                                new SelectListItem(){ Text = "House", Value = "1"},
                                new SelectListItem(){ Text = "Roots", Value ="2"},
                                new SelectListItem(){ Text = "Trova", Value ="3", Disabled = true}
                                                    };

            return listado;
        }
    }
}
