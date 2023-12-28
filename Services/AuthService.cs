using PamiwShared.Models;
using System.Net.Http.Json;

namespace PamiwShared.Services;

public class AuthService : IAuthService
{
    private HttpClient _httpClient;

    public AuthService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<ServiceResponse<string>> LoginAsync(UserLogin user)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync("auth/login", user);
            var serviceResponse = await response.Content.ReadFromJsonAsync<ServiceResponse<JwtResponse>>();

            if (!response.IsSuccessStatusCode)
            {
                return new ServiceResponse<string>()
                {
                    Success = false,
                    Message = serviceResponse?.Message ?? "Invalid user credentials."
                };
            }

            return new ServiceResponse<string>()
            {
                Success = true,
                Data = serviceResponse?.Data?.Token
            };
        }
        catch (Exception)
        {
            return new ServiceResponse<string>()
            {
                Success = false,
                Message = "Failed to login."
            };
        }
    }

    public async Task<ServiceResponse<string>> RegisterAsync(UserRegister user)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync("auth/register", user);
            var serviceResponse = await response.Content.ReadFromJsonAsync<ServiceResponse<string>>();

            if (!response.IsSuccessStatusCode)
            {
                return new ServiceResponse<string>()
                {
                    Success = false,
                    Message = serviceResponse?.Message ?? "Failed to register."
                };
            }

            return new ServiceResponse<string>()
            {
                Success = true,
                Message = serviceResponse?.Message ?? "User registered successfully."
            };
        }
        catch (Exception)
        {
            return new ServiceResponse<string>()
            {
                Success = false,
                Message = "Failed to register."
            };
        }
    }
}
