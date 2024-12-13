using System.Data.SqlClient;

namespace Proyecto_Agricola.Clases
{
    public class Herramientas
    {
        ConexionSQL x = new ConexionSQL();
        SqlConnection con = new SqlConnection();

        public Herramientas()
        {
            con.ConnectionString = x.Conexion;
        }

        public int consecutivo(string campo, string tabla)
        {
            int id = 0;
            string consulta = $"\r\nSELECT isnull(MAX({campo})+1,1) AS MAXID FROM {tabla}";
            con.Open();
            SqlCommand cmd = new SqlCommand(consulta, con);
            SqlDataReader lector = cmd.ExecuteReader();
            if (lector.Read())
            {
                id = int.Parse(lector["MAXID"].ToString());
            }
            con.Close();
            return id;
        }
    }
}
