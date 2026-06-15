using fastfoodadisyon_mvc.DTOs;
using fastfoodadisyon_mvc.Interfaces;
using fastfoodadisyon_mvc.Models;
using fastfoodadisyon_mvc.Repositories;

namespace fastfoodadisyon_mvc.Services
{
    public class AuthService : IAuthService
    {
        private readonly AuthRepository _authRepository;

        public AuthService(AuthRepository authRepository)
        {
            _authRepository = authRepository;
        }
        public async Task<UserResponse?> LoginAsync(UserLogin request)
        {
            var user = await _authRepository.FindAsync(request.userName);

            if (user == null)
                return null;

            if (user.passWord != request.passWord)
                return null;
            return new UserResponse
            {
                Id = user.Id,
                userName = user.userName,
                passWord = user.passWord
            };
        }
        public async Task<bool> RegisterAsync(UserCreate request)
        {
            var existingUser = await _authRepository.FindAsync(request.userName);

            if (existingUser != null)
                return false;

            await _authRepository.CreateAsync(new Users
            {
                userName = request.userName,
                passWord = request.passWord
            });

            return true;
        }
    }
}
