using ECommerce.Message.Context;
using ECommerce.Message.DTOs.UserMessageDtos;
using ECommerce.Message.Entities;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Message.Services.MessageServices
{
    public class UserMessageService(AppDbContext _context) : IUserMessageService
    {
        public async Task CreateAsync(CreateUserMessageDto createUserMessageDto)
        {
            var message = createUserMessageDto.Adapt<UserMessage>();
            await _context.AddAsync(message);
            await _context.SaveChangesAsync();  
        }

        public async Task DeleteAsync(int id)
        {
            var message = await _context.UserMessages.FindAsync(id);    
            _context.Remove(message);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ResultUserMessageDto>> GetAllAsync()
        {   //ef core verileri takip eder change tracking mekanizması ile, değişiklikleri takip eder, 
            //save changes ile tkaip ettiği değişiklikleri kaydeder
            //asnotrackingden sonra değişiklik yapıolırsa ve savechanges yapılırsa takip etmeediği için değişiklikleri kaydedemez
            //verilerin üzerinde işlem yapılmayacak, takip etme, asnotracking ile direk verileri çek, daha hızlı
            var messages = await _context.UserMessages.AsNoTracking().ToListAsync();
            return messages.Adapt<List<ResultUserMessageDto>>();

        }

        public async Task<ResultUserMessageDto> GetByIdAsync(int id)
        {
            //Find primarykey tarar, firstordefauolt önce tüm değerleri çeker sonra filtreleme yapar, find daha huızludur
            var message = await _context.UserMessages.FindAsync(id);
            return message.Adapt<ResultUserMessageDto>();
        }

        public async Task UpdateAsync(int id, UpdateUserMessageDto updateUserMessageDto)
        {
            var message = await _context.UserMessages.FindAsync(id);
            if (message == null)
            {
                throw new KeyNotFoundException("Mesaj bulunamadı");
            }
            //message = _mapper.Map(updateUserMessageDto, message); // kaynak,destination
            message.Email = updateUserMessageDto.Email;
            message.IsRead = updateUserMessageDto.IsRead;
            message.MessageBody = updateUserMessageDto.MessageBody;
            message.NameSurname = updateUserMessageDto.NameSurname;
            message.Subject = updateUserMessageDto.Subject;

            _context.Update(message);
            await _context.SaveChangesAsync();
        }
    }
}
