using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zentik.Models;
using Zentik.Exceptions;

namespace Zentik.Server
{
    internal class RestClient
    {
        private string _authToken;

        public async Task<Models.Message> CreateMessageAsync(string text, int chatId)
        {
            return new Models.Message(-1, chatId, text, DateTime.Now);
        }

        public async Task<List<Models.Message>> GetMessagesAsync(int chatId)
        {
            return new List<Models.Message>
            {
                new Models.Message(123, chatId, "Привет!", DateTime.Now.AddMinutes(-5)) ,
                new Models.Message(-1, chatId, "Привет, как дела?", DateTime.Now.AddMinutes(-4))
            };
        }

        public async Task<List<Chat>> GetChatsAsync()
        {
            return new List<Chat>
            {
                new Chat(1, "Саид1", "Дедлайн завтра", 12),
                new Chat(2, "Саид2", "Дедлайн завтра.", 99),
                new Chat(3, "Саид3", "Дедлайн завтра!", 100),
                new Chat(4, "Саид4", "Дедлайн завтра?", 0),
            };
        }

        
        public async Task<User> GetUserByEmailAsync(string email)
        {
            if (email == "Kostya")
            {
                throw new NotFoundException();
            }
            var a = Random.Shared.Next(100, 10000);
            return new User() { Email = email, UserId = a, Username = $"SearchUser {a}" };
        }

        public async Task<Chat> CreateChatAsync(int userId)
        {
            // Временная реализация
            if (userId % 3 == 0)
            {
                throw new AlreadyExistsException();
            }
            return new Chat(userId, $"Username {userId}", "Новый чат", 0);
        }
        public async Task<int> GetChatIdAsync(int userId)
        {
            // Временная реализация
            return Random.Shared.Next(1, 4);
        }

        public async Task SendVerificationCodeAsync(string email)
        {

        }

        public async Task<string> RegisterAsync(string username, string email, string code, string password)
        {
            return "11";
        }

        public async Task<string> LoginAsync(string email, string code, string password)
        {

            return "11";
        }
    }
}
