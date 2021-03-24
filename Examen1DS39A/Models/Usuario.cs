using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Examen1DS39A.Models
{
    public class Usuario
    {
        public Usuario()
        {

        }
        public Usuario(int cod_user, string nombre_usuario, string contra, string nivel_usuario)
        {
            this.cod_user = cod_user;
            this.nombre_usuario = nombre_usuario;
            this.contra = contra;
            this.nivel_usuario = nivel_usuario;
        }
        [Key]
        public int cod_user { get; set; }
        [Required]
        [StringLength(30)]
        public string nombre_usuario { get; set; }
        [Required]
        [StringLength(20)]
        public string contra {get; set; }
        [StringLength(20)]

        public string nivel_usuario { get; set; }

    }
}