namespace CarWash.Application.DTOs;

public class LoginRequest
{
    public string Email { get; set; } = string.Empty;

    public string Senha { get; set; } = string.Empty;
}

public class TokenRequest
{
    public string RefreshToken { get; set; } = string.Empty;
}

public class BaseResponse
{
    public string Message { get; set; } = string.Empty;

    public string? Code { get; set; }

    public string? TraceId { get; set; }
}

public class LoginResponse : BaseResponse
{
    public string AccessToken { get; set; } = string.Empty;

    public string RefreshToken { get; set; } = string.Empty;

    public UsuarioResponse Usuario { get; set; } = null!;
}

public class UsuarioResponse
{
    public Guid Id { get; set; }

    public string Email { get; set; } = string.Empty;
}
