using PostulacionesTecsite.Models;

namespace PostulacionesTecsite.Servicios
{
    public interface IServicio_API
    {
        Task<List<listaUsuarioRoles>> listaUsuarioRoles();

        

        Task<bool> guardarUsuario(Usuario usuario);

        Task<bool> editarUsuario(DatosActualizarUsuarios usuario, string dni);

        Task<bool> desactivarUsuario(string dni);

        Task<List<ListarSolicitudes>> listarSolicitudes();

        Task<List<ListarSolicitudes>> listarSolicitudesAceptadas();

        Task<List<ListarSolicitudes>> listarSolicitudesRechazadas();

        Task<bool> guardarSolicitud(Solicitudes solicitudes);

        Task<bool> aceptarSoli(int codSoli);

        Task<bool> rechazarSoli(int codSoli);


    }
}
