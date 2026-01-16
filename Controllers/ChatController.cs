using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zentik.Models;
using Zentik.Server;
using Zentik.Views;

namespace Zentik.Controllers
{
    internal class ChatController : IDisposable
    {
        private readonly RestClient _restClient;
        private readonly Chat _chat;
        private readonly ChatView _view;
        private readonly ChatsManager _listController;
        private readonly List<Models.Message> _messages = new();

        public ChatController(Chat chat, ChatView view, ChatsManager listController, RestClient restClient)
        {
            _chat = chat ?? throw new ArgumentNullException(nameof(chat));
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _listController = listController ?? throw new ArgumentNullException(nameof(listController));
            _restClient = restClient ?? throw new ArgumentNullException(nameof(chat));

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
            var message = await SaveMessage(text, _chat.Id);
            _messages.Add(message);
            _view.DisplayMessage(message);
            _listController.SendMessage(message); // TODO возможный баг
        }

        // Получение нового сообщения 
        public void ReceiveMessage(Models.Message message)
        {
            // Проверяем, что сообщение для этого чата
            if (message.ChatId != _chat.Id) return;

            // Сохраняем в коллекцию
            _messages.Add(message);

            // Если чат открыт - отображаем
            if (_view.Visible)
            {
                _view.DisplayMessage(message);
            }
        }

        // Заглушки для реальной реализации
        private Task<List<Models.Message>> GetMessagesFromStorage(int chatId)
        {
            // TODO Позже заменишь на реальную загрузку из БД
            return _restClient.GetMessagesAsync(chatId);
        }

        private async Task<Models.Message> SaveMessage(string text, int chatId)
        {
            // TODO Позже заменить на сохранение в БД
            Console.WriteLine($"Сохранено сообщение: {text}");
            return await _restClient.CreateMessageAsync(text, chatId);
        }

        public void Dispose()
        {
            _view.MessageSent -= OnMessageSent;
        }
    }
}
