using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Zentik.Models;

namespace Zentik.Views
{
    internal class MessageBubble : Panel
    {
        private Label _lblText;
        private Label _lblTime;

        // Конструктор
        public MessageBubble(Models.Message message)
        {
            // В коде
            InitializeComponent();
            SetMessage(message);
        }

        private void InitializeComponent()
        {
            // Настройка панели
            this.Padding = new Padding(10, 8, 10, 8);
            this.Margin = new Padding(5, 3, 5, 3);
            this.AutoSize = true;
            this.MaximumSize = new Size(400, 0);

            // Лейбл для текста
            _lblText = new Label
            {
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.Black,
                BackColor = Color.Transparent,
                AutoSize = true,
                MaximumSize = new Size(380, 0),
                UseMnemonic = false,
                Location = new Point(5, 5)
            };

            // Лейбл для времени
            _lblTime = new Label
            {
                Font = new Font("Segoe UI", 7, FontStyle.Italic),
                ForeColor = Color.FromArgb(100, 100, 100),
                BackColor = Color.Transparent,
                AutoSize = true
            };

            // Добавляем на панель
            this.Controls.Add(_lblText);
            this.Controls.Add(_lblTime);

            // Обновляем позицию времени при изменении размера текста
            _lblText.SizeChanged += (s, e) => UpdateTimePosition();
        }

        // Главный метод - установка данных из модели
        public void SetMessage(Models.Message message)
        {
            if (message == null) return;

            // Устанавливаем текст
            _lblText.Text = message.Text ?? string.Empty;

            // Устанавливаем время (уже отформатированное в модели)
            _lblTime.Text = message.FormattedTime;

            // Настраиваем внешний вид
            UpdateAppearance(message.IsMyMessage);

            // Обновляем расположение
            UpdateLayout();
        }

        private void UpdateAppearance(bool isMyMessage)
        {
            // Цвет фона
            this.BackColor = isMyMessage
                ? Color.FromArgb(220, 248, 198)  // Своё
                : Color.White;                   // Чужое

            // Выравнивание
            if (isMyMessage)
            {
                this.Dock = DockStyle.Right;
                this.Margin = new Padding(0, 3, 10, 3); // Отступ справа 10px
            }
            else
            {
                this.Dock = DockStyle.Left;
                this.Margin = new Padding(10, 3, 0, 3); // Отступ слева 10px
            }
        }

        public void UpdateTimePosition()
        {
            // Позиционируем время под текстом
            _lblTime.Location = new Point(5, _lblText.Bottom + 3);

            // Для своих сообщений время справа
            if (this.Anchor == AnchorStyles.Right)
            {
                _lblTime.Left = this.Width - _lblTime.Width - 10;
            }
        }

        private void UpdateLayout()
        {
            UpdateTimePosition();

            // Пересчитываем высоту
            int bottom = Math.Max(_lblText.Bottom, _lblTime.Bottom);
            this.Height = bottom + 10; // + нижний отступ
        }
    }
}
