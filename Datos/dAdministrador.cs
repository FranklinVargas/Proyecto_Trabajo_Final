using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entidades;

namespace Datos
{
    public class dAdministrador
    {
        Database db = new Database();

        public string InsertarAdmin(eProductos o)
        {
            try
            {
                SqlConnection con = db.ConectaDB();
                string insertar = "InsertarProducto";

                SqlCommand cmd = new SqlCommand(insertar, con);
                cmd.Parameters.AddWithValue("@nombre",o.Nombre);
                cmd.Parameters.AddWithValue("@color",o.Color);
                cmd.Parameters.AddWithValue("@tipo", o.Tipo);
                cmd.Parameters.AddWithValue("@tamanio", o.Tamanio);
                cmd.Parameters.AddWithValue("@precio",o.Precio);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.ExecuteNonQuery();
                return "Inserto";
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                db.DesconectaDB();
            }
        }


        public string ModificarAmdmin(eProductos o)
        {
            try
            {
                SqlConnection con = db.ConectaDB();
                string update = string.Format("UPDATE Productos SET Nombre = '{0}', Color = '{1}', Tipo = '{2}', Tamanio = '{3}', Precio ='{4}' WHERE Codigo ='{5}' ", o.Nombre, o.Color, o.Tipo,o.Tamanio,o.Precio,o.Codigo);
                SqlCommand cmd = new SqlCommand(update, con);
                cmd.ExecuteNonQuery();
                return "Modifico";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                db.DesconectaDB();
            }
        }


        public string Eliminar(int id)
        {
            try
            {
                SqlConnection con = db.ConectaDB();
                string delete = string.Format("DELETE from Productos WHERE Codigo={0}", id);
                SqlCommand cmd = new SqlCommand(delete, con);
                cmd.ExecuteNonQuery();
                return "Elimino";
            }
            catch (Exception ex)
            {
                return "Introduzca un valor correcto";
            }
            finally
            {
                db.DesconectaDB();
            }
        }

        public List<eProductos> ListarTodo()
        {
            try
            {
                
                List<eProductos> lsProductos = new List<eProductos>();
                eProductos productos = null;
                SqlConnection con = db.ConectaDB();
                SqlCommand cmd = new SqlCommand("MostrarProductos", con);
                

               SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    productos = new eProductos();
                    productos.Codigo = (int)reader["Codigo"];
                    productos.Nombre = (string)reader["Nombre"];
                    productos.Color = (string)reader["Color"];
                    productos.Tipo = (string)reader["Tipo"];
                    productos.Tamanio = (string)reader["Tamanio"];
                    productos.Precio = (string)reader["Precio"];
                    lsProductos.Add(productos);
                    

                }
                reader.Close();
                return lsProductos;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                db.DesconectaDB();
            }
        }




    }
}
