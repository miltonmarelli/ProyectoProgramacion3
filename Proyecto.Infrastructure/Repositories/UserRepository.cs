
using System.Collections.Generic;
using System.Linq;
using Proyecto.Application.Models.Dtos;
using Proyecto.Application.Repositories;
using Proyecto.Domain.Models;
using Proyecto.Infraestructure.Context;

namespace Proyecto.Infraestructure.Repositories
    {
        public class UserRepository : IUserRepository
    {
            private readonly ProyectoDbContext _context;

            public UserRepository(ProyectoDbContext context)
            {
                _context = context;
            }

            public ICollection<User> GetAllUsers()
            {
                return _context.Users.ToList();
            }

        public User GetByName(string name)
        {
            var userEntity = _context.Users.FirstOrDefault(u => u.Name == name);
            if (userEntity == null)
            {
                throw new ArgumentException("El usuario no existe");
            }

            switch (userEntity.Role.ToLower())
            {
                case "admin":
                    return new Admin
                    {
                        Name = userEntity.Name,
                        Email = userEntity.Email,
                        Role = userEntity.Role
                    };

                case "client":
                    return new Client
                    {
                        Name = userEntity.Name,
                        Email = userEntity.Email,
                        Role = userEntity.Role
                    };

                case "dev":
                    return new Dev
                    {
                        Name = userEntity.Name,
                        Email = userEntity.Email,
                        Role = userEntity.Role
                    };

                default:
                    throw new InvalidOperationException("Rol de usuario no valido");
            }
        }

        public void AddUser(User user)
            {
                _context.Users.Add(user);
                _context.SaveChanges();
            }

            public void DeleteUser(int id)
            {
                var userToDelete = _context.Users.Find(id);
                if (userToDelete != null)
                {
                    _context.Users.Remove(userToDelete);
                    _context.SaveChanges();
                }
                else
                {
                    throw new ArgumentException("El usuario no existe");
                }
            }

        public User GetById(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
            {
                throw new ArgumentException("El usuario no existe");
            }

            return user;
        }

        public void UpdateUser(User user)
            {
                _context.Users.Update(user);
                _context.SaveChanges();
            }

        public User GetUserById(int id)
        {
            throw new NotImplementedException();
        }
    }
    }

