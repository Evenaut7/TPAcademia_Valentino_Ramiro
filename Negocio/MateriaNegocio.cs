using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Models;
namespace Negocio
{
    public class MateriaNegocio
    {
        static readonly string defaultURL = "https://localhost:7058/materias/";

        public async static Task<IEnumerable<Materia>> GetAll()
        {
            var response = await Conexion.Instancia.Cliente.GetStringAsync(defaultURL);
            var data = JsonConvert.DeserializeObject<List<Materia>>(response);
            return data;
        }

        public async static Task<Materia> GetOne(string Id)
        {
            var response = await Conexion.Instancia.Cliente.GetStringAsync(defaultURL + Id);
            var data = JsonConvert.DeserializeObject<Materia>(response);
            return data;
        }

        public async static Task<Boolean> Add(Materia materia)
        {
            var response = await Conexion.Instancia.Cliente.PostAsJsonAsync(defaultURL, materia);
            return response.IsSuccessStatusCode;
        }

        public async static Task<Boolean> Update(Materia materia)
        {
            var response = await Conexion.Instancia.Cliente.PutAsJsonAsync(defaultURL + materia.Id, materia);
            return response.IsSuccessStatusCode;
        }

        public async static Task<Boolean> Delete(Materia materia)
        {
            var response = await Conexion.Instancia.Cliente.DeleteAsync(defaultURL + materia.Id);
            return response.IsSuccessStatusCode;
        }
    }
}