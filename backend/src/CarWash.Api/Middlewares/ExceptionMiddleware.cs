using System.Diagnostics;
using System.Net;
using System.Text.Json;
using CarWash.Application.DTOs;
using CarWash.Application.Exceptions;

namespace CarWash.Api.Middlewares;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (AuthException ex)
        {
            await HandleAuthExceptionAsync(context, ex);
        }
        catch (Exception ex)
        {
            // Oculta o erro real no log e devolve a mensagem amigável 500
            _logger.LogError(ex, "Erro interno não tratado.");
            await HandleInternalExceptionAsync(context);
        }
    }

    private static Task HandleAuthExceptionAsync(HttpContext context, AuthException ex)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = ex.StatusCode;

        var response = new BaseResponse
        {
            Code = ex.ErrorCode,
            Message = ex.Message,
            TraceId = Activity.Current?.Id ?? context.TraceIdentifier
        };

        string json = JsonSerializer.Serialize(response, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
        return context.Response.WriteAsync(json);
    }

    private static Task HandleInternalExceptionAsync(HttpContext context)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        var response = new BaseResponse
        {
            Code = "INTERNAL_SERVER_ERROR",
            Message = "Não foi possível concluir o login no momento. Tente novamente.",
            TraceId = Activity.Current?.Id ?? context.TraceIdentifier
        };

        string json = JsonSerializer.Serialize(response, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
        return context.Response.WriteAsync(json);
    }
}
