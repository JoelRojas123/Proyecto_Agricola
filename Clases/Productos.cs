using System.Data.SqlClient;

namespace Proyecto_Agricola.Clases
{
    public class Productos
    {
        ConexionSQL x = new ConexionSQL();
        SqlConnection con = new SqlConnection();

        //DECLARACION DE CAMPOS
        public int ID;
        public int IDCULTIVOS;
        public string FECHA_COSECHA;
        public string CANTIDAD;
        public string PRECIO_UNI;
        public string ESTADO;
        public string PRECIO_TOTAL;

        public Productos()
        {
            con.ConnectionString = x.Conexion;
        }

        public string guardar()
        {
            string msj = "";
            try
            {
                string Consulta = $"INSERT INTO PRODUCTOS(ID,ID_CULTIVOS,FECHA_COSECHA,CANTIDAD,PRECIO,ESTADO,PRECIO_TOTAL) VALUES({ID}, {IDCULTIVOS},'{FECHA_COSECHA}', '{CANTIDAD}', '{PRECIO_UNI}', '{ESTADO}', '{PRECIO_TOTAL}')";
                con.Open();
                SqlCommand cmd = new SqlCommand(Consulta, con);
                cmd.ExecuteNonQuery();
                con.Close();
                msj = "Proceso Exitoso";
            }
            catch
            {

            }
            return msj;
        }
        public string actualizar()
        {
            string msj = "";
            string consulta = $"UPDATE PRODUCTOS SET FECHA_COSECHA = '{FECHA_COSECHA}'   where ID = {ID}";
            con.Open();
            SqlCommand cmd = new SqlCommand(consulta, con);
            cmd.ExecuteNonQuery();
            con.Close();
            msj = "Se ejecuto el metodo";

            return msj;
        }

        public string eliminar()
        {
            string msj = "";
            string consulta = $"DELETE FROM PRODUCTOS WHERE ID = {ID}";
            con.Open();
            SqlCommand cmd = new SqlCommand(consulta, con);
            cmd.ExecuteNonQuery();
            msj = "Se elimino el registro";
            con.Close();
            return msj;

        }
    }
}
