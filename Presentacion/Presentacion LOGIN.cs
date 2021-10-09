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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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


        public void logins()
        {
            if (txtDniLogin.Text == "admin"  && txtContraLogin.Text == "123")
            {
                Presentacion_Admin pa = new Presentacion_Admin();
                MessageBox.Show("Bienvenido Administrador");
                this.Hide();
                pa.Show();
            }
            else
            {


                Database db = new Database();

                try
                {

                    SqlConnection conn = db.ConectaDB();
                    {

                        using (SqlCommand cmd = new SqlCommand("SELECT Dni, Contrasenia FROM Cliente WHERE Dni = '" + txtDniLogin.Text + "' AND Contrasenia = '" + txtContraLogin.Text + "'", conn))
                        {
                            SqlDataReader dr = cmd.ExecuteReader();

                            if (dr.Read())
                            {
                                MessageBox.Show("Login exitoso");

                                this.Hide();
                                VentanaCliente vc = new VentanaCliente();
                               
                                vc.Show();

                            }
                            else
                            {
                                MessageBox.Show("Datos incorrectos");
                                txtDniLogin.Text = "";
                                txtContraLogin.Text = "";
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Intente de nuevo");
                    txtContraLogin.Text = "";
                    txtDniLogin.Text = "";
                }

            }


        }
        

        private void btnEntrar_Click_1(object sender, EventArgs e)
        {
            logins();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            Database db = new Database();

            int dni;
            string contrasenia;
            dni = Convert.ToInt32(txtDNIregistrar.Text);
            contrasenia = txtContraseniaRegistrar.Text;

            try
            {     
                 SqlConnection conn = db.ConectaDB();
                 string insertar = string.Format("INSERT INTO Cliente (Dni, Contrasenia) VALUES ('{0}', '{1}')", dni, contrasenia);
                 SqlCommand cmdd = new SqlCommand(insertar, conn);
                 cmdd.ExecuteNonQuery();
                 MessageBox.Show("Inserto nuevo usuario");

                 this.Hide();
                 VentanaCliente vc = new VentanaCliente();
                 vc.Show();
                    
                

            }
            catch (Exception ex)
            {
                MessageBox.Show("Usuario ya registrado");
              
                txtDNIregistrar.Text = "";
                
                txtContraseniaRegistrar.Text = "";
            }
            finally
            {
                db.DesconectaDB();
            }
        }

        
    }
}

