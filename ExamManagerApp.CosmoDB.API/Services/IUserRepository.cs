using ExamManagerApp.CosmoDB.API.Models;

namespace ExamManagerApp.CosmoDB.API.Services
{
    public interface IUserRepository
    {
        Task<UserDocument> CreateUserAsync(UserDocument user);
        Task DeleteUserAsync(string userId);
        Task<UserDocument> GetUserByIdAsync(string userId);
        Task<UserDocument> UpdateUserAsync(UserDocument user);

    }
}
