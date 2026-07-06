namespace GestorQA_GCP.Application.DTOs.Responses;

public abstract record BaseResponse(bool Success = true, string? Message = null);