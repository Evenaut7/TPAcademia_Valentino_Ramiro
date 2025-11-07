using DTOs;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace API.Clients
{
    public class AlumnoInscripcionApiClient
    {
        private static HttpClient client = new HttpClient();

        static AlumnoInscripcionApiClient()
        {
            client.BaseAddress = new Uri("http://localhost:5124");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static async Task<AlumnoInscripcionDTO> GetAsync(int id)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("alumnosInscripciones/" + id);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<AlumnoInscripcionDTO>();
                }
                else
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al obtener inscripción con Id {id}. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al obtener inscripción con Id {id}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al obtener inscripción con Id {id}: {ex.Message}", ex);
            }
        }

        public static async Task<IEnumerable<AlumnoInscripcionDTO>> GetAllAsync()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("alumnosInscripciones");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<IEnumerable<AlumnoInscripcionDTO>>();
                }
                else
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al obtener lista de inscripciones. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al obtener lista de inscripciones: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al obtener lista de inscripciones: {ex.Message}", ex);
            }
        }

        public static async Task AddAsync(AlumnoInscripcionDTO inscripcion)
        {
            try
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("alumnosInscripciones", inscripcion);

                if (!response.IsSuccessStatusCode)
                {
                    // Intenta leer el error como JSON
                    var errorObj = await response.Content.ReadFromJsonAsync<ErrorResponse>();
                    if (errorObj != null && !string.IsNullOrWhiteSpace(errorObj.error))
                        throw new Exception(errorObj.error);

                    // Si no se puede leer como JSON, muestra el contenido crudo
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al crear inscripción. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al crear inscripción: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al crear inscripción: {ex.Message}", ex);
            }
        }

        private class ErrorResponse
        {
            public string error { get; set; }
        }

        public static async Task UpdateAsync(AlumnoInscripcionDTO inscripcion)
        {
            try
            {
                HttpResponseMessage response = await client.PutAsJsonAsync($"alumnosInscripciones/{inscripcion.Id}", inscripcion);

                if (!response.IsSuccessStatusCode)
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al actualizar inscripción con Id {inscripcion.Id}. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al actualizar inscripción con Id {inscripcion.Id}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al actualizar inscripción con Id {inscripcion.Id}: {ex.Message}", ex);
            }
        }

        public static async Task DeleteAsync(int id)
        {
            try
            {
                HttpResponseMessage response = await client.DeleteAsync("alumnosInscripciones/" + id);

                if (!response.IsSuccessStatusCode)
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al eliminar inscripción con Id {id}. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al eliminar inscripción con Id {id}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al eliminar inscripción con Id {id}: {ex.Message}", ex);
            }
        }
    }
}
