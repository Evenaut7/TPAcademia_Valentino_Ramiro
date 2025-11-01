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
                Tipo = usuario.Tipo,
                Legajo = usuario.Legajo,
                Clave = usuario.Clave,
                Salt = usuario.Salt,
                PersonaId = usuario.PersonaId,
                PlanId = usuario.PlanId
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
                Tipo = u.Tipo,
                Legajo = u.Legajo,
                Clave = u.Clave,
                Salt = u.Salt,
                PersonaId = u.PersonaId,
                PlanId = u.PlanId
            }).ToList();
        }

        public string GetUserRole(int usuarioId)
        {
            var usuarioRepository = new UsuarioRepository();
            var usuario = usuarioRepository.GetUserRole(usuarioId);

            if (usuario == null)
            {
                throw new Exception("Usuario no encontrado");
            }
            else if (!usuario.Habilitado)
            {
                throw new Exception("Usuario inhabilitado");
            }
            else
            {
                return usuario.Tipo;
            }
        }

        public UsuarioDTO Add(UsuarioDTO dto)
        {
            var usuarioRepository = new UsuarioRepository();

            if (usuarioRepository.UsernameExists(dto.NombreUsuario))
                throw new ArgumentException($"Ya existe un usuario con el nombre de usuario '{dto.NombreUsuario}'.");

            if (usuarioRepository.EmailExists(dto.Email))
                throw new ArgumentException($"Ya existe un usuario con el email '{dto.Email}'.");

            var usuario = new Usuario();
            usuario.NombreUsuario = dto.NombreUsuario;
            usuario.Email = dto.Email;
            usuario.Habilitado = dto.Habilitado;
            usuario.Tipo = dto.Tipo;
            usuario.Legajo = dto.Legajo;
            usuario.PersonaId = dto.PersonaId;
            usuario.PlanId = dto.PlanId;

            // Hashea la clave y genera el salt
            usuario.SetClave(dto.Clave);

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

            // Obtener el usuario actual de la base de datos
            var usuarioActual = usuarioRepository.Get(dto.Id);
            if (usuarioActual == null)
                return false;

            Usuario usuario;
            if (!string.IsNullOrWhiteSpace(dto.Clave))
            {
                // Si se ingresó una nueva clave, hashearla y generar nuevo salt
                usuario = new Usuario
                {
                    Id = dto.Id,
                    NombreUsuario = dto.NombreUsuario,
                    Email = dto.Email,
                    Habilitado = dto.Habilitado,
                    Tipo = dto.Tipo,
                    Legajo = dto.Legajo,
                    PersonaId = dto.PersonaId,
                    PlanId = dto.PlanId
                };
                usuario.SetClave(dto.Clave);
            }
            else
            {
                // Si no se ingresó clave, mantener la actual
                usuario = new Usuario
                {
                    Id = dto.Id,
                    NombreUsuario = dto.NombreUsuario,
                    Email = dto.Email,
                    Habilitado = dto.Habilitado,
                    Tipo = dto.Tipo,
                    Legajo = dto.Legajo,
                    PersonaId = dto.PersonaId,
                    PlanId = dto.PlanId,
                    Clave = usuarioActual.Clave,
                    Salt = usuarioActual.Salt,
                    Plan = usuarioActual.Plan
                };
            }

            return usuarioRepository.Update(usuario);
        }

        public bool Delete(int id)
        {
            var usuarioRepository = new UsuarioRepository();
            var usuario = usuarioRepository.Get(id);
            if (usuario == null)
                return false;

            if (usuario.Tipo == "Administrador")
            {
                return usuarioRepository.Delete(id);
            }
            else
            {
                usuario.Habilitado = false;
                return usuarioRepository.Update(usuario);
            }
        }

        public bool ValidarUsuario(string nombreUsuario, string clave)
        {
            var usuarioRepository = new UsuarioRepository();
            var usuario = usuarioRepository.GetByNombreUsuario(nombreUsuario);

            if (usuario == null)
                return false;

            return usuario.ValidarClave(clave);
        }
    }
}
