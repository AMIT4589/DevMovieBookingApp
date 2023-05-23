using MongoDBSetup.Models;
using MongoDBSetup.Models.Dto;

namespace MongoDBSetup.Services
{
    public interface IUserRepository
    {
        bool IsUniqueUser(string username);
        Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO);
        Task<LocalUser> Register(RegistrationRequestDTO registrationRequestDTO);
    }
}
