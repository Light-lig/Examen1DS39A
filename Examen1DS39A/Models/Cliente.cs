using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Examen1DS39A.Models
{
    public class Cliente
    {
        public Cliente()
        {

        }
        public Cliente(int cod_cliente, string nombre, string apellidos, string dui, string direccion, string nit)
        {
            this.cod_cliente = cod_cliente;
            this.nombres = nombre;
            this.apellidos = apellidos;
            this.dui = dui;
            this.direccion = direccion;
            this.nit = nit;
        }
        [key]
        public int cod_cliente { get; set; }
        [Required]
        [StringLength(30)]

        public string nombres { get; set; }
        [Required]
        [StringLength(30)]

        public string apellidos { get; set; }
        [Required]
        [StringLength(10)]
        [RegularExpression(@"^\d{1,8}\-\d{1,1}$",
         ErrorMessage = "Ejemplo de dui 00000000-0")]
        public string dui { get; set; }
        [Required]
        [StringLength(100)]
    
        public string direccion { get; set; }
        [Required]
        [StringLength(17)]
        [RegularExpression(@"^[0-9]{1,4}-[0-9]{1,6}-[0-9]{1,3}-[0-9]{1,1}$",
         ErrorMessage = "Ejemplo de nit 0000-000000-000-0")]
        public string nit { get; set; }
    }
}