using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class mvcPedidoModel
    {
        public int IdPedido { get; set; }
        public Nullable<int> CodigoProducto { get; set; }
        public System.DateTime FechaPedido { get; set; }
        public int CantidadPedido { get; set; }
        public decimal PrecioUnidad { get; set; }
        public System.DateTime FechaEntrega { get; set; }
        public string PersonaEntrega { get; set; }
        public string Empresa { get; set; }
        public string PersonaRecibe { get; set; }
        public string NumeroFactura { get; set; }
    }
}