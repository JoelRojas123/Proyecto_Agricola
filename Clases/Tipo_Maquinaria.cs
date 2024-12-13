using System.Data.SqlClient;

namespace Proyecto_Agricola.Clases
{
    public class Tipo_Maquinaria
    {
        ConexionSQL x = new ConexionSQL();
        SqlConnection con = new SqlConnection();

        //DECLARACION DE CAMPOS
        public int ID;
        public string NOMBRE, MODELO;


        public Tipo_Maquinaria()
        {
            con.ConnectionString = x.Conexion;
        }

        public string guardar()
        {
            string msj = "";
            try
            {
                string Consulta = $"INSERT INTO TIPO_MAQUINARIA(ID,NOMBRE,MODELO) VALUES ({ID}, '{NOMBRE}', '{MODELO}')";
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
            string consulta = $"UPDATE TIPO_MAQUINARIA SET NOMBRE = '{NOMBRE}' where ID = {ID}";
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
            string consulta = $"DELETE FROM TIPO_MAQUINARIA WHERE ID = {ID}";
            con.Open();
            SqlCommand cmd = new SqlCommand(consulta, con);
            cmd.ExecuteNonQuery();
            msj = "Se elimino el registro";
            con.Close();
            return msj;

        }
    }
}
