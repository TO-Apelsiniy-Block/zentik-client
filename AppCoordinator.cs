using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zentik.Server;

namespace Zentik
{
    internal class AppCoordinator
    {
        private const string TOKEN_FILE = "AuthToken.txt";
        private string _authToken;
        private RestClient _restClient = new("");

        public void Start()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (HasValidToken())
            {
                _authToken = File.ReadAllText(TOKEN_FILE);
                StartMainForm();
            }
            else
            {
                ShowRegistrationForm();
            }
        }

        private bool HasValidToken()
        {
            try
            {
                return File.Exists(TOKEN_FILE) && !string.IsNullOrWhiteSpace(File.ReadAllText(TOKEN_FILE));
            }
            catch
            {
                return false;
            }
        }

        private void SaveToken(string token)
        {
            try
            {
                _authToken = token;
                File.WriteAllText(TOKEN_FILE, token);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения токена: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void StartMainForm()
        {
            _restClient = new RestClient(_authToken);
            var mainForm = new MainWindow(_authToken, _restClient);
            Application.Run(mainForm);
        }

        private void ShowRegistrationForm()
        {
            using (var registerForm = new RegistrationForm(_restClient))
            {
                if (registerForm.ShowDialog() == DialogResult.OK)
                {
                    SaveToken(registerForm.Token);
                    StartMainForm();
                }
                else
                {
                    Application.Exit();
                }
            }
        }
    }
}
