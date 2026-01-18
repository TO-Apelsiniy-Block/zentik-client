using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zentik.Exceptions;
using Zentik.Server;

namespace Zentik
{
    internal partial class LoginForm : Form
    {
        private RestClient _restClient;
        public string Token { get; set; }

        public LoginForm(RestClient restClient)
        {
            InitializeComponent();
            _restClient = restClient;
        }

        private async void SendVerCodeButton_Click(object sender, EventArgs e)
        {
            await _restClient.SendVerificationCodeAsync(EmailTextBox.Text);
        }

        private void ToRegForm_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private async void LoginButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(EmailTextBox.Text) ||
                string.IsNullOrWhiteSpace(PasswordTextBox.Text) ||
                string.IsNullOrWhiteSpace(VerCodeTextBox.Text))
            {
                MessageBox.Show("Заполните все поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Token = await _restClient.LoginAsync(EmailTextBox.Text, VerCodeTextBox.Text, PasswordTextBox.Text);
            }
            catch (WrongEmailVerificationException)
            {
                MessageBox.Show("Неверный код подтверждения", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (InvalidEmailOrPasswordException)
            {
                MessageBox.Show("Неверный email или пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
