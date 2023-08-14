using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class mvcRetiroModel
    {
        public int NumeroSolicitud { get; set; }
        [Display(Name = "Codigo de Producto")]
        public Nullable<int> CodigoProducto { get; set; }
        [Display(Name = "Fecha de Entrega")]
        public System.DateTime FechaEntrega { get; set; }
        [Display(Name = "Cantidad de Retiro")]
        [Required(ErrorMessage = "El campo Cantidad de Retiro es requerido.")]
        public int CantidadRetiro { get; set; }
        [Display(Name = "Nombre Completo")]
        [Required(ErrorMessage = "El campo Nombre Completo es requerido.")]
        public string NombreCompleto { get; set; }
    }
}