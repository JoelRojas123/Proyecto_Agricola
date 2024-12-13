using System.Data.SqlClient;

namespace Proyecto_Agricola.Clases
{

    public class Personal
    {
        //CONEXION A SQL
        ConexionSQL x = new ConexionSQL();
        SqlConnection con = new SqlConnection();

        //DECLARACION DE CAMPOS
        public int ID;
        public string NOMBRE;
        public string APELLIDOS;
        public string CARGO;
        public string FECHA_CONTRATACION;
        public string TELEFONO;
        public string EMAIL;
        public string RFC;
        public string NSS;
        public string DOMICILIO;


        public Personal()
        {
            con.ConnectionString = x.Conexion;
        }

        public string guardar()
        {
            string msj = "";
            try
            {
                string Consulta = $"INSERT INTO PERSONAL (ID,NOMBRE,APELLIDOS,CARGO,FECHA_CONTRATACION,TELEFONO,EMAIL,RFC,NSS,DOMICILIO) VALUES ({ID}, '{NOMBRE}', '{APELLIDOS}', '{CARGO}', '{FECHA_CONTRATACION}','{TELEFONO}', '{EMAIL}', '{RFC}', '{NSS}', '{DOMICILIO}')";
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
            string consulta = $"UPDATE PERSONAL SET NOMBRE = '{NOMBRE}' where ID = {ID}";
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
            string consulta = $"DELETE FROM PERSONAL WHERE ID = {ID}";
            con.Open();
            SqlCommand cmd = new SqlCommand(consulta, con);
            cmd.ExecuteNonQuery();
            msj = "Se elimino el registro";
            con.Close();
            return msj;

        }
    }




}
