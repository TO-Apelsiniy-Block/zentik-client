using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Zentik.Models;
using static System.Net.WebRequestMethods;


namespace Zentik.Server
{
    internal class SseClient(string _authToken) : IDisposable
    {
        public event Action<Models.Message> OnNewMessage;
        public event Action<Chat> OnNewChat;

        private readonly HttpClient _http = new HttpClient();
        private readonly string BaseUrl = "http://193.233.16.110:80";

        private readonly int _deviceId = Random.Shared.Next(10000);

        public async Task StartAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, BaseUrl+$"/sse?deviceId={_deviceId}");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _authToken);
            request.Headers.Accept.Add(
                new MediaTypeWithQualityHeaderValue("text/event-stream"));

            var response = await _http.SendAsync(
                request,
                HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);

            var stream = await response.Content.ReadAsStreamAsync();
            using var reader = new StreamReader(stream);

            string sseEvent = "";
            string sseData = "";

            while (!reader.EndOfStream)
            {
                var line = await reader.ReadLineAsync().ConfigureAwait(false);
                if (line.StartsWith("data:"))
                {
                    sseData = line.Substring(5).Trim();
                }
                else if (line.StartsWith("event:"))
                {
                    sseEvent = line.Substring(6).Trim();
                }
                else if (line.StartsWith(":"))
                {
                   // Это комментарий, на него плюем
                }
                else if (sseEvent != "")
                {
                    if (sseEvent == "new_message")
                    {
                        JsonDocument doc = JsonDocument.Parse(sseData);
                        JsonElement root = doc.RootElement;

                        OnNewMessage.Invoke(new Models.Message(
                            root.GetProperty("sender_id").GetInt32(),
                            root.GetProperty("chat_id").GetInt32(),
                            root.GetProperty("message_text").GetString(),
                            root.GetProperty("send_time").GetDateTime()));
                    }
                    else if (sseEvent == "new_chat_pm")
                    {
                            JsonDocument doc = JsonDocument.Parse(sseData);
                            JsonElement root = doc.RootElement;

                            OnNewChat.Invoke(new Chat(
                                root.GetProperty("chat_id").GetInt32(),
                                root.GetProperty("chat_name").GetString(), 
                                root.GetProperty("last_message_text").GetString(),
                                0));
                    }
                    sseEvent = "";
                }
            }
        }

        public void Dispose()
        {
            _http.Dispose();
        }
    }
}
