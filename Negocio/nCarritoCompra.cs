using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;

namespace Negocio
{
    public class nCarritoCompra
    {
        dCarritoCompra carrodao;

        public nCarritoCompra()
        {
            carrodao = new dCarritoCompra();
        }

        public string AgregarA_Lista(int codigo,string nombre, string color, string tipo,string tamanio, string precio)
        {
            eProductos producto = new eProductos()
            {
                Codigo = codigo,
                Nombre = nombre,
                Color = color,
                Tipo = tipo,
                Tamanio = tamanio,
                Precio = precio
            };
            return carrodao.Insertar(producto);

        }

        public string EliminarUno(int id)
        {
            return carrodao.EliminarUno(id);
        }

        public string Vaciar()
        {
            return carrodao.Vaciar();
        }

        public List<eProductos> Listar()
        {
            return carrodao.Listar();
        }
    }
}
