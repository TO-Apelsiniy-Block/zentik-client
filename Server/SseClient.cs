using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Zentik.Models;
using static System.Net.WebRequestMethods;

namespace Zentik.Server
{
    internal class SseClient
    {
        public event EventHandler<Models.Message> OnNewMessage;
        public event EventHandler<Chat> OnNewChat;

        private readonly HttpClient _http = new HttpClient();
        private CancellationTokenSource _cts;

        public async Task StartAsync()
        {
            _cts = new CancellationTokenSource();

            int a, b;
            while (!_cts.Token.IsCancellationRequested)
            {
                // await Task.Delay(1000000000);
                a = Random.Shared.Next(1, 4);
                b = Random.Shared.Next(100, 1000000);
                Console.WriteLine($"Начали ждать {a} {b}");
                await Task.Delay(2000);
                Console.WriteLine("Начали новое сообщение");
                try
                {
                    OnNewMessage.Invoke(this, new Models.Message(a, a, $"Random Message {a} {b}", DateTime.Now));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                Console.WriteLine("Закончили новое сообщение");
                await Task.Delay(2000);
                Console.WriteLine("Начали новый чат");
                OnNewChat.Invoke(this, new Chat(b, $"Random Chat {b}", "qwe", 0));
                Console.WriteLine("Прололжили новой чат");
                OnNewMessage.Invoke(this, new Models.Message(b, b, "qwe", DateTime.Now));
                Console.WriteLine("Закончили новой чат");
            }
        }
    }
}
