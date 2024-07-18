using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtoDevDemo.Models
{
    public class CarritoCompras
    {
        [PrimaryKey]
        public int id { get; set; }
        public int cantidad { get; set; }
        public double Total { get; set; }
        public double PrecioCarrito { get; set; }
        public String NombreProductoCarrito { get; set; }
        public string ImagenCarrito { get; set; }


    }
}