using ECommerce.Message.DTOs.UserMessageDtos;
using ECommerce.Message.Services.MessageServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Message.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController(IUserMessageService _messageService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var messages = await _messageService.GetAllAsync();
            return Ok(messages);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var message = await _messageService.GetByIdAsync(id);
            if (message == null)
            {
                return NotFound("Id değerine ait bir mesaj bulunamadı");
            }
            return Ok(message);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserMessageDto createUserMessageDto)
        {

            await _messageService.CreateAsync(createUserMessageDto);
            return Ok("Mesaj başarıyla oluşturuldu");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateUserMessageDto updateUserMessageDto)
        {
            var message = await _messageService.GetByIdAsync(id);
            if (message == null)
            {
                return NotFound("Id değerine ait bir değer bulunamadı");
            }
            await _messageService.UpdateAsync(id, updateUserMessageDto);
            return Ok("Mesaj başarıyla güncellendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var message = await _messageService.GetByIdAsync(id);
            if (message == null)
            {
                return NotFound("Id değerine ait bir değer bulunamadı");
            }
            await _messageService.DeleteAsync(id);
            return Ok("Mesaj başarıyla silindi");
        }
    }
}
