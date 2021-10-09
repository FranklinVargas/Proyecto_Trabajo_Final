using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entidades;

namespace Datos
{
    public class dCarritoCompra
    {
        Database db = new Database();

       public string Insertar(eProductos o)
        {
            try
            {
                SqlConnection conn = db.ConectaDB();
                string insertar = "AgregarProCarro";
                SqlCommand cmd = new SqlCommand(insertar, conn);
                cmd.Parameters.AddWithValue("@codigo_product", o.Codigo);
                cmd.Parameters.AddWithValue("@Nombre", o.Nombre);
                cmd.Parameters.AddWithValue("@color", o.Color);
                cmd.Parameters.AddWithValue("@tipo", o.Tipo);
                cmd.Parameters.AddWithValue("@tamanio", o.Tamanio);
                cmd.Parameters.AddWithValue("@precio", o.Precio);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.ExecuteNonQuery();
                return "Inserto al carrito de compras";
            }
            catch(Exception ex)
            {
                return ex.Message.ToString();
            }
            finally
            {
                db.DesconectaDB();
            }
        }    
        

        public string EliminarUno(int id)
        {
            try
            {
                SqlConnection conn = db.ConectaDB();

                string eliminar = "EliminarProCarro";
                SqlCommand cmd = new SqlCommand(eliminar, conn);
                cmd.Parameters.AddWithValue("@codigo", id);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.ExecuteNonQuery();
                return "Se elimino de la base de datos";
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

        public string Vaciar()
        {
            try
            {
                SqlConnection conn = db.ConectaDB();
                string vaciar = string.Format("DELETE from CarritoCompra");
                SqlCommand cmd = new SqlCommand(vaciar, conn);
                cmd.ExecuteNonQuery();
                return "Gracias por su visita";
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


        public List<eProductos> Listar()
        {
            try
            {
                List<eProductos> lsproductos = new List<eProductos>();
                eProductos producto = null;
                SqlConnection con = db.ConectaDB();
                SqlCommand cmd = new SqlCommand("MostrarProCarro", con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    producto = new eProductos();
                    producto.Codigo = (int)reader["Codigo_product"];
                    producto.Nombre = (string)reader["Nombre"];
                    producto.Color = (string)reader["Color"];
                    producto.Tipo = (string)reader["Tipo"];
                    producto.Tamanio = (string)reader["Tamanio"];
                    producto.Precio = (string)reader["Precio"];
                    lsproductos.Add(producto);
                }
                reader.Close();
                return lsproductos;
            }
            catch(Exception ex)
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
