using Examen1DS39A.util;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Examen1DS39A.Models
{
    public class DaoUsuario
    {
        Constantes constantes = new Constantes();
        public Usuario login(string nombre, string clave)
        {
            string query = "select * from usuarios where nombre_usuario = @nombre and contra = @pass";
            using (SqlConnection cnn = new SqlConnection(constantes.CONEXIONSTRING))
            {
                using (SqlCommand comando = new SqlCommand(query, cnn))
                {
                    try
                    {
                        cnn.Open();
                        comando.Parameters.AddWithValue("@nombre", nombre);
                        comando.Parameters.AddWithValue("@pass", clave);
                        SqlDataReader lector = comando.ExecuteReader();
         
                        Usuario us = new Usuario();
                        while (lector.Read())
                        {
                           us  = new Usuario(int.Parse(lector[0].ToString()), lector[1].ToString(), lector[2].ToString(), lector[3].ToString());
                        }

                        cnn.Close();
                        return us;
                    }
                    catch (Exception)
                    {
                        cnn.Close();
              
                        return null;
                    }
                }
            }

        }
    }
}