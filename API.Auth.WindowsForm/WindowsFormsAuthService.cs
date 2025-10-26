using API.Clients;
using DTOs;

namespace API.Auth.WindowsForms
{
    public class WindowsFormsAuthService : IAuthService
    {
        private static string? _currentToken;
        private static DateTime _tokenExpiration;
        private static string? _currentUsername;
        private static int _currentUserId;
        private static string? _currentUserRole; // Agrega campo para el rol

        public event Action<bool>? AuthenticationStateChanged;

        public async Task<bool> IsAuthenticatedAsync()
        {
            return !string.IsNullOrEmpty(_currentToken) && DateTime.UtcNow < _tokenExpiration;
        }

        public async Task<string?> GetTokenAsync()
        {
            var isAuth = await IsAuthenticatedAsync();
            return isAuth ? _currentToken : null;
        }

        public async Task<string?> GetUsernameAsync()
        {
            var isAuth = await IsAuthenticatedAsync();
            return isAuth ? _currentUsername : null;
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
                _currentToken = response.Token;
                _tokenExpiration = response.ExpiresAt;
                _currentUsername = response.NombreUsuario;
                _currentUserId = response.UsuarioId;

                // Obtener el rol desde la API usando el ID
                try
                {
                    _currentUserRole = await UsuarioApiClient.getUserRole(_currentUserId);
                }
                catch
                {
                    _currentUserRole = null;
                }

                AuthenticationStateChanged?.Invoke(true);
                return true;
            }

            return false;
        }

        public async Task LogoutAsync()
        {
            _currentToken = null;
            _tokenExpiration = default;
            _currentUsername = null;
            _currentUserId = 0;
            _currentUserRole = null;

            AuthenticationStateChanged?.Invoke(false);
        }

        public async Task CheckTokenExpirationAsync()
        {
            if (!string.IsNullOrEmpty(_currentToken) && DateTime.UtcNow >= _tokenExpiration)
            {
                await LogoutAsync();
            }
        }

        public async Task<int> GetUserIdAsync()
        {
            var isAuth = await IsAuthenticatedAsync();
            return isAuth ? _currentUserId : 0;
        }

        public async Task<string?> GetUserRoleAsync()
        {
            var isAuth = await IsAuthenticatedAsync();
            return isAuth ? _currentUserRole : null;
        }
    }
}