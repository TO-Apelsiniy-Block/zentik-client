using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zentik.Models;

namespace Zentik.Views
{
    public partial class ChatView : UserControl
    {
        // Событие для уведомления контроллера
        public event EventHandler<string> MessageSent;

        public ChatView()
        {
            InitializeComponent();

            btnSend.Click += (s, e) => OnSendMessage();
            txtMessage.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter && !e.Control)
                {
                    e.SuppressKeyPress = true;
                    OnSendMessage();
                }
            };

            // чтобы обозначить flowMessages границы для нормального выравнивания
            flowMessages.Controls.Add(new Panel()
            {
                Width = flowMessages.ClientSize.Width,
                Height = 0
            }); 
            
            // ресайз при изменении размеров окна
            flowMessages.SizeChanged += (s, e) =>
            {
                flowMessages.Controls[0].Width = flowMessages.ClientSize.Width;
            };
            Console.WriteLine(flowMessages.MaximumSize);
        }

        internal void DisplayMessage(Models.Message message)
        {
            var bubble = new MessageBubble(message);
            flowMessages.Controls.Add(bubble);
            flowMessages.ScrollControlIntoView(bubble);
            Console.WriteLine(flowMessages.Width);
            Console.WriteLine(flowMessages.Controls[0].Width);
        }

        // Очистка чата
        public void ClearMessages()
        {
            flowMessages.Controls.Clear();
            // чтобы обозначить flowMessages границы для нормального выравнивания
            flowMessages.Controls.Add(new Panel()
            {
                Width = flowMessages.ClientSize.Width,
                Height = 0
            });
        }

        // Установка информации о чате
        public void SetChatInfo(string contactName, Image avatar)
        {
            if (headerName != null)
                headerName.Text = contactName;
            if (headerAvatar != null)
                headerAvatar.Image = avatar;
        }

        // Приватный метод для уведомления контроллера
        private void OnSendMessage()
        {
            string text = txtMessage.Text.Trim();
            if (!string.IsNullOrEmpty(text))
            {
                MessageSent?.Invoke(this, text);
                txtMessage.Clear();
            }
        }
    }
}
