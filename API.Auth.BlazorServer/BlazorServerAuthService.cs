using DTOs;
using API.Clients;

namespace API.Auth.Blazor.Server
{
    public class BlazorServerAuthService : IAuthService
    {
        private static SessionData? _currentSession;

        public event Action<bool>? AuthenticationStateChanged;

        private class SessionData
        {
            public string? Token { get; set; }
            public string? Username { get; set; }
            public DateTime Expiration { get; set; }
            public int UserId { get; set; }
            public string? Role { get; set; }
        }

        public Task<bool> IsAuthenticatedAsync()
        {
            if (_currentSession != null)
            {
                return Task.FromResult(!string.IsNullOrEmpty(_currentSession.Token) && DateTime.UtcNow < _currentSession.Expiration);
            }
            return Task.FromResult(false);
        }

        public Task<string?> GetTokenAsync()
        {
            return Task.FromResult(_currentSession?.Token);
        }

        public Task<string?> GetUsernameAsync()
        {
            return Task.FromResult(_currentSession?.Username);
        }

        public async Task<bool> LoginAsync(string username, string password)
        {
            var request = new LoginRequest
            {
                NombreUsuario = username,
                Clave = password
            };

            var authClient = new AuthApiClient();
            var response = await authClient.LoginAsync(request);

            if (response != null)
            {
                // Fetch role from API using user ID
                string? role = null;
                try
                {
                    role = await UsuarioApiClient.getUserRole(response.UsuarioId);
                    Console.WriteLine($"[DEBUG] Rol recuperado para usuario {response.UsuarioId}: {role}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[ERROR] No se pudo recuperar el rol: {ex.Message}");
                    // Optionally handle error or set a default role
                }

                _currentSession = new SessionData
                {
                    Token = response.Token,
                    Username = response.NombreUsuario,
                    Expiration = response.ExpiresAt,
                    UserId = response.UsuarioId,
                    Role = role
                };

                AuthenticationStateChanged?.Invoke(true);
                return true;
            }

            return false;
        }

        public Task LogoutAsync()
        {
            _currentSession = null;
            AuthenticationStateChanged?.Invoke(false);
            return Task.CompletedTask;
        }

        public async Task CheckTokenExpirationAsync()
        {
            if (!await IsAuthenticatedAsync())
            {
                await LogoutAsync();
            }
        }

        public Task<int> GetUserIdAsync()
        {
            return Task.FromResult(_currentSession?.UserId ?? 0);
        }

        public Task<string?> GetUserRoleAsync()
        {
            return Task.FromResult(_currentSession?.Role);
        }
    }
}