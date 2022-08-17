using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Usuario
    {

        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public ML.EstadoCivil EstadoCivil { get; set; }
        public ML.Genero  Genero { get; set; }
        public string FechaNacimiento { get; set; }
        public ML.Entidad Entidad { get; set; }
        public string Curp { get; set; }    
        public string RFC { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }

        public byte[] Imagen { get; set; }
        public List<Object> Usuarios { get; set; }
    }
}
