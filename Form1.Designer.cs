namespace Zentik
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            chatsListAndСurrentChat = new SplitContainer();
            flowLayoutPanelChats = new FlowLayoutPanel();
            UnloginAndSearch = new Panel();
            LogoutButton = new Button();
            emailSearchLabel = new Label();
            emailSearchTextBox = new TextBox();
            currentChatAndInfo = new SplitContainer();
            ((System.ComponentModel.ISupportInitialize)chatsListAndСurrentChat).BeginInit();
            chatsListAndСurrentChat.Panel1.SuspendLayout();
            chatsListAndСurrentChat.Panel2.SuspendLayout();
            chatsListAndСurrentChat.SuspendLayout();
            UnloginAndSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)currentChatAndInfo).BeginInit();
            currentChatAndInfo.SuspendLayout();
            SuspendLayout();
            // 
            // chatsListAndСurrentChat
            // 
            chatsListAndСurrentChat.BackColor = Color.FromArgb(30, 41, 53);
            chatsListAndСurrentChat.BorderStyle = BorderStyle.FixedSingle;
            chatsListAndСurrentChat.Dock = DockStyle.Fill;
            chatsListAndСurrentChat.FixedPanel = FixedPanel.Panel1;
            chatsListAndСurrentChat.IsSplitterFixed = true;
            chatsListAndСurrentChat.Location = new Point(0, 0);
            chatsListAndСurrentChat.Name = "chatsListAndСurrentChat";
            // 
            // chatsListAndСurrentChat.Panel1
            // 
            chatsListAndСurrentChat.Panel1.Controls.Add(flowLayoutPanelChats);
            chatsListAndСurrentChat.Panel1.Controls.Add(UnloginAndSearch);
            // 
            // chatsListAndСurrentChat.Panel2
            // 
            chatsListAndСurrentChat.Panel2.BackColor = Color.FromArgb(30, 41, 53);
            chatsListAndСurrentChat.Panel2.Controls.Add(currentChatAndInfo);
            chatsListAndСurrentChat.Size = new Size(1184, 711);
            chatsListAndСurrentChat.SplitterDistance = 280;
            chatsListAndСurrentChat.SplitterWidth = 1;
            chatsListAndСurrentChat.TabIndex = 0;
            chatsListAndСurrentChat.SplitterMoved += splitContainer1_SplitterMoved;
            // 
            // flowLayoutPanelChats
            // 
            flowLayoutPanelChats.AutoScroll = true;
            flowLayoutPanelChats.Dock = DockStyle.Fill;
            flowLayoutPanelChats.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanelChats.Location = new Point(0, 56);
            flowLayoutPanelChats.Name = "flowLayoutPanelChats";
            flowLayoutPanelChats.Size = new Size(278, 653);
            flowLayoutPanelChats.TabIndex = 12;
            flowLayoutPanelChats.WrapContents = false;
            // 
            // UnloginAndSearch
            // 
            UnloginAndSearch.Controls.Add(LogoutButton);
            UnloginAndSearch.Controls.Add(emailSearchLabel);
            UnloginAndSearch.Controls.Add(emailSearchTextBox);
            UnloginAndSearch.Dock = DockStyle.Top;
            UnloginAndSearch.Location = new Point(0, 0);
            UnloginAndSearch.Name = "UnloginAndSearch";
            UnloginAndSearch.Size = new Size(278, 56);
            UnloginAndSearch.TabIndex = 11;
            // 
            // LogoutButton
            // 
            LogoutButton.BackColor = Color.FromArgb(30, 41, 53);
            LogoutButton.BackgroundImage = Properties.Resources.UnLoginBtnPic;
            LogoutButton.BackgroundImageLayout = ImageLayout.Zoom;
            LogoutButton.FlatAppearance.BorderSize = 0;
            LogoutButton.FlatStyle = FlatStyle.Flat;
            LogoutButton.Location = new Point(3, 3);
            LogoutButton.Name = "LogoutButton";
            LogoutButton.Size = new Size(52, 52);
            LogoutButton.TabIndex = 11;
            LogoutButton.UseVisualStyleBackColor = false;
            LogoutButton.Click += LogoutButton_Click;
            // 
            // emailSearchLabel
            // 
            emailSearchLabel.Font = new Font("Segoe UI", 10F);
            emailSearchLabel.ForeColor = Color.White;
            emailSearchLabel.Location = new Point(61, 3);
            emailSearchLabel.Margin = new Padding(3);
            emailSearchLabel.Name = "emailSearchLabel";
            emailSearchLabel.Size = new Size(214, 21);
            emailSearchLabel.TabIndex = 10;
            emailSearchLabel.Text = "Поиск пользователя по email";
            // 
            // emailSearchTextBox
            // 
            emailSearchTextBox.BackColor = Color.FromArgb(30, 41, 53);
            emailSearchTextBox.BorderStyle = BorderStyle.FixedSingle;
            emailSearchTextBox.Font = new Font("Segoe UI", 10F);
            emailSearchTextBox.ForeColor = Color.White;
            emailSearchTextBox.Location = new Point(61, 27);
            emailSearchTextBox.Name = "emailSearchTextBox";
            emailSearchTextBox.Size = new Size(214, 25);
            emailSearchTextBox.TabIndex = 9;
            // 
            // currentChatAndInfo
            // 
            currentChatAndInfo.Dock = DockStyle.Fill;
            currentChatAndInfo.FixedPanel = FixedPanel.Panel2;
            currentChatAndInfo.IsSplitterFixed = true;
            currentChatAndInfo.Location = new Point(0, 0);
            currentChatAndInfo.Name = "currentChatAndInfo";
            // 
            // currentChatAndInfo.Panel2
            // 
            currentChatAndInfo.Panel2.Paint += currentChatAndInfo_Panel2_Paint;
            currentChatAndInfo.Size = new Size(901, 709);
            currentChatAndInfo.SplitterDistance = 875;
            currentChatAndInfo.SplitterWidth = 1;
            currentChatAndInfo.TabIndex = 0;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 41, 53);
            ClientSize = new Size(1184, 711);
            Controls.Add(chatsListAndСurrentChat);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(750, 400);
            Name = "MainWindow";
            Text = "Zentik";
            chatsListAndСurrentChat.Panel1.ResumeLayout(false);
            chatsListAndСurrentChat.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)chatsListAndСurrentChat).EndInit();
            chatsListAndСurrentChat.ResumeLayout(false);
            UnloginAndSearch.ResumeLayout(false);
            UnloginAndSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)currentChatAndInfo).EndInit();
            currentChatAndInfo.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer chatsListAndСurrentChat;
        private SplitContainer currentChatAndInfo;
        private Panel UnloginAndSearch;
        private Label emailSearchLabel;
        private TextBox emailSearchTextBox;
        private FlowLayoutPanel flowLayoutPanelChats;
        private Button LogoutButton;
    }
}
