namespace Zentik
{
    partial class RegistrationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistrationForm));
            label1 = new Label();
            EmailTextBox = new TextBox();
            SendVerCodeButton = new Button();
            label2 = new Label();
            VerCodeTextBox = new TextBox();
            PasswordTextBox = new TextBox();
            label3 = new Label();
            RegistrationButton = new Button();
            ToAuthForm = new Button();
            UsernameTextBox = new TextBox();
            label4 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(125, 146);
            label1.Name = "label1";
            label1.Size = new Size(39, 17);
            label1.TabIndex = 0;
            label1.Text = "Email";
            // 
            // EmailTextBox
            // 
            EmailTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            EmailTextBox.Location = new Point(125, 114);
            EmailTextBox.MaxLength = 63;
            EmailTextBox.Name = "EmailTextBox";
            EmailTextBox.Size = new Size(245, 29);
            EmailTextBox.TabIndex = 1;
            // 
            // SendVerCodeButton
            // 
            SendVerCodeButton.BackColor = Color.FromArgb(152, 183, 220);
            SendVerCodeButton.FlatAppearance.BorderSize = 0;
            SendVerCodeButton.FlatStyle = FlatStyle.Flat;
            SendVerCodeButton.Location = new Point(376, 110);
            SendVerCodeButton.Name = "SendVerCodeButton";
            SendVerCodeButton.Size = new Size(102, 39);
            SendVerCodeButton.TabIndex = 2;
            SendVerCodeButton.Text = "Отправить код подтверждения";
            SendVerCodeButton.UseVisualStyleBackColor = false;
            SendVerCodeButton.Click += SendVerCodeButton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label2.Location = new Point(125, 207);
            label2.Name = "label2";
            label2.Size = new Size(128, 17);
            label2.TabIndex = 3;
            label2.Text = "Код подтверждения";
            // 
            // VerCodeTextBox
            // 
            VerCodeTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            VerCodeTextBox.Location = new Point(125, 175);
            VerCodeTextBox.MaxLength = 20;
            VerCodeTextBox.Name = "VerCodeTextBox";
            VerCodeTextBox.Size = new Size(353, 29);
            VerCodeTextBox.TabIndex = 4;
            // 
            // PasswordTextBox
            // 
            PasswordTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            PasswordTextBox.Location = new Point(125, 238);
            PasswordTextBox.MaxLength = 63;
            PasswordTextBox.Name = "PasswordTextBox";
            PasswordTextBox.Size = new Size(353, 29);
            PasswordTextBox.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label3.Location = new Point(125, 270);
            label3.Name = "label3";
            label3.Size = new Size(54, 17);
            label3.TabIndex = 6;
            label3.Text = "Пароль";
            // 
            // RegistrationButton
            // 
            RegistrationButton.AutoSize = true;
            RegistrationButton.BackColor = Color.FromArgb(160, 190, 220);
            RegistrationButton.FlatAppearance.BorderSize = 0;
            RegistrationButton.FlatStyle = FlatStyle.Flat;
            RegistrationButton.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            RegistrationButton.Location = new Point(185, 317);
            RegistrationButton.Name = "RegistrationButton";
            RegistrationButton.Size = new Size(218, 41);
            RegistrationButton.TabIndex = 7;
            RegistrationButton.Text = "Зарегистрироваться";
            RegistrationButton.UseVisualStyleBackColor = false;
            RegistrationButton.Click += RegistrationButton_Click;
            // 
            // ToAuthForm
            // 
            ToAuthForm.AutoSize = true;
            ToAuthForm.BackColor = Color.FromArgb(100, 130, 155);
            ToAuthForm.FlatAppearance.BorderSize = 0;
            ToAuthForm.FlatStyle = FlatStyle.Flat;
            ToAuthForm.Font = new Font("Segoe UI", 9F, FontStyle.Underline, GraphicsUnit.Point, 204);
            ToAuthForm.Location = new Point(220, 391);
            ToAuthForm.Name = "ToAuthForm";
            ToAuthForm.Size = new Size(152, 27);
            ToAuthForm.TabIndex = 8;
            ToAuthForm.Text = "У меня уже есть аккаунт";
            ToAuthForm.UseVisualStyleBackColor = false;
            ToAuthForm.Click += ToAuthForm_Click;
            // 
            // UsernameTextBox
            // 
            UsernameTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            UsernameTextBox.Location = new Point(125, 54);
            UsernameTextBox.MaxLength = 63;
            UsernameTextBox.Name = "UsernameTextBox";
            UsernameTextBox.Size = new Size(353, 29);
            UsernameTextBox.TabIndex = 9;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label4.Location = new Point(125, 86);
            label4.Name = "label4";
            label4.Size = new Size(34, 17);
            label4.TabIndex = 10;
            label4.Text = "Имя";
            // 
            // RegistrationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(100, 130, 155);
            ClientSize = new Size(599, 451);
            Controls.Add(label4);
            Controls.Add(UsernameTextBox);
            Controls.Add(ToAuthForm);
            Controls.Add(RegistrationButton);
            Controls.Add(label3);
            Controls.Add(PasswordTextBox);
            Controls.Add(VerCodeTextBox);
            Controls.Add(label2);
            Controls.Add(SendVerCodeButton);
            Controls.Add(EmailTextBox);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(615, 490);
            MinimizeBox = false;
            MinimumSize = new Size(615, 490);
            Name = "RegistrationForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Регистрация";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox EmailTextBox;
        private Button SendVerCodeButton;
        private Label label2;
        private TextBox VerCodeTextBox;
        private TextBox PasswordTextBox;
        private Label label3;
        private Button RegistrationButton;
        private Button ToAuthForm;
        private TextBox UsernameTextBox;
        private Label label4;
    }
}