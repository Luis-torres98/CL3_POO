using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data;
using POOI_CL3_LUIS_TORRES.util;
using POOI_CL3_LUIS_TORRES.Entidades;

namespace POOI_CL3_LUIS_TORRES.ADO
{
    class ADOConductor
    {
        //Declarar la conexion
        SqlConnection cn = null;

        //Listar los cargos con DataSet
        public DataTable ListarConductorDS()
        {
            DataTable dt = new DataTable();
            //Obtener la conexion
            cn = new BDConexion().ObtenerConexion();

            //Declarar el DataAdapter
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM DBO.CONDUCTOR", cn);
            da.SelectCommand.CommandType = CommandType.Text;

            da.Fill(dt);

            return dt;
        }


        public List<Conductor> Listar()
        {
            List<Conductor> lista = new List<Conductor>();
            SqlConnection cn = new BDConexion().ObtenerConexion();

            try
            {
                SqlCommand cmd = new SqlCommand("SP_CONDUCTOR_LISTAR", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(new Conductor()
                    {
                        ConductorId= dr.GetInt32(0),
                        Dni = dr.GetString(1),
                        Nombre = dr.GetString(2),
                        ApellidoPaterno = dr.GetString(3),
                        ApellidoMaterno = dr.GetString(4),
                        Brevete = dr.GetString(5),
                        Telefono = dr.GetString(6),
                        Estado = dr.GetString(7),
                        IdTipoDocumento = dr.GetInt32(8),
                        NombreTipoDocumento = dr.GetString(9)

                    });

                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                cn.Close();
            }

            return lista;
        }

        public int Insertar(Conductor obj)
        {
            int resultado = -1;
            SqlConnection cn = new BDConexion().ObtenerConexion();
            try
            {
                SqlCommand cmd = new SqlCommand("SP_CONDUCTOR_INSERTAR", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DNI", obj.Dni);
                cmd.Parameters.AddWithValue("@NOMBRE", obj.Nombre);
                cmd.Parameters.AddWithValue("@APE_PAT", obj.ApellidoPaterno);
                cmd.Parameters.AddWithValue("@APE_MAT", obj.ApellidoMaterno);
                cmd.Parameters.AddWithValue("@BREVETE", obj.Brevete);
                cmd.Parameters.AddWithValue("@TLF", obj.Telefono);
                cmd.Parameters.AddWithValue("@EDO", obj.Estado);
                cmd.Parameters.AddWithValue("@ID_TD", obj.IdTipoDocumento);
                cn.Open();
                resultado = cmd.ExecuteNonQuery();
               
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                cn.Close();
            }

            return resultado;
        }


        public int Actualizar(Conductor obj)
        {
            int resultado = -1;
            SqlConnection cn = new BDConexion().ObtenerConexion();
            try
            {
                SqlCommand cmd = new SqlCommand("SP_ACTUALIZAR_CONDUCTOR", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DNI", obj.Dni);
                cmd.Parameters.AddWithValue("@NOMBRE", obj.Nombre);
                cmd.Parameters.AddWithValue("@APE_PAT", obj.ApellidoPaterno);
                cmd.Parameters.AddWithValue("@APE_MAT", obj.ApellidoMaterno);
                cmd.Parameters.AddWithValue("@BREVETE", obj.Brevete);
                cmd.Parameters.AddWithValue("@TLF", obj.Telefono);
                cmd.Parameters.AddWithValue("@EDO", obj.Estado);
                cmd.Parameters.AddWithValue("@ID_TD", obj.IdTipoDocumento);
                cmd.Parameters.AddWithValue("@ID_CONDUCTOR", obj.ConductorId);
                cn.Open();
                resultado = cmd.ExecuteNonQuery();

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                cn.Close();
            }

            return resultado;
        }


        public DataTable BuscarClientesXTD(int TipoDocumento)
        {
            DataTable dt = new DataTable();
            cn = new BDConexion().ObtenerConexion();

            SqlDataAdapter da = new SqlDataAdapter("SP_CONDUCTOR_X_TIPODOCUMENTO", cn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@IdTD", TipoDocumento);
            da.Fill(dt);

            return dt;
        }
    }
}
