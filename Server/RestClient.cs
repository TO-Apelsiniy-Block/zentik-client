using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zentik.Models;

namespace Zentik.Server
{
    internal class RestClient
    {
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
    }
}
