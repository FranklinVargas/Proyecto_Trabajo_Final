using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;

namespace Negocio
{
    public class nAdministrador
    {
        dAdministrador admindao;
        public nAdministrador()
        {
            admindao = new dAdministrador();
        }
        public string RegistrarProduct(string nombre, string color, string tipo, string tamanio, string precio)
        {
            eProductos productos = new eProductos() {
                Nombre = nombre,
                Color = color,
                Tipo = tipo,
                Tamanio = tamanio,
                Precio = precio
            };
            return admindao.InsertarAdmin(productos);

        }

        public string ModificarProducto(int codigo, string nombre, string color, string tipo, string tamanio, string precio)
        {
            eProductos productos = new eProductos()
            {
                Codigo = codigo,
                Nombre = nombre,
                Color = color,
                Tipo = tipo,
                Tamanio = tamanio,
                Precio = precio
            };
            return admindao.ModificarAmdmin(productos);
        }

        public string EliminarProducto(int id)
        {
            return admindao.Eliminar(id);
        }

        public List<eProductos> ListarProductos()
        {
            return admindao.ListarTodo();
        }


    }
}
