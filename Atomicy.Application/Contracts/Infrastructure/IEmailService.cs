using Atomicy.Application.Models.Mail;
using System.Threading.Tasks;

namespace Atomicy.Application.Contracts.Infrastructure
{
    public interface IEmailService
    {
        Task<bool> SendEmail(Email email);
    }
}
