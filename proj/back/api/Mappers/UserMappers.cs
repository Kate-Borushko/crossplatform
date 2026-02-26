using api.Dtos.User;
using api.Models;
using System.ComponentModel.DataAnnotations;

namespace api.Mappers
{
    public static class UserMappers
    {
        public static UserDto ToUserDto(this User UserModel)
        {
            return new UserDto
            {
                UserID = UserModel.UserID,
                Name = UserModel.Name,
                Surname = UserModel.Surname,
                Email = UserModel.Email,
                //Role = UserModel.Role,
                Position = UserModel.Position,
                EmployeeID = UserModel.EmployeeID,
            };
        }

        public static User ToUserFromCreateDTO(this CreateUserRequestDto UserDto, int EmployeeId)
        {
            return new User
            {
                Name = UserDto.Name,
                Surname = UserDto.Surname,
                Email = UserDto.Email,
                //Role = UserDto.Role,
                Position = UserDto.Position,
                EmployeeID = EmployeeId
            };
        }

        public static User ToUserFromUpdateDTO(this UpdateUserRequestDto UserDto)
        {
            return new User
            {
                Name = UserDto.Name,
                Surname = UserDto.Surname,
                Email = UserDto.Email,
                //Role = UserDto.Role,
                Position = UserDto.Position
            };
        }
    }
}
