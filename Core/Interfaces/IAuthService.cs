using JwtAutorizacionAutenciacionEnRoles.Core.Dtos;

namespace JwtAutorizacionAutenciacionEnRoles.Core.Interfaces
{
    public interface IAuthService
    {
        // VERSION 3
        Task<AuthServiceResponseDto> SeedRolesAsync();
        Task<AuthServiceResponseDto> RegistrerAsync(RegisterDto registerDto);
        Task<AuthServiceResponseDto> LoginAsync(LoginDto loginDto);
        Task<AuthServiceResponseDto> MakeAdminAsync(UpdatePermissionDto updatePermissionDto);
        Task<AuthServiceResponseDto> MakeOwnerAsync(UpdatePermissionDto updatePermissionDto);

    }
}
