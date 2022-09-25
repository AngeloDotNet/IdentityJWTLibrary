using IdentityAuth.Models.Request;
using IdentityAuth.Models.Response;

namespace IdentityAuth.BusinessLayer.Services;

public interface IIdentityService
{
    Task<AuthResponse> LoginAsync(LoginRequest request);
    Task<RegisterResponse> RegisterAsync(RegisterRequest request);
    Task<AuthResponse> RefreshTokenAsync(RefreshTokenRequest request);
}