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

        private SynchronizationContext _ui;

        internal MainWindow(string token, RestClient restClient)
        {
            InitializeComponent();
            InitializeControllers(restClient, token);

            // На минимум вторая панель не нужна
            // Чтобы не менять структуру отключена
            currentChatAndInfo.Panel2Collapsed = true;

        }

        private void InitializeControllers(RestClient restClient, string token)
        {
            _sseClient = new SseClient(token);
            _restClient = restClient;
            _chatsManager = ChatsManager.Create(
                flowLayoutPanelChats,
                currentChatAndInfo.Panel1,
                _restClient);

            // _sseClient.OnNewMessage += _chatsManager.ReceiveMessage;
            // _sseClient.OnNewChat += _chatsManager.CreateChat;
            // Иначе проблема с тем, что объекты создаются не в UI потоке
            _ui = SynchronizationContext.Current;
            _sseClient.OnNewMessage += message =>
            {
                _ui.Post(_ =>
                {
                    _chatsManager.ReceiveMessage(message);
                }, null);
            };
            _sseClient.OnNewChat += chat =>
            {
                _ui.Post(_ =>
                {
                    _chatsManager.CreateChat(chat);
                }, null);
            };

            _emailSearchController = new EmailSearchController(new EmailSearchView(emailSearchTextBox), _restClient, _chatsManager);

            _ = _sseClient.StartAsync();
        }

        private void LogoutButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Выйти из аккаунта?", "Выход", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    File.Delete("AuthToken.txt");

                    Application.Restart();
                }
                catch
                {
                    MessageBox.Show("Ошибка при выходе", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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

        private void UnloginAndSearch_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
