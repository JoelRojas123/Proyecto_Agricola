using System.Data.SqlClient;

namespace Proyecto_Agricola.Clases
{
    public class Produccion
    {
        //CONEXION A BASE DE DATOS SQL
        ConexionSQL x = new ConexionSQL();
        SqlConnection con = new SqlConnection();

        //DECLARACION DE CAMPOS 
        public int ID;
        public int ID_PARCELA;
        public int ID_CULTIVOS;
        public string FECHA_SIEMBRA;
        public string FECHA_COSECHA;
        public string CANTIDADPRO;
        public string ESTADO;

        public Produccion()
        {
            con.ConnectionString = x.Conexion;
        }

        public string guardar()
        {
            string msj = "";
            try
            {
                string Consulta = $"INSERT INTO PRODUCCION(ID,FECHA_SIEMBRE,FECHA_COSHECHA,CANTIDAD_PRODUCIDA,ESTADO,ID_PARCELAS,ID_CULTIVO) VALUES({ID},'{FECHA_SIEMBRA}','{FECHA_COSECHA}','{CANTIDADPRO}','{ESTADO}',{ID_PARCELA},{ID_CULTIVOS})";
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
            string consulta = $"UPDATE PRODUCCION SET FECHA_SIEMBRE = '{FECHA_SIEMBRA}' where ID = {ID}";
            con.Open();
            SqlCommand cmd = new SqlCommand(consulta, con);
            cmd.ExecuteNonQuery();
            con.Close();
            msj = "Se actualizaron los datos";

            return msj;
        }

        public string eliminar()
        {
            string msj = "";
            string consulta = $"DELETE FROM PRODUCCION WHERE ID = {ID}";
            con.Open();
            SqlCommand cmd = new SqlCommand(consulta, con);
            cmd.ExecuteNonQuery();
            msj = "Se elimino el registro";
            con.Close();
            return msj;

        }
    }
}
