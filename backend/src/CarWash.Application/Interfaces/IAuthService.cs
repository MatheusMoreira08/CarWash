using CarWash.Application.DTOs;

namespace CarWash.Application.Interfaces;

public interface IAuthService
{
    Task<LoginResponse> LoginAsync(LoginRequest request);

    Task<LoginResponse> RefreshAsync(TokenRequest request);

    Task LogoutAsync(string refreshToken);
}
