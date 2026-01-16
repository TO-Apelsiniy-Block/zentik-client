using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zentik.Models;
using Zentik.Views;
using Zentik.Server;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Zentik.Controllers
{
    internal class ChatsManager
    {
        private readonly RestClient _restClient;
        private readonly List<Chat> _chats = new();         // список чатов
        private readonly FlowLayoutPanel _chatListPanel;    // панель, на которой располагаются чаты
        private ChatListItem _selectedItem;                 // выбранный (текущий) чат
        private ChatController _currentChatController;
        private Panel _chatContainer; // Контейнер для ChatView


        // Асинхронный конструткор
        public static async Task<ChatsManager> Create(
            FlowLayoutPanel chatListPanel, 
            Panel chatContainer, 
            RestClient restClient)
        {
            var chatsManager = new ChatsManager(chatListPanel, chatContainer, restClient);
            await chatsManager.LoadChats();
            return chatsManager;
        }

        // Создавать нужно через статически метод
        private ChatsManager(FlowLayoutPanel chatListPanel, Panel chatContainer, RestClient restClient)
        {
            _chatListPanel = chatListPanel;
            _chatContainer = chatContainer;
            _restClient = restClient;
        }

        // Загрузка чатов
        private async Task LoadChats() // TODO баги из-за async
        {
            _chats.AddRange(await _restClient.GetChatsAsync());

            // Создание для каждого чата UI
            foreach (var chat in _chats)
            {
                ChatListItem chatListItem = new ChatListItem(chat);

                // Подписка на клик (выбор чата в списке чатов)
                chatListItem.Click += (s, e) => SelectChatItem(chatListItem);
                foreach (Control child in chatListItem.Controls)
                {
                    child.Click += (s, e) => SelectChatItem(chatListItem);
                }
                _chatListPanel.Controls.Add(chatListItem);
            }
        }

        // При выделении чата
        private void SelectChatItem(ChatListItem chatListItem)
        {
            if (_selectedItem != null)
                _selectedItem.IsSelected = false;

            chatListItem.IsSelected = true;
            _selectedItem = chatListItem;


            // Открываем чат
            OpenChat(chatListItem.ChatData);

            // TODO При открытии чата все сообщения прочитываются автоматически
            chatListItem.UnreadCounter = 0;
            chatListItem.ChatData.UnreadCounter = 0;

        }

        private void OpenChat(Chat chat)
        {
            // Удаляем предыдущий чат
            if (_currentChatController != null)
            {
                _currentChatController.Dispose();
                _chatContainer.Controls.Clear();
            }

            var chatView = new ChatView();
            chatView.Dock = DockStyle.Fill;

            _currentChatController = new ChatController(chat, chatView, this, _restClient);

            _chatContainer.Controls.Add(chatView);

            _currentChatController.LoadHistory();
        }

        public void ReceiveMessage(Models.Message message)
        {
            // Обновляет модель и представление ChatListItem при ПОЛУЧЕНИИ нового сообщения

            ChatListItem chatView = _chatListPanel.Controls
                .Cast<ChatListItem>()
                .First(c => c.ChatData.Id == message.ChatId);
            // TODO изменение данных в чате требует изменения в одном месте а не двух
            chatView.ChatData.LastMessage = message.Text;
            chatView.ChatData.LastMessageTime = message.Timestamp;
            chatView.ChatData.UnreadCounter++;
            chatView.UnreadCounter = chatView.ChatData.UnreadCounter;
            chatView.LastMessage = message.Text;

            _chatListPanel.Controls.SetChildIndex(chatView, 0);

            if (_selectedItem != null && _selectedItem.ChatData.Id == message.ChatId)
            {
                chatView.UnreadCounter = 0;
                _currentChatController.ReceiveMessage(message);
            }
        }

        public void SendMessage(Models.Message message)
        {
            // Обновляет модель и представление ChatListItem при ОТПРАВКЕ нового сообщения
            // Предполагается что количество непрочитанных сообщений равно нулю в текущем чате
            ChatListItem chatView = _chatListPanel.Controls
                .Cast<ChatListItem>()
                .First(c => c.ChatData.Id == message.ChatId);
            
            chatView.ChatData.LastMessage = message.Text;
            chatView.ChatData.LastMessageTime = message.Timestamp;
            chatView.LastMessage = message.Text;

            _chatListPanel.Controls.SetChildIndex(chatView, 0);
        }

        public void ReceiveChat(Chat chat)
        {
            // Получение нового чата 

            _chats.Add(chat);

            // TODO вынести в отдельную функцию
            ChatListItem chatListItem = new ChatListItem(chat);

            // Подписка на клик (выбор чата в списке чатов)
            chatListItem.Click += (s, e) => SelectChatItem(chatListItem);
            foreach (Control child in chatListItem.Controls)
            {
                child.Click += (s, e) => SelectChatItem(chatListItem);
            }
            _chatListPanel.Controls.Add(chatListItem);
        }
    }
}
