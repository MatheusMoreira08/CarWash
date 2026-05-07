using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using BCrypt.Net;
using CarWash.Application.DTOs;
using CarWash.Application.Exceptions;
using CarWash.Application.Interfaces;
using CarWash.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace CarWash.Application.Services;

public class AuthService : IAuthService
{
    private readonly ICarWashDbContext _context;
    private readonly IConfiguration _configuration;
    private readonly ILogger<AuthService> _logger;

    public AuthService(ICarWashDbContext context, IConfiguration configuration, ILogger<AuthService> logger)
    {
        _context = context;
        _configuration = configuration;
        _logger = logger;
    }

    public async Task<LoginResponse> LoginAsync(LoginRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Email) || string.IsNullOrWhiteSpace(request.Senha))
        {
            throw new AuthException(400, "AUTH_VALIDATION_ERROR", "Dados de acesso inválidos. Verifique os campos e tente novamente.");
        }

        string emailNormalizado = request.Email.Trim().ToLowerInvariant();

        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == emailNormalizado);

        if (user == null || !user.Active)
        {
            _logger.LogWarning("LOGIN_FALHA: Tentativa de acesso para utilizador inexistente ou inativo. Email: {Email}", MascararEmail(emailNormalizado));
            throw new AuthException(401, "AUTH_INVALID_CREDENTIALS", "Usuário ou senha inválidos.");
        }

        if (user.BlockedUntil.HasValue && user.BlockedUntil.Value > DateTime.UtcNow)
        {
            _logger.LogWarning("LOGIN_BLOQUEIO: Utilizador bloqueado tentou aceder. Email: {Email}", MascararEmail(emailNormalizado));
            throw new AuthException(403, "AUTH_TEMPORARILY_BLOCKED", "Acesso temporariamente bloqueado por tentativas inválidas. Tente novamente em alguns minutos.");
        }

        bool senhaValida = BCrypt.Net.BCrypt.Verify(request.Senha, user.PasswordHash);

        if (!senhaValida)
        {
            user.FailedLoginAttempts++;

            if (user.FailedLoginAttempts >= 3)
            {
                user.BlockedUntil = DateTime.UtcNow.AddMinutes(15);
                await _context.SaveChangesAsync();

                _logger.LogWarning("LOGIN_BLOQUEIO: Utilizador bloqueado por exceder 3 falhas. Email: {Email}", MascararEmail(emailNormalizado));
                throw new AuthException(403, "AUTH_TEMPORARILY_BLOCKED", "Acesso temporariamente bloqueado por tentativas inválidas. Tente novamente em alguns minutos.");
            }

            await _context.SaveChangesAsync();
            _logger.LogWarning("LOGIN_FALHA: Credencial inválida. Email: {Email}", MascararEmail(emailNormalizado));
            throw new AuthException(401, "AUTH_INVALID_CREDENTIALS", "Usuário ou senha inválidos.");
        }

        user.FailedLoginAttempts = 0;
        user.BlockedUntil = null;

        string accessToken = GerarAccessToken(user);
        string refreshToken = GerarRefreshToken();

        var session = new Session
        {
            UserId = user.Id,
            RefreshTokenHash = BCrypt.Net.BCrypt.HashPassword(refreshToken),
            ExpiresAt = DateTime.UtcNow.AddDays(7),
            IsRevoked = false
        };

        _context.Sessions.Add(session);
        await _context.SaveChangesAsync();

        _logger.LogInformation("LOGIN_SUCESSO: Utilizador autenticado. Email: {Email}", MascararEmail(emailNormalizado));

        return new LoginResponse
        {
            Message = "Login realizado com sucesso.",
            AccessToken = accessToken,
            RefreshToken = refreshToken,
            Usuario = new UsuarioResponse { Id = user.Id, Email = user.Email }
        };
    }

    public Task<LoginResponse> RefreshAsync(TokenRequest request)
    {
        throw new NotImplementedException();
    }

    public Task LogoutAsync(string refreshToken)
    {
        throw new NotImplementedException();
    }

    private string GerarAccessToken(User user)
    {
        var jwtSettings = _configuration.GetSection("JwtSettings");
        string secretKey = jwtSettings["Secret"] ?? throw new InvalidOperationException("JWT Secret não configurado.");

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var token = new JwtSecurityToken(
            issuer: jwtSettings["Issuer"],
            audience: jwtSettings["Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(15),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    private static string GerarRefreshToken()
    {
        byte[] randomNumber = new byte[32];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomNumber);
        return Convert.ToBase64String(randomNumber);
    }

    private static string MascararEmail(string email)
    {
        string[] partes = email.Split('@');
        if (partes.Length != 2 || partes[0].Length <= 2)
        {
            return "***@***";
        }

        return $"{partes[0].Substring(0, 2)}***@{partes[1]}";
    }
}
