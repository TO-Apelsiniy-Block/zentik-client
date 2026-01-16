using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zentik.Models;
using Zentik.Views;

namespace Zentik.Controllers
{
    internal class ChatController : IDisposable
    {
        private readonly Chat _chat;
        private readonly ChatView _view;
        private readonly ChatsManager _listController;
        private readonly List<Models.Message> _messages = new();

        public ChatController(Chat chat, ChatView view, ChatsManager listController)
        {
            _chat = chat ?? throw new ArgumentNullException(nameof(chat));
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _listController = listController ?? throw new ArgumentNullException(nameof(listController));

            // Настраиваем View
            _view.SetChatInfo(chat.ContactName, chat.Avatar);
            _view.MessageSent += OnMessageSent;

            // Загружаем историю
            LoadHistory();
        }

        // Загрузка истории сообщений
        public async Task LoadHistory()
        {
            // Очищаем View
            _view.ClearMessages();

            // Загружаем данные (пока тестовые, потом из БД)
            var messages = await GetMessagesFromStorage(_chat.Id);
            _messages.AddRange(messages);

            // Отображаем во View
            foreach (var message in messages)
            {
                _view.DisplayMessage(message);
            }
        }

        // Обработка отправки сообщения
        private async void OnMessageSent(object sender, string text)
        {
            // Создаем модель
            var message = new Models.Message (-1, _chat.Id, text, DateTime.Now)
            {
                IsRead = true
            };

            // Сохраняем в хранилище
            await SaveMessage(message);

            // Добавляем в локальную коллекцию
            _messages.Add(message);

            // Обновляем модель чата
            _chat.LastMessage = message.Text;
            _chat.LastMessageTime = message.Timestamp;
            _chat.UnreadCounter = 0;

            // Обновляем список чатов (через ChatListController)
            //_listController.UpdateChat(_chat);

            // Отображаем в View
            _view.DisplayMessage(message);
        }

        // Получение нового сообщения 
        public void ReceiveMessage(Models.Message message)
        {
            // Проверяем, что сообщение для этого чата
            if (message.ChatId != _chat.Id) return;

            // Сохраняем в коллекцию
            _messages.Add(message);

            // Обновляем модель чата
            _chat.LastMessage = message.Text;
            _chat.LastMessageTime = message.Timestamp;
            _chat.UnreadCounter++;

            // Обновляем список чатов
            //_listController.UpdateChat(_chat);

            // Если чат открыт - отображаем
            if (_view.Visible)
            {
                _view.DisplayMessage(message);
                _chat.UnreadCounter = 0;
            }
        }

        // Заглушки для реальной реализации
        private Task<List<Models.Message>> GetMessagesFromStorage(int chatId)
        {
            // Позже заменишь на реальную загрузку из БД
            return Task.FromResult(new List<Models.Message>
            {
                new Models.Message(123, chatId, "Привет!", DateTime.Now.AddMinutes(-5)) ,
                new Models.Message(-1, chatId, "Привет, как дела?", DateTime.Now.AddMinutes(-4))
            });
        }

        private Task SaveMessage(Models.Message message)
        {
            // TODO Позже заменить на сохранение в БД
            Console.WriteLine($"Сохранено сообщение: {message.Text}");
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _view.MessageSent -= OnMessageSent;
        }
    }
}
