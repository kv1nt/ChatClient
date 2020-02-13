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

        public void Create(User user)
        {
            _chatContext.Users.Add(new User()
            {
                Id = Guid.NewGuid(),
                Name = user.Name
            });
            _chatContext.SaveChanges();
        }

        public User Get(Guid id) => _chatContext.Users.First(x => x.Id == id);

        public IEnumerable<User> GetAll() => _chatContext.Users.ToList();

        public void Delete(User user) { _chatContext.Users.Remove(user); }

        public void Update(User user) { _chatContext.Users.Update(user); }
    }
}
