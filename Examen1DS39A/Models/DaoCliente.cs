using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Examen1DS39A.util;

namespace Examen1DS39A.Models
{
    public class DaoCliente
    {
        Constantes constantes = new Constantes();
        public List<Cliente> getData(string filtro)
        {
            string query = @"select * from clientes where (" +
                     "(cod_cliente like '%' + @codcliente + '%') or (@codcliente is null) ) or " +
                     "((nombres like '%' + @nombres + '%') or (@nombres is null)) or " +
                     "((apellidos like '%' + @apellidos + '%') or (@apellidos is null)) or" +
                     "((dui like '%' + @dui + '%') or (@dui is null)) or " +
                     "((direccion like '%' + @direccion + '%') or (@direccion is null)) or" +
                     "((nit like '%' + @nit + '%') or (@nit is null));";
            using (SqlConnection cnn = new SqlConnection(constantes.CONEXIONSTRING))
            {
                using (SqlCommand comando = new SqlCommand(query, cnn))
                {
                    try
                    {
                        Object valorFinal = null;
                        if(filtro == null)
                        {
                            valorFinal = DBNull.Value;
                        }
                        else
                        {
                            valorFinal = filtro;
                        }
                        cnn.Open();
                         comando.Parameters.AddWithValue("@codcliente", valorFinal);
                        comando.Parameters.AddWithValue("@nombres", valorFinal);
                        comando.Parameters.AddWithValue("@apellidos", valorFinal);
                        comando.Parameters.AddWithValue("@dui", valorFinal);
                        comando.Parameters.AddWithValue("@direccion", valorFinal);
                        comando.Parameters.AddWithValue("@nit", valorFinal);
                        SqlDataReader lector = comando.ExecuteReader();
                        List<Cliente> lista = new List<Cliente>();
                        while (lector.Read())
                        {
                            lista.Add(new Cliente(int.Parse(lector[0].ToString()), 
                                                            lector[1].ToString(), 
                                                            lector[2].ToString(), 
                                                            lector[3].ToString(), 
                                                            lector[4].ToString(), 
                                                            lector[5].ToString()));
                        }
                        cnn.Close();
                        return lista;

                    }
                    catch (Exception)
                    {

                        throw;
                    }
                   
                }
            }
        }

        public bool insertar(Cliente cli)
        {
            string query = "insert into clientes values(@nombres,@apellidos,@dui,@direccion, @nit)";
            using (SqlConnection cnn = new SqlConnection(constantes.CONEXIONSTRING))
            {
                using (SqlCommand comando = new SqlCommand(query, cnn))
                {
                    try
                    {
                        cnn.Open();
                        comando.Parameters.AddWithValue("@nombres", cli.nombres);
                        comando.Parameters.AddWithValue("@apellidos", cli.apellidos);
                        comando.Parameters.AddWithValue("@dui", cli.dui);
                        comando.Parameters.AddWithValue("@direccion", cli.direccion);
                        comando.Parameters.AddWithValue("@nit", cli.nit);
                        int r = comando.ExecuteNonQuery();
                        if(r == 1)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    catch (Exception)
                    {

                        return false;
                    }
                }
            }
        }

        public bool modificar(Cliente cli)
        {
            string query = "update clientes set nombres = @nombres, apellidos = @apellidos, dui = @dui, direccion = @direccion, nit = @nit where cod_cliente = @id";
            using (SqlConnection cnn = new SqlConnection(constantes.CONEXIONSTRING))
            {
                using (SqlCommand comando = new SqlCommand(query, cnn))
                {
                    try
                    {
                        cnn.Open();
                        comando.Parameters.AddWithValue("@nombres", cli.nombres);
                        comando.Parameters.AddWithValue("@apellidos", cli.apellidos);
                        comando.Parameters.AddWithValue("@dui", cli.dui);
                        comando.Parameters.AddWithValue("@direccion", cli.direccion);
                        comando.Parameters.AddWithValue("@nit", cli.nit);
                        comando.Parameters.AddWithValue("@id", cli.cod_cliente);
                        int r = comando.ExecuteNonQuery();
                        if (r == 1)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    catch (Exception)
                    {

                        return false;
                    }
                }
            }
        }

        public bool eliminar(int id)
        {
            string query = "delete from clientes where cod_cliente = @id";
            using (SqlConnection cnn = new SqlConnection(constantes.CONEXIONSTRING))
            {
                using (SqlCommand comando = new SqlCommand(query, cnn))
                {
                    try
                    {
                        cnn.Open();
                        comando.Parameters.AddWithValue("@id", id);
                        int r = comando.ExecuteNonQuery();
                        if (r == 1)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    catch (Exception)
                    {

                        return false;
                    }
                }
            }
        }
    }
}