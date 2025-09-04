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
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                Email = usuario.Email,
                Habilitado = usuario.Habilitado,
                Clave = usuario.Clave
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
                Nombre = u.Nombre,
                Apellido = u.Apellido,
                Email = u.Email,
                Habilitado = u.Habilitado,
                Clave = u.Clave
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
                nombre: dto.Nombre,
                apellido: dto.Apellido,
                email: dto.Email,
                clave: dto.Clave,
                habilitado: dto.Habilitado
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
                nombre: dto.Nombre,
                apellido: dto.Apellido,
                email: dto.Email,
                clave: dto.Clave,
                habilitado: dto.Habilitado
            );

            return usuarioRepository.Update(usuario);
        }

        public bool Delete(int id)
        {
            var usuarioRepository = new UsuarioRepository();
            return usuarioRepository.Delete(id);
        }
    }
}
