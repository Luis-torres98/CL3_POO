using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using POOI_CL3_LUIS_TORRES.Entidades;
using System.Data;
using System.Data.SqlClient;
using POOI_CL3_LUIS_TORRES.util;

namespace POOI_CL3_LUIS_TORRES.ADO
{
    public class ADOTipoDocumento
    {
        public List<TipoDocumento> Listar()
        {
            List<TipoDocumento> lista = new List<TipoDocumento>();
            SqlConnection cn = new BDConexion().ObtenerConexion();

            try
            {
                SqlCommand cmd = new SqlCommand("SP_TIPODOCUMENTO_LISTAR", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(new TipoDocumento()
                    {
                        IdTipoDocumento = dr.GetInt32(0),
                        Nombre = dr.GetString(1)
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
    }
}
