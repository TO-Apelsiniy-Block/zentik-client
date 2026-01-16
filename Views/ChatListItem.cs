using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Zentik.Models
{
    internal partial class ChatListItem : UserControl
    {
        private bool _isSelected;
        public Chat ChatData { get; set; }
        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                _isSelected = value;
                BackColor = value ? Color.FromArgb(27, 49, 73) : Color.FromArgb(30, 41, 53);
            }
        }
        public int UnreadCounter 
        {
            set
            {
                this.unreadСounter.Visible = true;
                if (value == 0)
                    this.unreadСounter.Visible = false;
                else if (value > 99)

                    this.unreadСounter.Text = "♾️"; // ∞
                else
                    this.unreadСounter.Text = Convert.ToString(ChatData.UnreadCounter);
            }
        }
        public string LastMessage
        {
            set
            {
                massage.Text = value;
            }
        }

        // Основной конструктор
        public ChatListItem(Chat chat)
        {
            InitializeComponent();
            this.ChatData = chat; // сохраняем ссылку, на какой чат ссылается этот UI
            this.Name = chat.Id.ToString();
            this.name.Text = chat.ContactName;
            this.avatar.Image = chat.Avatar;
            LastMessage = chat.LastMessage;
            UnreadCounter = chat.UnreadCounter;
        }

        private void ChatListItem_Load(object sender, EventArgs e)
        {

        }
    }
}
