using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                if (value == 0)
                    this.unreadСounter.Visible = false;
                else if (value > 99)
                    this.unreadСounter.Text = "♾️"; // ∞
                else
                    this.unreadСounter.Text = Convert.ToString(ChatData.UnreadCounter);
            }
        }

        public event EventHandler<string> NewMessage;
        public event EventHandler<string> ;


        // Основной конструктор
        public ChatListItem(Chat chat)
        {
            InitializeComponent();
            this.ChatData = chat; // сохраняем ссылку, на какой чат ссылается этот UI

            this.name.Text = chat.ContactName;
            this.massage.Text = chat.LastMessage;
            this.avatar.Image = chat.Avatar;
            UnreadCounter = chat.UnreadCounter;
            
        }

        private void ChatListItem_Load(object sender, EventArgs e)
        {

        }
    }
}
