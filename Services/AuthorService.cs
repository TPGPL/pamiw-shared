﻿using PamiwShared.Models;
using System.Net.Http.Json;

namespace PamiwShared.Services;

public class AuthorService : IAuthorService
{
    private readonly HttpClient _httpClient;

    public AuthorService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<ServiceResponse<List<Author>>> GetAuthorsAsync()
    {
        try
        {
            var response = await _httpClient.GetAsync("authors");

            if (!response.IsSuccessStatusCode)
            {
                return new ServiceResponse<List<Author>>
                {
                    Success = false,
                    Message = "HTTP Request failed."
                };
            }

            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<List<Author>>>()
                ?? new ServiceResponse<List<Author>>() { Success = false, Message = "Failed to read data." };

            result.Success = result.Success && result.Data is not null;

            return result;
        }
        catch (Exception ex)
        {
            return new ServiceResponse<List<Author>>()
            {
                Success = false,
                Message = ex.Message ?? "Unknown error occured."
            };
        }
    }

    public async Task<ServiceResponse<Author>> GetAuthorAsync(int id)
    {
        try
        {
            var response = await _httpClient.GetAsync($"authors/{id}");

            if (!response.IsSuccessStatusCode)
            {
                return new ServiceResponse<Author>
                {
                    Success = false,
                    Message = "HTTP Request failed."
                };
            }

            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<Author>>()
                ?? new ServiceResponse<Author>() { Success = false, Message = "Failed to read data." };

            result.Success = result.Success && result.Data is not null;

            return result;
        }
        catch (Exception ex)
        {
            return new ServiceResponse<Author>
            {
                Success = false,
                Message = ex.Message ?? "Unknown error occurred."
            };
        }
    }

    public async Task<ServiceResponse<Author>> UpdateAuthorAsync(int id, Author author)
    {
        try
        {
            var response = await _httpClient.PutAsJsonAsync($"authors/{id}", author);
            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<Author>>()
                ?? new ServiceResponse<Author>() { Success = false, Message = "Failed to read data." };

            return result;
        }
        catch (Exception ex)
        {
            return new ServiceResponse<Author>
            {
                Success = false,
                Message = ex.Message ?? "Unknown error occurred."
            };
        }
    }

    public async Task<ServiceResponse<Author>> CreateAuthorAsync(Author author)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync($"authors", author);
            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<Author>>()
                ?? new ServiceResponse<Author>() { Success = false, Message = "Failed to read data." };

            return result;
        }
        catch (Exception ex)
        {
            return new ServiceResponse<Author>
            {
                Success = false,
                Message = ex.Message ?? "Unknown error occurred."
            };
        }
    }

    public async Task<ServiceResponse<Author>> DeleteAuthorAsync(int id)
    {
        try
        {
            var response = await _httpClient.DeleteAsync($"authors/{id}");
            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<Author>>()
                ?? new ServiceResponse<Author>() { Success = false, Message = "Failed to read data." };

            return result;
        }
        catch (Exception ex)
        {
            return new ServiceResponse<Author>
            {
                Success = false,
                Message = ex.Message ?? "Unknown error occurred."
            };
        }
    }
}