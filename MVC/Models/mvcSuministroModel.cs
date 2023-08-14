using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class mvcSuministroModel
    {
        [Required(ErrorMessage = "El campo Código es requerido.")]
        public int Codigo { get; set; }
        [Required(ErrorMessage = "El campo Nombre es requerido.")]
        public string Nombre { get; set; }

        [Display(Name = "Unidad de Medida")]
        [Required(ErrorMessage = "El campo Unidad de Medida es requerido.")]
        public string UnidadMedida { get; set; }
        [Display(Name = "Cantidad Minima")]
        [Required(ErrorMessage = "El campo Cantidad Minima es requerido.")]
        public int CantidadMinima { get; set; }
        [Display(Name = "Cantidad Maxima")]
        [Required(ErrorMessage = "El campo Cantidad Maxima es requerido.")]
        public int CantidadMaxima { get; set; }
        [Display(Name = "Cantidad Actual")]
        [Required(ErrorMessage = "El campo Cantidad Actual es requerido.")]
        public int CantidadActual { get; set; }
    }
}