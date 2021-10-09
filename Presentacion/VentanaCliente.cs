using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Presentacion
{
    public partial class VentanaCliente : Form
    {
        public VentanaCliente()
        {
            InitializeComponent();

            cmbTipo.Items.Add("Todos");
            cmbTipo.Items.Add("Sofá");
            cmbTipo.Items.Add("Ropero");
            cmbTipo.Items.Add("Comedor");
            cmbTipo.Items.Add("Panel para TV");
        }

           

        public class Database
        {
            private SqlConnection conn;

            public SqlConnection ConectaDB()
            {
                try
                {
                    string cadenaconexion = "Data Source=LAPTOP-VOOI83B2\\SQLEXPRESS;Initial Catalog = TrabajoFinal; Integrated Security = True";
                    conn = new SqlConnection(cadenaconexion);
                    conn.Open();
                    return conn;
                }
                catch (SqlException e)
                {
                    return null;
                }
            }
            public void DesconectaDB()
            {
                conn.Close();
            }
        }




        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            Database db = new Database();
            SqlConnection conexion = new SqlConnection();
            conexion = db.ConectaDB();
            if ( cmbTipo.SelectedItem.ToString()== "Todos")
            {
                string oracion = "Select * from Productos";
                SqlCommand cmd = new SqlCommand(oracion,conexion);
                SqlDataAdapter data = new SqlDataAdapter(cmd);
                DataTable tabla = new DataTable();
                data.Fill(tabla);
                dataGridView1.DataSource = tabla;
            }
            else 
            {
                string oracion = "Select * from Productos where Tipo = '"+cmbTipo.SelectedItem.ToString()+"'";
                SqlCommand cmd = new SqlCommand(oracion, conexion);
                SqlDataAdapter data = new SqlDataAdapter(cmd);
                DataTable tabla = new DataTable();
                data.Fill(tabla);
                dataGridView1.DataSource = tabla;
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cmbTipo.Text = "Todos";
        }

        string codigo;
        string nombre, color, tipo, tamanio, precio;

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            codigo = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            nombre = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            color = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            tipo = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            tamanio = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            precio = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            CarritoCompra cc = new CarritoCompra();
            this.Hide();
            cc.Show();

            cc.RecibirDatos(codigo, nombre, color, tipo, tamanio, precio);




        }

        
    }
}
