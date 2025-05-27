using ECommerce.Message.DTOs.UserMessageDtos;

namespace ECommerce.Message.Services.MessageServices
{
    public interface IUserMessageService
    {
        Task<List<ResultUserMessageDto>> GetAllAsync();
        Task<ResultUserMessageDto> GetByIdAsync(int id);
        Task CreateAsync(CreateUserMessageDto createUserMessageDto);
        Task UpdateAsync(int id,UpdateUserMessageDto updateUserMessageDto);
        Task DeleteAsync(int id);

    }
}
