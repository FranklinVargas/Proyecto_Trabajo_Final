using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace Presentacion_LOGIN
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
                    string cadenaconexion = "Data Source=DESKTOP-0GL1SDK\\SQLEXPRESS;Initial Catalog = TrabajoFinal; Integrated Security = True";
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
                        }
                        else
                        {
                            MessageBox.Show("Datos incorrectos");
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
           
        }

        private void btnEntrar_Click(object sender, EventArgs e)
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
                SqlCommand cmd = new SqlCommand(insertar, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Inserto nuevo usuario");

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                db.DesconectaDB();
            }

        }
    }
}
