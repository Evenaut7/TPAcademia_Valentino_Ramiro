using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Models;

namespace Negocio
{
    public class PlanNegocio
    {
        static readonly string defaultURL = "https://localhost:7055/api/Plan/";

        public async static Task<IEnumerable<Plan>> GetAll()
        {
            var response = await Conexion.Instancia.Cliente.GetStringAsync(defaultURL);
            var data = JsonConvert.DeserializeObject<List<Plan>>(response);
            return data;
        }

        public async static Task<Plan> GetOne(string Id)
        {
            var response = await Conexion.Instancia.Cliente.GetStringAsync(defaultURL + Id);
            var data = JsonConvert.DeserializeObject<Plan>(response);
            return data;
        }

        public async static Task<bool> Add(Plan plan)
        {
            var response = await Conexion.Instancia.Cliente.PostAsJsonAsync(defaultURL, plan);
            return response.IsSuccessStatusCode;
        }

        public async static Task<bool> Update(Plan plan)
        {
            var response = await Conexion.Instancia.Cliente.PutAsJsonAsync(defaultURL + plan.Id, plan);
            return response.IsSuccessStatusCode;
        }

        public async static Task<bool> Delete(Plan plan)
        {
            var response = await Conexion.Instancia.Cliente.DeleteAsync(defaultURL + plan.Id);
            return response.IsSuccessStatusCode;
        }
    }
}

