using System.Data.SqlClient;

namespace Proyecto_Agricola.Clases
{
    public class P_Mantenimiento
    {
        ConexionSQL x = new ConexionSQL();
        SqlConnection con = new SqlConnection();

        //DECLARACION DE CAMPOS

        public int ID;
        public string NOMBRE, APELLIDOS, CARGO;


        public P_Mantenimiento()
        {
            con.ConnectionString = x.Conexion;
        }

        public string guardar()
        {
            string msj = "";
            try
            {
                string Consulta = $"INSERT INTO P_MANTENIMIENTO(ID,NOMBRE,APELLIDOS,CARGO) VALUES ({ID}, '{NOMBRE}', '{APELLIDOS}', '{CARGO}')";
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
            string consulta = $"UPDATE P_MANTENIMIENTO SET NOMBRE = '{NOMBRE}' where ID = {ID}";
            con.Open();
            SqlCommand cmd = new SqlCommand(consulta, con);
            cmd.ExecuteNonQuery();
            con.Close();
            msj = "Se realizo la actualizacion de datos";

            return msj;
        }

        public string eliminar()
        {
            string msj = "";
            string consulta = $"DELETE FROM P_MANTENIMIENTO WHERE ID = {ID}";
            con.Open();
            SqlCommand cmd = new SqlCommand(consulta, con);
            cmd.ExecuteNonQuery();
            msj = "Se elimino el registro";
            con.Close();
            return msj;

        }
    }
}
