using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POOI_CL3_LUIS_TORRES.Entidades
{
    public partial class Conductor
    {
        public int ConductorId { get; set; }
        public string Dni { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Brevete { get; set; }
        public string Telefono { get; set; }
        public string Estado { get; set; }
        public int IdTipoDocumento { get; set; }

        
    }
}
