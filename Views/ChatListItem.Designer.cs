namespace Zentik.Models
{
    partial class ChatListItem
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChatListItem));
            avatar = new PictureBox();
            name = new Label();
            massage = new Label();
            unreadСounter = new Label();
            ((System.ComponentModel.ISupportInitialize)avatar).BeginInit();
            SuspendLayout();
            // 
            // avatar
            // 
            avatar.Location = new Point(0, 0);
            avatar.Name = "avatar";
            avatar.Size = new Size(70, 70);
            avatar.SizeMode = PictureBoxSizeMode.CenterImage;
            avatar.TabIndex = 0;
            avatar.TabStop = false;
            // 
            // name
            // 
            name.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            name.ForeColor = Color.White;
            name.Location = new Point(74, 12);
            name.Name = "name";
            name.Size = new Size(178, 23);
            name.TabIndex = 1;
            // 
            // massage
            // 
            massage.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            massage.ForeColor = Color.White;
            massage.Location = new Point(74, 40);
            massage.Name = "massage";
            massage.Size = new Size(135, 23);
            massage.TabIndex = 2;
            // 
            // unreadСounter
            // 
            unreadСounter.Font = new Font("Segoe UI", 9.75F, FontStyle.Italic, GraphicsUnit.Point, 204);
            unreadСounter.ForeColor = Color.White;
            unreadСounter.Image = (Image)resources.GetObject("unreadСounter.Image");
            unreadСounter.Location = new Point(225, 40);
            unreadСounter.Name = "unreadСounter";
            unreadСounter.Size = new Size(23, 23);
            unreadСounter.TabIndex = 3;
            unreadСounter.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ChatListItem
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 41, 53);
            Controls.Add(unreadСounter);
            Controls.Add(massage);
            Controls.Add(name);
            Controls.Add(avatar);
            Cursor = Cursors.Hand;
            Name = "ChatListItem";
            Size = new Size(255, 70);
            Load += ChatListItem_Load;
            ((System.ComponentModel.ISupportInitialize)avatar).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox avatar;
        private Label name;
        private Label massage;
        private Label unreadСounter;
    }
}
