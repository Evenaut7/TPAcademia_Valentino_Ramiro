using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Data
{
    public class UsuarioRepository
    {
        private TPIContext CreateContext()
        {
            return new TPIContext();
        }

        public void Add(Usuario usuario)
        {
            using var context = CreateContext();
            context.Usuarios.Add(usuario);
            context.SaveChanges();
        }

        public bool Delete(int id)
        {
            using var context = CreateContext();
            var usuario = context.Usuarios.Find(id);
            if (usuario != null)
            {
                context.Usuarios.Remove(usuario);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public Usuario? Get(int id)
        {
            using var context = CreateContext();
            return context.Usuarios
                .FirstOrDefault(u => u.Id == id);
        }

        public IEnumerable<Usuario> GetAll()
        {
            using var context = CreateContext();
            return context.Usuarios.ToList();
        }

        public bool UsernameExists(string username, int? excludeId = null)
        {
            using var context = CreateContext();
            var query = context.Usuarios
                .Where(u => u.NombreUsuario.ToLower() == username.ToLower());

            if (excludeId.HasValue)
            {
                query = query.Where(u => u.Id != excludeId.Value);
            }

            return query.Any();
        }

        public bool EmailExists(string email, int? excludeId = null)
        {
            using var context = CreateContext();
            var query = context.Usuarios
                .Where(u => u.Email.ToLower() == email.ToLower());

            if (excludeId.HasValue)
            {
                query = query.Where(u => u.Id != excludeId.Value);
            }

            return query.Any();
        }

        public Usuario? GetByNombreUsuario(string nombreUsuario)
        {
            using var context = CreateContext();
            return context.Usuarios.FirstOrDefault(u => u.NombreUsuario == nombreUsuario && u.Habilitado);
        }

        public bool Update(Usuario usuario)
        {
            using var context = CreateContext();
            var existingUsuario = context.Usuarios.Find(usuario.Id);
            if (existingUsuario != null)
            {
                existingUsuario.NombreUsuario = usuario.NombreUsuario;
                existingUsuario.Email = usuario.Email;
                existingUsuario.Clave = usuario.Clave;
                existingUsuario.Salt = usuario.Salt;
                existingUsuario.Privilegio = usuario.Privilegio;
                existingUsuario.Habilitado = usuario.Habilitado;
                existingUsuario.PersonaId = usuario.PersonaId;


                context.SaveChanges();
                return true;
            }
            return false;
        }

        public Usuario? GetUserRole(int userId)
        {
            using var context = CreateContext();

            // Include the Persona navigation property
            return context.Usuarios
                .Include(u => u.Persona)
                .FirstOrDefault(u => u.Id == userId);
        }
    }
}
