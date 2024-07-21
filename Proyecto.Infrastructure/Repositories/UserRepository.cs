
using System.Collections.Generic;
using System.Linq;
using Proyecto.Application.Models.Dtos;
using Proyecto.Domain.Repositories;
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

            public ICollection<Client> GetAllClients()
            {
            return _context.Users.OfType<Client>().ToList();
            }

            public ICollection<Admin> GetAllAdmins()
            {
            return _context.Users.OfType<Admin>().ToList();
            }

            public ICollection<Dev> GetAllDevs()
            {
                return _context.Users.OfType<Dev>().ToList();
            }

            public User GetByName(string name)
            {
            var userEntity = _context.Users.FirstOrDefault(u => u.Name == name);
            if (userEntity == null)
            {
                throw new ArgumentException("El usuario no existe");
            }

            return userEntity;
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
                    userToDelete.Activo = false;
                    _context.SaveChanges();
                }
                else
                {
                    throw new ArgumentException("El usuario no existe");
                }
            }


            public void UpdateUser(User user)
            {
                _context.Users.Update(user);
                _context.SaveChanges();
            }

            public User GetUserById(int id)
            {
            var user = _context.Users.Find(id);
            if (user == null)
            {
                throw new ArgumentException("El usuario no existe");
            }
            return user;
            }
        }
}

