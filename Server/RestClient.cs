using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zentik.Exceptions;
using Zentik.Models;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Zentik.Server
{
    internal class RestClient (string _authToken)
    {
        private readonly HttpClient _http = new HttpClient();
        private readonly string _baseUrl = "http://193.233.16.110:80";

        private readonly int _deviceId = Random.Shared.Next(10000);

        public async Task<Models.Message> CreateMessageAsync(string text, int chatId)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, _baseUrl + "/message");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _authToken);
            request.Content = JsonContent.Create(new { text = text, chat_id = chatId });
            var response = await _http.SendAsync(request);
            return new Models.Message(-1, chatId, text, DateTime.Now);
        }

        public async Task<List<Models.Message>> GetMessagesAsync(int chatId)
        {
            try
            { 
            var request = new HttpRequestMessage(HttpMethod.Get, _baseUrl + $"/message/{chatId}");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _authToken);
            var response = await _http.SendAsync(request).ConfigureAwait(false);

            JsonDocument doc = JsonDocument.Parse(await response.Content.ReadAsStringAsync().ConfigureAwait(false));
            JsonElement root = doc.RootElement;
            var userId = root.GetProperty("user_id").GetInt32();
            return root.GetProperty("messages")
                .EnumerateArray().ToList()
                .ConvertAll<Models.Message>(m => new (
                    m.GetProperty("sender_id").GetInt32() == userId ? -1 : m.GetProperty("sender_id").GetInt32(),
                    chatId,
                    m.GetProperty("text").GetString(),
                    m.GetProperty("send_time").GetDateTime()));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task<List<Chat>> GetChatsAsync()
        {
            try
            { 
            var request = new HttpRequestMessage(HttpMethod.Get, _baseUrl + $"/chat/my");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _authToken);
            var response = await _http.SendAsync(request).ConfigureAwait(false);
            JsonDocument doc = JsonDocument.Parse(await response.Content.ReadAsStringAsync().ConfigureAwait(false));
            JsonElement root = doc.RootElement;

            return root.GetProperty("chats")
                .EnumerateArray().ToList()
                .ConvertAll<Models.Chat>(m => new(
                    m.GetProperty("chat_id").GetInt32(),
                    m.GetProperty("name").GetString(),
                    m.GetProperty("last_message_text").GetString(),
                    0));
                }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        
        public async Task<User> GetUserByEmailAsync(string email)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, _baseUrl + $"/user/{email}");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _authToken);
            var response = await _http.SendAsync(request).ConfigureAwait(false);

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                throw new NotFoundException();
            }

            JsonDocument doc = JsonDocument.Parse(await response.Content.ReadAsStringAsync().ConfigureAwait(false));
            JsonElement root = doc.RootElement;
            return new User() { Email = email, UserId = root.GetProperty("user_id").GetInt32(), Username = root.GetProperty("username").GetString() };
        }

        public async Task<Chat> CreateChatAsync(int userId)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, _baseUrl + $"/chat/pm");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _authToken);
            request.Content = JsonContent.Create(new { second_user_id = userId });
            var response = await _http.SendAsync(request).ConfigureAwait(false);

            if (response.StatusCode == System.Net.HttpStatusCode.Conflict)
            {
                throw new AlreadyExistsException();
            }
            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                throw new SelfChatException();
            }

            JsonDocument doc = JsonDocument.Parse(await response.Content.ReadAsStringAsync().ConfigureAwait(false));
            JsonElement root = doc.RootElement;
            return new Chat(root.GetProperty("chat_id").GetInt32(), root.GetProperty("chat_name").GetString(), "Новый чат", 0);
        }
        public async Task<int> GetChatIdAsync(int userId)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, _baseUrl + $"/chat/pm/qwe");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _authToken);
            request.Content = JsonContent.Create(new { second_user_id = userId });
            var response = await _http.SendAsync(request).ConfigureAwait(false);

            JsonDocument doc = JsonDocument.Parse(await response.Content.ReadAsStringAsync().ConfigureAwait(false));
            JsonElement root = doc.RootElement;
            return root.GetProperty("chat_id").GetInt32();
        }

        public async Task SendVerificationCodeAsync(string email)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, _baseUrl + $"/auth/email_confirmation");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _authToken);
            request.Content = JsonContent.Create(new { email = email, device_id = _deviceId });
            var response = await _http.SendAsync(request).ConfigureAwait(false);
        }

        public async Task<string> RegisterAsync(string username, string email, string code, string password)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, _baseUrl + $"/auth/register/");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _authToken);
            request.Content = JsonContent.Create(new { email = email, username = username, email_code = code, password = password, device_id = _deviceId });
            var response = await _http.SendAsync(request).ConfigureAwait(false);

            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                throw new WrongEmailVerificationException();
            }
            if (response.StatusCode == System.Net.HttpStatusCode.Conflict)
            {
                throw new EmailIsAlreadyTakenException();
            }

            JsonDocument doc = JsonDocument.Parse(await response.Content.ReadAsStringAsync().ConfigureAwait(false));
            JsonElement root = doc.RootElement;
            return root.GetProperty("token").GetString();
        }

        public async Task<string> LoginAsync(string email, string code, string password)
        {

            var request = new HttpRequestMessage(HttpMethod.Post, _baseUrl + $"/auth/login/");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _authToken);
            request.Content = JsonContent.Create(new { email = email, email_code = code, password = password, device_id = _deviceId });
            var response = await _http.SendAsync(request).ConfigureAwait(false);

            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                throw new WrongEmailVerificationException();
            }
            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                throw new InvalidEmailOrPasswordException();
            }

            JsonDocument doc = JsonDocument.Parse(await response.Content.ReadAsStringAsync().ConfigureAwait(false));
            JsonElement root = doc.RootElement;
            return root.GetProperty("token").GetString();
        }
    }
}
