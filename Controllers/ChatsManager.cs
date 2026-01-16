using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zentik.Models;
using Zentik.Views;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Zentik.Controllers
{
    internal class ChatsManager
    {
        private readonly List<Chat> _chats = new();         // список чатов
        private readonly FlowLayoutPanel _chatListPanel;    // панель, на которой располагаются чаты
        private ChatListItem _selectedItem;                 // выбранный (текущий) чат
        private ChatController _currentChatController;
        private Panel _chatContainer; // Контейнер для ChatView

        public ChatsManager(FlowLayoutPanel chatListPanel, Panel chatContainer)
        {
            _chatListPanel = chatListPanel;
            _chatContainer = chatContainer;
            LoadChats();
        }

        // Загрузка чатов
        private void LoadChats()
        {
            // Тестовые данные
            _chats.Add(new Chat("Саид", "Дедлайн завтра", 12));
            _chats.Add(new Chat("Саид", "Дедлайн завтра.", 99));
            _chats.Add(new Chat("Саид", "Дедлайн завтра!", 999));
            _chats.Add(new Chat("Саид", "Дедлайн завтра?", 0));
            _chats.Add(new Chat("Саид", "Дедлайн завтра!?", 0));
            _chats.Add(new Chat("Саид", "Дедлайн завтра...", 0));
            _chats.Add(new Chat("Саид", "Дедлайн завтра(", 2));
            _chats.Add(new Chat("Саид", "Дедлайн завтра)", 2));
            _chats.Add(new Chat("Саид", "Дедлайн завтра!", 200));
            _chats.Add(new Chat("Саид", "Дедлайн завтра!", 100));
            _chats.Add(new Chat("Саид", "Дедлайн завтра!", 2));
            _chats.Add(new Chat("Саид", "Дедлайн завтра!", 2));
            _chats.Add(new Chat("Саид", "Дедлайн завтра!", 2));
            _chats.Add(new Chat("Саид", "Дедлайн завтра!", 2));

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

        }

        private void OpenChat(Chat chat)
        {
            // Удаляем предыдущий чат
            if (_currentChatController != null)
            {
                _currentChatController.Dispose();
                _chatContainer.Controls.Clear();
            }

            // Создаем View
            var chatView = new ChatView();
            chatView.Dock = DockStyle.Fill;

            // Создаем Controller
            _currentChatController = new ChatController(chat, chatView, this);

            // Добавляем View в контейнер
            _chatContainer.Controls.Add(chatView);

            // Загружаем историю
            _currentChatController.LoadHistory();
        }
    }
}
