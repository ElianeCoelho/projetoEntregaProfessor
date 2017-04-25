using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Classificados.Models
{
    public class Anunciante
    {

        public int AnuncianteID { get; set; }
        
        [Required]    
        public string Nome { get; set; }

        [Required]
        public string Cpf { get; set; }

        [Required, Display(Name ="Endereço")]
        public string Endereco { get; set; }

        [Required, Display(Name ="Anúncio")]
        public int AnuncioID { get; set; }

        [Display(Name ="Anúncio")]
        public virtual Anuncio _Anuncio { get; set; }
    }

}