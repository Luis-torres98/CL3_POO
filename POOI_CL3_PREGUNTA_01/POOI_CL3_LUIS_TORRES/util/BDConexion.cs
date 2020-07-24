using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Para Leer el archivo de configuracion 
using System.Configuration;
//Proveedor de datos 
using System.Data.SqlClient;
using System.Runtime.Remoting.Messaging;

namespace POOI_CL3_LUIS_TORRES.util
{
    public class BDConexion
    {

        SqlConnection cn;

        public SqlConnection ObtenerConexion()
        {
            if (cn == null)
                cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CNX"].ConnectionString);
            return cn;
        }
    }
}
