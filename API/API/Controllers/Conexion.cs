using API.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace API.Controllers
{
    public class Conexion
    {
        public static SqlConnection Insertar(string cadena)
        {

            string connetionString = "Data Source=DESKTOP-UNVUFTH\\SA;Initial Catalog=MasterDevel;User ID=servicios; Password=123";

            SqlConnection conexion = new SqlConnection(connetionString);
            conexion.Open();
            try
            {
                SqlCommand sentencia = new SqlCommand(cadena, conexion);
                sentencia.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;

            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }


            return conexion;


        }

        public static IEnumerable<Auth> Consulta(string cadena)
        {
            List<Auth> lstResult = new List<Auth>();

            string connetionString = "Data Source=DESKTOP-UNVUFTH\\SA;Initial Catalog=MasterDevel;User ID=servicios; Password=123";

            SqlConnection conexion = new SqlConnection(connetionString);
            conexion.Open();
            try
            {
                SqlCommand sentencia = new SqlCommand(cadena, conexion);
                SqlDataReader reader = sentencia.ExecuteReader();
                while (reader.Read())
                {
                    lstResult.Add(new Auth { key = reader.GetString(0), shared_secret = reader.GetString(1) });
            
                }
                reader.Close();
                sentencia.Dispose();
                               
            }
            catch (Exception ex)
            {
                throw ex;

            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }


            return lstResult;


        }

        public static string ConsultaID(string cadena)
        {

            string result = null;
            string connetionString = "Data Source=DESKTOP-UNVUFTH\\SA;Initial Catalog=MasterDevel;User ID=servicios; Password=123";

            SqlConnection conexion = new SqlConnection(connetionString);
            conexion.Open();
            try
            {
               
                SqlCommand sentencia = new SqlCommand(cadena, conexion);
                SqlDataReader reader = sentencia.ExecuteReader();
                while (reader.Read())
                {
                    result =reader.GetString(1);
                }
                reader.Close();
                sentencia.Dispose();

            }
            catch (Exception ex)
            {
                throw ex;

            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }


            return result;


        }



    }
}