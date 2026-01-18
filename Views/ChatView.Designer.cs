namespace Zentik.Views
{
    partial class ChatView
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
            Button attachButton;
            tableLayoutPanel1 = new TableLayoutPanel();
            panelHeader = new Panel();
            headerName = new Label();
            headerAvatar = new PictureBox();
            flowMessages = new FlowLayoutPanel();
            inputPanel = new Panel();
            txtMessage = new RichTextBox();
            btnSend = new Button();
            attachButton = new Button();
            tableLayoutPanel1.SuspendLayout();
            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)headerAvatar).BeginInit();
            inputPanel.SuspendLayout();
            SuspendLayout();
            // 
            // attachButton
            // 
            attachButton.BackColor = Color.FromArgb(30, 41, 53);
            attachButton.BackgroundImage = Properties.Resources.attachButtonPic;
            attachButton.BackgroundImageLayout = ImageLayout.Zoom;
            attachButton.Dock = DockStyle.Left;
            attachButton.Location = new Point(0, 0);
            attachButton.Name = "attachButton";
            attachButton.Size = new Size(54, 54);
            attachButton.TabIndex = 0;
            attachButton.UseVisualStyleBackColor = false;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.FromArgb(30, 41, 53);
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(panelHeader, 0, 0);
            tableLayoutPanel1.Controls.Add(flowMessages, 0, 1);
            tableLayoutPanel1.Controls.Add(inputPanel, 0, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tableLayoutPanel1.Size = new Size(800, 700);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // panelHeader
            // 
            panelHeader.Controls.Add(headerName);
            panelHeader.Controls.Add(headerAvatar);
            panelHeader.Dock = DockStyle.Fill;
            panelHeader.Location = new Point(3, 3);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(794, 39);
            panelHeader.TabIndex = 0;
            // 
            // headerName
            // 
            headerName.BackColor = Color.FromArgb(28, 39, 51);
            headerName.Dock = DockStyle.Left;
            headerName.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            headerName.ForeColor = Color.White;
            headerName.Location = new Point(39, 0);
            headerName.Name = "headerName";
            headerName.Size = new Size(755, 39);
            headerName.TabIndex = 1;
            headerName.Text = "Иван Алексеевич";
            headerName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // headerAvatar
            // 
            headerAvatar.Dock = DockStyle.Left;
            headerAvatar.Location = new Point(0, 0);
            headerAvatar.Name = "headerAvatar";
            headerAvatar.Size = new Size(39, 39);
            headerAvatar.SizeMode = PictureBoxSizeMode.Zoom;
            headerAvatar.TabIndex = 0;
            headerAvatar.TabStop = false;
            // 
            // flowMessages
            // 
            flowMessages.AutoScroll = true;
            flowMessages.AutoSize = true;
            flowMessages.Dock = DockStyle.Fill;
            flowMessages.FlowDirection = FlowDirection.TopDown;
            flowMessages.Location = new Point(3, 48);
            flowMessages.MinimumSize = new Size(394, 0);
            flowMessages.Name = "flowMessages";
            flowMessages.Size = new Size(794, 589);
            flowMessages.TabIndex = 1;
            flowMessages.WrapContents = false;
            // 
            // inputPanel
            // 
            inputPanel.Controls.Add(txtMessage);
            inputPanel.Controls.Add(btnSend);
            inputPanel.Controls.Add(attachButton);
            inputPanel.Dock = DockStyle.Fill;
            inputPanel.Location = new Point(3, 643);
            inputPanel.Name = "inputPanel";
            inputPanel.Size = new Size(794, 54);
            inputPanel.TabIndex = 2;
            // 
            // txtMessage
            // 
            txtMessage.BackColor = Color.FromArgb(30, 41, 53);
            txtMessage.BorderStyle = BorderStyle.FixedSingle;
            txtMessage.Dock = DockStyle.Fill;
            txtMessage.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            txtMessage.ForeColor = Color.White;
            txtMessage.Location = new Point(54, 0);
            txtMessage.Name = "txtMessage";
            txtMessage.ScrollBars = RichTextBoxScrollBars.Vertical;
            txtMessage.Size = new Size(686, 54);
            txtMessage.TabIndex = 3;
            txtMessage.Text = "";
            // 
            // btnSend
            // 
            btnSend.BackColor = Color.FromArgb(30, 41, 53);
            btnSend.BackgroundImage = Properties.Resources.sendButtonPic;
            btnSend.BackgroundImageLayout = ImageLayout.Zoom;
            btnSend.Dock = DockStyle.Right;
            btnSend.Location = new Point(740, 0);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(54, 54);
            btnSend.TabIndex = 2;
            btnSend.UseVisualStyleBackColor = false;
            // 
            // ChatView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            Controls.Add(tableLayoutPanel1);
            MinimumSize = new Size(400, 0);
            Name = "ChatView";
            Size = new Size(800, 700);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            panelHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)headerAvatar).EndInit();
            inputPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Panel panelHeader;
        private Label headerName;
        private PictureBox headerAvatar;
        private FlowLayoutPanel flowMessages;
        private Panel inputPanel;
        private Button attachButton;
        private Button btnSend;
        private RichTextBox txtMessage;
    }
}
