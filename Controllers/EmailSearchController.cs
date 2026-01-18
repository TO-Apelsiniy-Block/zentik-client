using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zentik.Exceptions;
using Zentik.Models;
using Zentik.Server;
using Zentik.Views;

namespace Zentik.Controllers
{
    internal class EmailSearchController
    {
        private readonly EmailSearchView _emailSearchView;
        private readonly RestClient _restClient;
        private readonly ChatsManager _chatsManager;

        public EmailSearchController(EmailSearchView emailSearchView, RestClient restClient, ChatsManager chatsManager)
        {
            _emailSearchView = emailSearchView;
            _restClient = restClient;
            _chatsManager = chatsManager;
            _emailSearchView.EmailSearching += SearchUserByEmail;
        }

        public async void SearchUserByEmail(object sender, string email)
        {
            Models.User user;
            try
            {
                user = await _restClient.GetUserByEmailAsync(email);
            }
            catch (NotFoundException)
            {
                MessageBox.Show("Пользователь не найден");
                return;
            }

            _emailSearchView.Clear();
            try
            {
                var chat = await _restClient.CreateChatAsync(user.UserId);
                _chatsManager.CreateChat(chat);
                _chatsManager.SelectChatByChatId(chat.Id);
            }
            catch (AlreadyExistsException)
            {
                _chatsManager.SelectChatByChatId(await _restClient.GetChatIdAsync(user.UserId));
            }
        }
    }
}
