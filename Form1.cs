using System.Windows.Forms;
using Zentik.Controllers;
using Zentik.Models;
using Zentik.Server;
using Zentik.Views;

namespace Zentik
{
    public partial class MainWindow : Form
    {
        private ChatsManager _chatsManager;
        private ChatController _currentChatController;
        private EmailSearchController _emailSearchController;
        private SseClient _sseClient;
        private RestClient _restClient;

        public MainWindow()
        {
            InitializeComponent();
            InitializeControllers();

            var qwe = chatsListAndСurrentChat.Panel1.Controls.Count;
            Console.WriteLine(qwe);
            // На минимум вторая панель не нужна
            // Чтобы не менять структуру отключена
            currentChatAndInfo.Panel2.BackColor = Color.Red;
            currentChatAndInfo.Panel2Collapsed = true;

        }

        private void InitializeControllers()
        {
            _sseClient = new SseClient();
            _restClient = new RestClient();
            _chatsManager = ChatsManager.Create(
                flowLayoutPanelChats,
                currentChatAndInfo.Panel1,
                _restClient)
                .GetAwaiter().GetResult();
            _sseClient.OnNewMessage += (s, e) => _chatsManager.ReceiveMessage(e);
            _sseClient.OnNewChat += (s, e) => _chatsManager.CreateChat(e);

            _emailSearchController = new EmailSearchController(new EmailSearchView(emailSearchTextBox), _restClient, _chatsManager);

            _ = _sseClient.StartAsync();
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

        private void flowLayoutPanelChats_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
