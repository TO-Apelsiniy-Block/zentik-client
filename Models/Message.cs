using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zentik.Models
{
    internal class Message
    {
        public int SenderId { get; set; }  // -1 = моё сообщение
        public int ChatId { get; set; }
        public string Text { get; set; }
        public DateTime Timestamp { get; set; }
        public bool IsRead { get; set; }

        // Вычисляемые свойства
        public bool IsMyMessage => SenderId == -1;
        public string FormattedTime
        {
            get
            {
                var now = DateTime.Now;
                var diff = now - Timestamp;

                if (diff.TotalSeconds < 60)
                    return "только что";
                if (diff.TotalMinutes < 60)
                    return $"{(int)diff.TotalMinutes} мин назад";
                if (Timestamp.Date == now.Date)
                    return Timestamp.ToString("HH:mm");
                if (Timestamp.Date == now.Date.AddDays(-1))
                    return $"вчера в {Timestamp:HH:mm}";

                return Timestamp.ToString("dd.MM.yy HH:mm");
            }
        }

        // Конструктор
        public Message(int senderId, int chatId, string text, DateTime timestamp)
        {
            SenderId = senderId;
            ChatId = chatId;
            Text = text ?? throw new ArgumentNullException(nameof(text));
            Timestamp = timestamp;
        }

        // Методы бизнес-логики
        public void UpdateText(string newText)
        {
            if (string.IsNullOrWhiteSpace(newText))
                throw new ArgumentException("Текст сообщения не может быть пустым");

            Text = newText;
        }
    }
}
