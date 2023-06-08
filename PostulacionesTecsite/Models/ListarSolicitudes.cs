﻿namespace PostulacionesTecsite.Models
{
    public class ListarSolicitudes
    {
        public int cod_solicitud { get; set; }
        public string nom_soli { get; set; }
        public string dni_soli { get; set; }
        public string pais_soli { get; set; }
        public string correo_soli { get; set; }

        public string perfil { get; set; }

        public string area { get; set; }

        public string link { get; set; }

        public DateTime fecha_registrada { get; set; }

    }
}
