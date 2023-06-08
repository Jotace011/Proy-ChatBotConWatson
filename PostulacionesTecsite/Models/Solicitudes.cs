using System.ComponentModel.DataAnnotations;

namespace PostulacionesTecsite.Models
{

    public class Solicitudes
    {

        public int cod_solicitud { get; set; }
        public string nom_soli { get; set; }

        public string ape_soli { get; set; }
        public string dni_soli { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime fec_nac_soli { get; set; }
        public string pais_soli { get; set; }
        public string ciudad_soli { get; set; }
        public string correo_soli { get; set; }

        public string cel_soli { get; set; }
        public string nom_insti { get; set; }
        public int cod_carrera { get; set; }

        public int cod_ciclo { get; set; }
        public int cod_area { get; set; }
        public string cv_link { get; set; }


    }
}
