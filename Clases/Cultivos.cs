using System.Data.SqlClient;

namespace Proyecto_Agricola.Clases
{
    public class Cultivos
    {
        //Conexion a la base de datos

        ConexionSQL x = new ConexionSQL();
        SqlConnection con = new SqlConnection();

        //Declaracion de Campos
        public int ID;
        public string NOMBRE;
        public string TEMPORADA;
        public string CICLO;

        public Cultivos()
        {
            con.ConnectionString = x.Conexion;
        }

        public string guardar()
        {
            string msj = "";
            try
            {
                string consulta = $"INSERT INTO CULTIVOS(ID,NOMBRE,TEMPORADA,CICLO) VALUES({ID}, '{NOMBRE}', '{TEMPORADA}', '{CICLO}')";
                con.Open();
                SqlCommand cmd = new SqlCommand(consulta, con);
                cmd.ExecuteNonQuery();
                con.Close();
                msj = "PROCESO EXITOSO";
            }
            catch
            {

            }
            return msj;
        }

        public string actualizar()
        {
            string msj = "";
            string consulta = $"UPDATE CULTIVOS SET NOMBRE = '{NOMBRE}', '{TEMPORADA}', '{CICLO}' WHERE ID = {ID}";
            con.Open();
            SqlCommand cmd = new SqlCommand(consulta, con);
            cmd.ExecuteNonQuery();
            con.Close();
            msj = "Se actualizo el registro";

            return msj;
        }

        public string eliminar()
        {
            string msj = "";
            string consulta = $"DELETE CULTIVOS WHERE ID = {ID}";
            con.Open();
            SqlCommand cmd = new SqlCommand(consulta, con);
            cmd.ExecuteNonQuery();
            msj = "Se elimino el registro";
            con.Close();


            return msj;
        }
    }
}
