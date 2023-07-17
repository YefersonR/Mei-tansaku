using Core.Application.Dtos.Email;

namespace Core.Application.Interface.Services
{
    public interface IEmailService
    {
        Task SendAsync(EmailRequest request);
    }
}
