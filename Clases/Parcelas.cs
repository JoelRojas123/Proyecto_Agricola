using System.Data.SqlClient;

namespace Proyecto_Agricola.Clases
{
    public class Parcelas
    {
        //Conexion a la base de datos

        ConexionSQL x = new ConexionSQL();
        SqlConnection con = new SqlConnection();

        //Declaracion de Campos
        public int ID;
        public string SECTOR;
        public string UBICACION;
        public string TAMAÑO;
        public string TIPOSUELO;
        public string ESTADO;

        public Parcelas()
        {
            con.ConnectionString = x.Conexion;
        }

        public string guardar()
        {
            string msj = "";
            try
            {
                string consulta = $"INSERT INTO PARCELAS(ID,SECTOR,UBICACION,TAMAÑO,TIPOSUELO,ESTADO) VALUES({ID}, '{SECTOR}', '{UBICACION}', '{TAMAÑO}','{TIPOSUELO}', '{ESTADO}')";
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
            string consulta = $"UPDATE PARCELAS SET SECTOR = '{SECTOR}', '{UBICACION}', '{TAMAÑO}', '{TIPOSUELO}', {ESTADO} WHERE ID = {ID}";
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
