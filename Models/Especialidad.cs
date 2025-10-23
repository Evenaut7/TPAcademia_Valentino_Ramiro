using Domain.Model;
using System.Net;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Especialidad
    {
        private string _descripcion = string.Empty;

        public int Id { get; set; }

        public string Descripcion
        {
            get => _descripcion;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("La descripción no puede estar vacía.");
                if (value.Length > 100)
                    throw new ArgumentException("La descripción no puede superar los 100 caracteres.");
                _descripcion = value;
            }
        }
    }
}

