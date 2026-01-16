using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zentik.Models
{
    internal class Chat
    {
        public int Id { get; set; }
        public string ContactName { get; set; }
        public string LastMessage { get; set; }
        public Image Avatar { get; set; }
        public DateTime LastMessageTime { get; set; }
        public int UnreadCounter { get; set; }

        // Конструктор для теста, потом убрать
        public Chat(string contactName, string lastMessage, int unreadCounter) 
        {
            ContactName = contactName;
            LastMessage = lastMessage;
            Avatar = Image.FromFile(".\\..\\..\\..\\pictures\\defoltAvatar.jpg");
            LastMessageTime = DateTime.Now;
            UnreadCounter = unreadCounter;
        }

        // Основной конструктор
        public Chat(string contactName, string lastMessage, Image avatar, DateTime lastMessageTime, int unreadCounter) 
        {
            ContactName = contactName;
            LastMessage = lastMessage;
            Avatar = avatar;
            LastMessageTime = lastMessageTime;
            UnreadCounter = unreadCounter;
        }

    }
}
