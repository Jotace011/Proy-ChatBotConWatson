using Newtonsoft.Json;
using PostulacionesTecsite.Models;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;

namespace PostulacionesTecsite.Servicios
{
    public class ServicioUsuario_API : IServicio_API
    {
        private static string _baseurl;

        public ServicioUsuario_API()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            _baseurl = builder.GetSection("ApiSettings:baseUrl").Value;

        }
        public async Task<List<listaUsuarioRoles>> listaUsuarioRoles()
        {
            var lista = new List<listaUsuarioRoles>();

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);

            var request = await   cliente.GetAsync("api/usuarios");

            if(request.IsSuccessStatusCode)
            {
               var res =  request.Content.ReadAsStringAsync().Result;
               lista = JsonConvert.DeserializeObject<List<listaUsuarioRoles>>(res);
                return lista.ToList();
               
            }

            return lista;
        }


        public async Task<bool> guardarUsuario( Usuario usuario   ) {
            bool respuesta = false;

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);

            var content = new StringContent( JsonConvert.SerializeObject(usuario),Encoding.UTF8,"application/json");
            var response = await cliente.PostAsync("/api/usuarios/guardar", content);
            
            if (response.IsSuccessStatusCode)
            {
                respuesta = true;   
            }

            return respuesta;
        }

        public async Task<bool> editarUsuario(DatosActualizarUsuarios usuario, string dni)
        {
            bool respuesta = false;

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);

            var content = new StringContent(JsonConvert.SerializeObject(usuario), Encoding.UTF8, "application/json");
            var response = await cliente.PutAsync("api/usuarios/editar/"+dni, content);
            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }

            return respuesta;
        }


        public async Task<bool> desactivarUsuario(string dni)
        {
            bool respuesta = false;

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);

            var response = await cliente.DeleteAsync("api/usuarios/eliminar"+dni);
            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }

            return respuesta;
        }

        public async Task<List<ListarSolicitudes>> listarSolicitudes()
        {
            var lista = new List<ListarSolicitudes>();

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);

            var request = await cliente.GetAsync("api/solicitudes/espera");

            if (request.IsSuccessStatusCode)
            {
                var res = request.Content.ReadAsStringAsync().Result;
                lista = JsonConvert.DeserializeObject<List<ListarSolicitudes>>(res);
                return lista.ToList();

            }

            return lista;
        }

        public async Task<List<ListarSolicitudes>> listarSolicitudesAceptadas()
        {
            var lista = new List<ListarSolicitudes>();

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);

            var request = await cliente.GetAsync("api/solicitudes/aceptadas");

            if (request.IsSuccessStatusCode)
            {
                var res = request.Content.ReadAsStringAsync().Result;
                lista = JsonConvert.DeserializeObject<List<ListarSolicitudes>>(res);
                return lista.ToList();

            }

            return lista;
        }

        public async Task<List<ListarSolicitudes>> listarSolicitudesRechazadas()
        {
            var lista = new List<ListarSolicitudes>();

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);

            var request = await cliente.GetAsync("api/solicitudes/rechazadas");

            if (request.IsSuccessStatusCode)
            {
                var res = request.Content.ReadAsStringAsync().Result;
                lista = JsonConvert.DeserializeObject<List<ListarSolicitudes>>(res);
                return lista.ToList();

            }

            return lista;
        }

        public async Task<bool> guardarSolicitud(Solicitudes solicitudes)
        {
            bool respuesta = false;

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);

            var content = new StringContent(JsonConvert.SerializeObject(solicitudes), Encoding.UTF8, "application/json");
            var response = await cliente.PostAsync("api/solicitudes/guardar", content);

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }

            return respuesta;
        }

        public async Task<bool> aceptarSoli(int codSoli)
        {


            bool respuesta = false;

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);



            var response = await cliente.DeleteAsync("api/solicitudes/aceptar/" + codSoli);
            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }

            return respuesta;
        }

        public async Task<bool> rechazarSoli(int codSoli)
        {


            bool respuesta = false;

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);



            var response = await cliente.DeleteAsync("api/solicitudes/rechazar/" + codSoli);
            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }

            return respuesta;
        }
    }
}
