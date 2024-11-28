using MediatR;
using vsapro.Shared.Model.Dtos;

namespace vspro.Application.Users.RegisterUser
{
    public class RegisterUserCommand : IRequest<CudResponseDto>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
