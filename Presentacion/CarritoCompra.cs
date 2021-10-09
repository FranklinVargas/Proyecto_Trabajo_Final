using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using Negocio;

namespace Presentacion
{
    public partial class CarritoCompra : Form
    {
        nCarritoCompra nc = new nCarritoCompra();
       
        public CarritoCompra()
        {
            InitializeComponent();
            Insertar();
            mostrar();
        }

        string codigo, nombre, color, tipo, tamanio;
        string precio;

        public void RecibirDatos(string Codigo, string Nombre,string Color,string Tipo, string Tamanio, string Precio )
        {
            codigo = Codigo;
            nombre = Nombre;
            color = Color;
            tipo = Tipo;
            tamanio = Tamanio;
            precio = Precio;
        }

        private void Insertar()
        {
            MessageBox.Show(nc.AgregarA_Lista(Convert.ToInt32(codigo), nombre, color, tipo, tamanio, precio));
        }

        private void mostrar()
        {
            List<eProductos> lspproductos = nc.Listar();
            foreach (eProductos productos in lspproductos)
            {
                dataGridView1.DataSource = lspproductos;
            }

        }


    }
}
