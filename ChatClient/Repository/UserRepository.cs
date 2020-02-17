using ChatClient.Context;
using ChatClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatClient.Repository
{
    public class UserRepository : IRepository<User>
    {
        private ChatContext _chatContext = new ChatContext();

        public bool Create(User user)
        {
            var existsUser = _chatContext.Users.FirstOrDefault(x => x.Name == user.Name && x.Password == user.Password);
            if (existsUser == null)
            {
                _chatContext.Users.Add(new User()
                {
                    Id = user.Id,
                    Name = user.Name,
                    Password = user.Password
                });
                _chatContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
           
        }

        public User Get(Guid id) => _chatContext.Users.First(x => x.Id == id);
        public IEnumerable<User> GetAll() => _chatContext.Users.ToList();
        public IEnumerable<User> GetAllByUserId(string id) => _chatContext.Users.Where(x => x.Id == Guid.Parse(id));
        public void Delete(User user) { _chatContext.Users.Remove(user); }
        public void Update(User user) { _chatContext.Users.Update(user); }
    }
}
