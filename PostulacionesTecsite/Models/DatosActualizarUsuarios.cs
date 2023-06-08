using System.ComponentModel.DataAnnotations;

namespace PostulacionesTecsite.Models
{
    public class DatosActualizarUsuarios
    {
        public string nombre { get; set; }
        public string apellido { get; set; }

        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}")]
        public DateTime? fecha { get; set; }
        public string correo { get; set; }
        public string clave { get; set; }


    }
}
