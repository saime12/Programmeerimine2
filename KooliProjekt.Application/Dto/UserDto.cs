using System;
namespace KooliProjekt.Application.Dto
{
    // Password is deliberately excluded from API responses.
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
