using ChatClient.Context;
using ChatClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatClient.Repository
{
    public class MessageRepository : IRepository<Message>, IDisposable
    {
        private ChatContext _chatContext = new ChatContext();
        public bool Create(Message msg)
        {
            _chatContext.Messages.Add(new Message()
            {
                Id = Guid.NewGuid(),
                UserId = _chatContext.Users.AsEnumerable().Last().Id.ToString(),
                RecipientId = msg.RecipientId,
                MessageText = msg.MessageText,
                TimeMsgCreated = DateTime.Now
            });
            _chatContext.SaveChanges();
            return true;
        }

        public void Delete(Message msg) { _chatContext.Messages.Remove(msg); }

        public void Dispose()
        {
            this.Dispose();
        }

        public Message Get(Guid id) => _chatContext.Messages.First(x => x.Id == id);

        public IEnumerable<Message> GetAll()
        {
            return _chatContext.Messages.ToList();
        }

        public IEnumerable<Message> GetAllByUserId(string recipientId)
        {
            return _chatContext.Messages.Where(a => a.RecipientId == recipientId);
        }
        

        public void Update(Message msg) { _chatContext.Messages.Update(msg); }

    }
}
