﻿using Proyecto.Application.Models.Request;
using Proyecto.Application.Models.Dtos;
using Proyecto.Domain.Models;

namespace Proyecto.Application.IServices
{
    public interface IUserService
    {
            ICollection<UserDto> GetAll();
            User GetByName(string name);
            UserDto Create(UserSaveRequest user);
            void DeleteUser(int id);
            UserDto GetById(int id);
            UserDto UpdateUser(int id, UserSaveRequest user);

    }
}
