using Domain.Model;
using Data;
using DTOs;

namespace Application.Services
{
    public class UsuarioService
    {
        public UsuarioDTO? Get(int id)
        {
            var usuarioRepository = new UsuarioRepository();
            Usuario? usuario = usuarioRepository.Get(id);

            if (usuario == null)
                return null;

            return new UsuarioDTO
            {
                Id = usuario.Id,
                NombreUsuario = usuario.NombreUsuario,
                Email = usuario.Email,
                Habilitado = usuario.Habilitado,
                Privilegio = usuario.Privilegio,
                Clave = usuario.Clave,
                PersonaId = usuario.PersonaId,
            };
        }

        public IEnumerable<UsuarioDTO> GetAll()
        {
            var usuarioRepository = new UsuarioRepository();
            var usuarios = usuarioRepository.GetAll();

            return usuarios.Select(u => new UsuarioDTO
            {
                Id = u.Id,
                NombreUsuario = u.NombreUsuario,
                Email = u.Email,
                Habilitado = u.Habilitado,
                Privilegio = u.Privilegio,
                Clave = u.Clave,
                PersonaId = u.PersonaId
            }).ToList();
        }

        public UsuarioDTO Add(UsuarioDTO dto)
        {
            var usuarioRepository = new UsuarioRepository();

            if (usuarioRepository.UsernameExists(dto.NombreUsuario))
                throw new ArgumentException($"Ya existe un usuario con el nombre de usuario '{dto.NombreUsuario}'.");

            if (usuarioRepository.EmailExists(dto.Email))
                throw new ArgumentException($"Ya existe un usuario con el email '{dto.Email}'.");

            var usuario = new Usuario(
                id: dto.Id,
                nombreUsuario: dto.NombreUsuario,
                email: dto.Email,
                clave: dto.Clave,
                habilitado: dto.Habilitado,
                privilegio: dto.Privilegio,
                personaId: dto.PersonaId
            );

            usuarioRepository.Add(usuario);
            dto.Id = usuario.Id;
            return dto;
        }

        public bool Update(UsuarioDTO dto)
        {
            var usuarioRepository = new UsuarioRepository();

            if (usuarioRepository.UsernameExists(dto.NombreUsuario, excludeId: dto.Id))
                throw new ArgumentException($"Ya existe otro usuario con el nombre de usuario '{dto.NombreUsuario}'.");

            if (usuarioRepository.EmailExists(dto.Email, excludeId: dto.Id))
                throw new ArgumentException($"Ya existe otro usuario con el email '{dto.Email}'.");

            var usuario = new Usuario(
                id: dto.Id,
                nombreUsuario: dto.NombreUsuario,
                email: dto.Email,
                clave: dto.Clave,
                habilitado: dto.Habilitado,
                privilegio: dto.Privilegio,
                personaId: dto.PersonaId
            );

            return usuarioRepository.Update(usuario);
        }

        public bool Delete(int id)
        {
            var usuarioRepository = new UsuarioRepository();
            return usuarioRepository.Delete(id);
        }

        public bool ValidarUsuario(string nombreUsuario, string clave)
        {
            var usuarioRepository = new UsuarioRepository();
            var usuarios = usuarioRepository.GetAll();
            return usuarios.Any(u => u.NombreUsuario.Equals(nombreUsuario, StringComparison.OrdinalIgnoreCase) && u.Clave == clave);
        }
    }
}
