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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Zentik
{
    internal partial class RegistrationForm : Form
    {
        private RestClient _restClient;
        public string Token { get; set; }

        public RegistrationForm(RestClient restClient)
        {
            InitializeComponent();
            _restClient = restClient;
        }

        private async void SendVerCodeButton_Click(object sender, EventArgs e)
        {
            await _restClient.SendVerificationCodeAsync(EmailTextBox.Text);
            MessageBox.Show("Это ты");

        }

        private void ToAuthForm_Click(object sender, EventArgs e)
        {
            this.Hide();

            using (var loginForm = new LoginForm(_restClient))
            {
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    // Получаем токен из формы авторизации
                    Token = loginForm.Token;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    this.Show();
                }
            }
        }

        private async void RegistrationButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(UsernameTextBox.Text) ||
                string.IsNullOrWhiteSpace(EmailTextBox.Text) ||
                string.IsNullOrWhiteSpace(PasswordTextBox.Text) ||
                string.IsNullOrWhiteSpace(VerCodeTextBox.Text))
            {
                MessageBox.Show("Заполните все поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Token = await _restClient.RegisterAsync(UsernameTextBox.Text, EmailTextBox.Text, VerCodeTextBox.Text, PasswordTextBox.Text);
            }
            catch (WrongEmailVerificationException)
            {
                MessageBox.Show("Неверный код подтверждения", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (EmailIsAlreadyTakenException)
            {
                MessageBox.Show("Данный адрес электронной почты уже занят", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
