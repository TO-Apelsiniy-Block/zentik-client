using System.Windows.Forms;
using Zentik.Controllers;
using Zentik.Models;
using Zentik.Views;

namespace Zentik
{
    public partial class MainWindow : Form
    {
        private ChatsManager _chatsManager;     // контроллер списка чатов
        private ChatController _currentChatController;  // контроллер чата

        public MainWindow()
        {
            InitializeComponent();
            InitializeControllers();

            // Ќа минимум втора€ панель не нужна
            // „тобы не мен€ть структуру отключена
            currentChatAndInfo.Panel2.BackColor = Color.Red;
            currentChatAndInfo.Panel2Collapsed = true;
        }

        private void InitializeControllers()
        {
            _chatsManager = new ChatsManager(flowLayoutPanelChats, currentChatAndInfo.Panel1);
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void currentChatAndInfo_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
