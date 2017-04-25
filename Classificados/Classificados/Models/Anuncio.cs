using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Classificados.Models
{
    public class Anuncio
    {
        public int AnuncioID { get; set; }

        [Required, Display (Name ="Título")]
        public string Titulo { get; set; }

        [Required]
        public string Tipo { get; set; }

        [Required, Display(Name = "Descrição")]
        public string Descricao { get; set; }

    }
}