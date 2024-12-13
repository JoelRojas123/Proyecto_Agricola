using System.Data.SqlClient;

namespace Proyecto_Agricola.Clases
{
    public class Mantenimiento
    {
        //CONEXION A BASE DE DATOS SQL
        ConexionSQL X = new ConexionSQL();
        SqlConnection con = new SqlConnection();

        //DECLARACION DE CAMPOS9
        public int ID;
        public int ID_MAQUINARIA;
        public int ID_P_MAQUINARIA;
        public string FECHA;
        public string DESCRIPCION;
        public string COSTO;


        public Mantenimiento()
        {
            con.ConnectionString = X.Conexion;
        }

        public string guardar()
        {
            string msj = "";
            //try
            {
                string Consulta = $"INSERT INTO MANTENIMIENTO_MAQUINARIA(ID,ID_MAQUINARIA,ID_P_MANTENIMIENTO,FECHA,DESCRIPCION,COSTO) VALUES({ID},{ID_MAQUINARIA}, {ID_P_MAQUINARIA},'{FECHA}','{DESCRIPCION}','{COSTO}')";
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
            string consulta = $"UPDATE MANTENIMIENTO_MAQUINARIA SET FECHA = '{FECHA}'where ID = {ID}";
            con.Open();
            SqlCommand cmd = new SqlCommand(consulta, con);
            cmd.ExecuteNonQuery();
            con.Close();
            msj = "Se Actualizaron los datos";

            return msj;
        }

        public string eliminar()
        {
            string msj = "";
            string consulta = $"DELETE FROM MANTENIMIENTO_MAQUINARIA WHERE ID = {ID}";
            con.Open();
            SqlCommand cmd = new SqlCommand(consulta, con);
            cmd.ExecuteNonQuery();
            msj = "Se elimino el registro";
            con.Close();
            return msj;

        }
    }
}
