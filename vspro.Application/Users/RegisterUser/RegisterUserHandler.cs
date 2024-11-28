using MediatR;
using Microsoft.EntityFrameworkCore;
using vsapro.Domain.Entities;
using vsapro.Infrastructure.DatabaseAccess;
using vsapro.Shared.Constant;
using vsapro.Shared.Extension;
using vsapro.Shared.Model.Dtos;

namespace vspro.Application.Users.RegisterUser
{
    public class RegisterUserHandler(ApplicationDbContext _dbContext) : IRequestHandler<RegisterUserCommand, CudResponseDto>
    {
        public async Task<CudResponseDto> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var existingUser = await _dbContext.Users.SingleOrDefaultAsync(u => u.Email == request.Email);
            if (existingUser != null)
            {
                return new CudResponseDto { Message = ResponseMessageConstants.UserAlreadyExists, IsSucceeded = false };
            }

            var hashedPassword = request.Password.ToHashPassword();

            var newUser = new User
            {
                Email = request.Email,
                PasswordHash = hashedPassword,
                FirstName = request.FirstName,
                LastName = request.LastName
            };

            _dbContext.Users.Add(newUser);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return new CudResponseDto { Message = ResponseMessageConstants.UserRegisteredSuccessfully, Id = newUser.Id, IsSucceeded = true };
        }
    }
}
