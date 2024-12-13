using System.Data.SqlClient;

namespace Proyecto_Agricola.Clases
{
    public class Ventas
    {
        //CONEXION A SQL SERVER
        ConexionSQL x = new ConexionSQL();
        SqlConnection con = new SqlConnection();

        //DECLARACION DE CAMPOS
        public int ID;
        public int ID_PRODUCTO;
        public string FECHA_VENTA;
        public string CANTIDAD;
        public string PRECIO_TOTAL;
        public string CLIENTE;


        public Ventas()
        {
            con.ConnectionString = x.Conexion;
        }

        public string guardar()
        {
            string msj = "";
            //try
            {
                string Consulta = $"INSERT INTO VENTAS(ID,ID_PRODUCTO,FECHA_VENTA,CANTIDAD,PRECIO_TOTAL,CLIENTE) VALUES ({ID},{ID_PRODUCTO},'{FECHA_VENTA}','{CANTIDAD}','{PRECIO_TOTAL}','{CLIENTE}')";
                con.Open();
                SqlCommand cmd = new SqlCommand(Consulta, con);
                cmd.ExecuteNonQuery();
                con.Close();
                msj = "Proceso Exitoso";
            }
            //catch
            {

            }
            return msj;
        }
        public string actualizar()
        {
            string msj = "";
            string consulta = $"UPDATE VENTAS SET FECHA_VENTA = '{FECHA_VENTA}'where ID = {ID}";
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
            string consulta = $"DELETE FROM VENTAS WHERE ID = {ID}";
            con.Open();
            SqlCommand cmd = new SqlCommand(consulta, con);
            cmd.ExecuteNonQuery();
            msj = "Se elimino el registro";
            con.Close();
            return msj;

        }


    }
}
