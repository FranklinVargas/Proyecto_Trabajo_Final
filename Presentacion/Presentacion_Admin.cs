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
    public partial class Presentacion_Admin : Form
    {
        nAdministrador na = new nAdministrador();

        public Presentacion_Admin()
        {
            InitializeComponent();
            
            comboBox1.Items.Add("Sofá");
            comboBox1.Items.Add("Ropero");
            comboBox1.Items.Add("Comedor");
            comboBox1.Items.Add("Panel para TV");

            comboBox2.Items.Add("Sofá");
            comboBox2.Items.Add("Ropero");
            comboBox2.Items.Add("Comedor");
            comboBox2.Items.Add("Panel para TV");

        }

        private void btnInsertarAdmin_Click(object sender, EventArgs e)
        {
            MessageBox.Show(na.RegistrarProduct(txtNombreAdmin.Text, txtColorAdmin.Text,comboBox1.SelectedItem.ToString(), txtTamanioAdmin.Text, txtPrecioAdmin.Text));
            txtNombreAdmin.Text = "";
            txtColorAdmin.Text = "";
            comboBox1.Text = "Sofá";
            txtTamanioAdmin.Text = "";
            txtPrecioAdmin.Text = "";

            Mostrar();
            
        }

        
        private void Mostrar()
        {
            List<eProductos> lsProductos = na.ListarProductos();
            foreach (eProductos productos in lsProductos)
            {
                dataGridView1.DataSource = lsProductos;
            }
        }


        private void btnEliminarAdmin_Click(object sender, EventArgs e)
        {
            if (txtCodigoEliminar.Text == "")
            {
                MessageBox.Show("Introduzca un valor correcto");
            }

            if (txtCodigoEliminar.Text != "")
            {
                MessageBox.Show(na.EliminarProducto(Convert.ToInt32(txtCodigoEliminar.Text)));
                txtCodigoEliminar.Text = "";

                Mostrar();
            }
            
        }

        private void button1_Click(object sender, EventArgs e)//mostrar
        {
            Mostrar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            this.Hide();
            f1.Show();
        }

        private void button2_Click(object sender, EventArgs e)// modificar
        {
            if(txtPrecioModificar.Text == ""){
                txtPrecioModificar.Text = "0";
            }
            MessageBox.Show(na.ModificarProducto(Convert.ToInt32(txtCodigoModificar.Text), txtNombreModificar.Text, txtColorModificar.Text,comboBox2.SelectedItem.ToString(), txtTamanioModificar.Text, txtPrecioModificar.Text));
            txtCodigoModificar.Text = "";
            txtNombreModificar.Text = "";
            txtColorModificar.Text = "";
            comboBox2.Text = "Sofá";
            txtTamanioModificar.Text = "";
            txtPrecioModificar.Text = "";

            Mostrar();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodigoModificar.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtNombreModificar.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtColorModificar.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            comboBox2.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtTamanioModificar.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtPrecioModificar.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }

      
    }
}
