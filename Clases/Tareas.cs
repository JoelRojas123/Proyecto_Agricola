using System.Data.SqlClient;

namespace Proyecto_Agricola.Clases
{
    public class Tareas
    {
        //CONEXION A SQL SERVER
        ConexionSQL x = new ConexionSQL();
        SqlConnection con = new SqlConnection();

        //DECLARACION DE CAMPOS
        public int ID;
        public int ID_PERSONAL;
        public int ID_PARCELAS;
        public string DESCRIPCION;
        public string ESTADO;

        public Tareas()
        {
            con.ConnectionString = x.Conexion;
        }

        public string guardar()
        {
            string msj = "";
            try
            {
                string Consulta = $"INSERT INTO TAREAS(ID,ID_PERSONAL,ID_PARCELAS,DESCRIPCION,ESTADO) VALUES ({ID},{ID_PERSONAL},{ID_PARCELAS}, '{DESCRIPCION}','{ESTADO}')";
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
            string consulta = $"UPDATE TAREAS SET DESCRIPCION = '{DESCRIPCION}'where ID = {ID}";
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
            string consulta = $"DELETE FROM TAREAS WHERE ID = {ID}";
            con.Open();
            SqlCommand cmd = new SqlCommand(consulta, con);
            cmd.ExecuteNonQuery();
            msj = "Se elimino el registro";
            con.Close();
            return msj;

        }
    }
}
