using System.Data.SqlClient;

namespace Proyecto_Agricola.Clases
{
    public class Maquinaria
    {
        ConexionSQL x = new ConexionSQL();
        SqlConnection con = new SqlConnection();

        //Declaracion de Campos
        public int ID;
        public string TIPO;
        public string MARCA;
        public string MODELO;
        public string FECHAADD;
        public string HORASTRA;
        public string ESTADO;

        public Maquinaria()
        {
            con.ConnectionString = x.Conexion;
        }

        public string guardar()
        {
            string msj = "";
            //try
            {
                string consulta = $"INSERT INTO MAQUINARIA(ID,TIPO,MARCA,MODELO,FECHA_ADD,HORAS_TRABAJADAS,ESTADO) VALUES({ID}, '{TIPO}', '{MARCA}', '{MODELO}', '{FECHAADD}', {HORASTRA}, '{ESTADO}')";
                con.Open();
                SqlCommand cmd = new SqlCommand(consulta, con);
                cmd.ExecuteNonQuery();
                con.Close();
                msj = "PROCESO EXITOSO";
            }
            //catch
            {

            }
            return msj;
        }

        public string actualizar()
        {
            string msj = "";
            string consulta = $"UPDATE MAQUINARIA SET NOMBRE = '{TIPO}', '{MARCA}', '{MODELO}','{FECHAADD}', {HORASTRA}, '{ESTADO}' WHERE ID = {ID}";
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
            string consulta = $"DELETE MAQUINARIA WHERE ID = {ID}";
            con.Open();
            SqlCommand cmd = new SqlCommand(consulta, con);
            cmd.ExecuteNonQuery();
            msj = "Se elimino el registro";
            con.Close();


            return msj;
        }
    }
}
