using ProtoDevDemo.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtoDevDemo.Repositories
{
    public class ProtoBDRepo
    {
        public string _dbPath;
        private SQLiteConnection conn;

        private void Init()
        {
            if (conn != null)
                return;

            conn = new SQLiteConnection(_dbPath);
            conn.CreateTable<CarritoCompras>();
            //conn.CreateTable<Producto>();  //Falta generar un objeto
        }

        // Constructor
        public ProtoBDRepo(string dbPath)
        {
            _dbPath = dbPath;
            Init(); 
        }

        // Método Devuelve listado de productos del carrito de compras
        public List<CarritoCompras> DevuelveListadoCarritoCompras()
        {
            //conn.Insert(new Producto());
          
            return conn.Table<CarritoCompras>().ToList();
        }

        // Método Guardar listado de productos en el carrito de compras
        public void GuardarProductoCarritoCompras(CarritoCompras producto)
        {
            conn.Insert(producto);
        }

        // Método Actualizar listado de productos en el carrito de compras
        public void ActualizarProductoCarritoCompras(CarritoCompras producto)
        {
            conn.Update(producto);
        }

        // Método Eliminar listado de productos en el carrito de compras
        public void EliminarProductoCarritoCompras(CarritoCompras producto)
        {
            conn.Delete(producto);
        }
    }
}