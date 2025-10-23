using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Curso
    {
        private int _anioCalendario;
        private int _cupo;
        private int _materiaId;
        private int _comisionId;

        public int Id { get; set; }

        public int AnioCalendario
        {
            get => _anioCalendario;
            set
            {
                if (value < 1900 || value > 2100)
                    throw new ArgumentException("El año calendario debe estar entre 1900 y 2100.");
                _anioCalendario = value;
            }
        }

        public int Cupo
        {
            get => _cupo;
            set
            {
                if (value < 1)
                    throw new ArgumentException("El cupo debe ser al menos 1.");
                if (value > 300)
                    throw new ArgumentException("El cupo no puede superar los 300 estudiantes.");
                _cupo = value;
            }
        }

        public int MateriaId
        {
            get => _materiaId;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("El ID de materia debe ser un número positivo.");
                _materiaId = value;
            }
        }

        public int ComisionId
        {
            get => _comisionId;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("El ID de comisión debe ser un número positivo.");
                _comisionId = value;
            }
        }

        public Materia Materia { get; set; } = null!;
        public Comision Comision { get; set; } = null!;

        public Curso()
        {
        }

        public Curso(int id, int anioCalendario, int cupo, int materiaId, int comisionId)
        {
            Id = id;
            AnioCalendario = anioCalendario;
            Cupo = cupo;
            MateriaId = materiaId;
            ComisionId = comisionId;
        }
    }
}