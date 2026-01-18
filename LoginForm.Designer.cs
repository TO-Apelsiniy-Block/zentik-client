namespace Zentik
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            EmailTextBox = new TextBox();
            label1 = new Label();
            PasswordTextBox = new TextBox();
            label2 = new Label();
            ToRegForm = new Button();
            LoginButton = new Button();
            SendVerCodeButton = new Button();
            VerCodeTextBox = new TextBox();
            label3 = new Label();
            SuspendLayout();
            // 
            // EmailTextBox
            // 
            EmailTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            EmailTextBox.Location = new Point(123, 105);
            EmailTextBox.MaxLength = 63;
            EmailTextBox.Name = "EmailTextBox";
            EmailTextBox.Size = new Size(245, 29);
            EmailTextBox.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(123, 137);
            label1.Name = "label1";
            label1.Size = new Size(39, 17);
            label1.TabIndex = 2;
            label1.Text = "Email";
            // 
            // PasswordTextBox
            // 
            PasswordTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            PasswordTextBox.Location = new Point(123, 231);
            PasswordTextBox.MaxLength = 63;
            PasswordTextBox.Name = "PasswordTextBox";
            PasswordTextBox.Size = new Size(353, 29);
            PasswordTextBox.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label2.Location = new Point(123, 263);
            label2.Name = "label2";
            label2.Size = new Size(54, 17);
            label2.TabIndex = 4;
            label2.Text = "Пароль";
            // 
            // ToRegForm
            // 
            ToRegForm.AutoSize = true;
            ToRegForm.BackColor = Color.FromArgb(100, 130, 155);
            ToRegForm.FlatAppearance.BorderSize = 0;
            ToRegForm.FlatStyle = FlatStyle.Flat;
            ToRegForm.Font = new Font("Segoe UI", 9F, FontStyle.Underline, GraphicsUnit.Point, 204);
            ToRegForm.Location = new Point(220, 387);
            ToRegForm.Name = "ToRegForm";
            ToRegForm.Size = new Size(153, 27);
            ToRegForm.TabIndex = 10;
            ToRegForm.Text = "У меня ещё нет аккаунта";
            ToRegForm.UseVisualStyleBackColor = false;
            ToRegForm.Click += ToRegForm_Click;
            // 
            // LoginButton
            // 
            LoginButton.AutoSize = true;
            LoginButton.BackColor = Color.FromArgb(160, 190, 220);
            LoginButton.FlatAppearance.BorderSize = 0;
            LoginButton.FlatStyle = FlatStyle.Flat;
            LoginButton.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            LoginButton.Location = new Point(219, 313);
            LoginButton.Name = "LoginButton";
            LoginButton.Size = new Size(153, 41);
            LoginButton.TabIndex = 9;
            LoginButton.Text = "Войти";
            LoginButton.UseVisualStyleBackColor = false;
            LoginButton.Click += LoginButton_Click;
            // 
            // SendVerCodeButton
            // 
            SendVerCodeButton.BackColor = Color.FromArgb(152, 183, 220);
            SendVerCodeButton.FlatAppearance.BorderSize = 0;
            SendVerCodeButton.FlatStyle = FlatStyle.Flat;
            SendVerCodeButton.Location = new Point(374, 101);
            SendVerCodeButton.Name = "SendVerCodeButton";
            SendVerCodeButton.Size = new Size(102, 39);
            SendVerCodeButton.TabIndex = 11;
            SendVerCodeButton.Text = "Отправить код подтверждения";
            SendVerCodeButton.UseVisualStyleBackColor = false;
            SendVerCodeButton.Click += SendVerCodeButton_Click;
            // 
            // VerCodeTextBox
            // 
            VerCodeTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            VerCodeTextBox.Location = new Point(123, 167);
            VerCodeTextBox.MaxLength = 20;
            VerCodeTextBox.Name = "VerCodeTextBox";
            VerCodeTextBox.Size = new Size(353, 29);
            VerCodeTextBox.TabIndex = 13;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label3.Location = new Point(123, 199);
            label3.Name = "label3";
            label3.Size = new Size(128, 17);
            label3.TabIndex = 12;
            label3.Text = "Код подтверждения";
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(100, 130, 155);
            ClientSize = new Size(599, 451);
            Controls.Add(VerCodeTextBox);
            Controls.Add(label3);
            Controls.Add(SendVerCodeButton);
            Controls.Add(ToRegForm);
            Controls.Add(LoginButton);
            Controls.Add(PasswordTextBox);
            Controls.Add(label2);
            Controls.Add(EmailTextBox);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(615, 490);
            MinimizeBox = false;
            MinimumSize = new Size(615, 490);
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Авторизация";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox EmailTextBox;
        private Label label1;
        private TextBox PasswordTextBox;
        private Label label2;
        private Button ToRegForm;
        private Button LoginButton;
        private Button SendVerCodeButton;
        private TextBox VerCodeTextBox;
        private Label label3;
    }
}