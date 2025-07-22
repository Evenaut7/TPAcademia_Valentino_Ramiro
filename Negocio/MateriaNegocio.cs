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
        public async static Task<IEnumerable<Materia>> GetAll()
        {
            var response = await Conexion.Instancia.Cliente.GetStringAsync("https://localhost:7058/materias");
            var data = JsonConvert.DeserializeObject<List<Materia>>(response);
            return data;
        }

        public async static Task<Boolean> Delete(Materia materia)
        {
            var response = await Conexion.Instancia.Cliente.DeleteAsync("https://localhost:7058/materias/" + materia.Id);
            return response.IsSuccessStatusCode;
        }
    }
}