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
            currentChatAndInfo = new SplitContainer();
            ((System.ComponentModel.ISupportInitialize)chatsListAndСurrentChat).BeginInit();
            chatsListAndСurrentChat.Panel1.SuspendLayout();
            chatsListAndСurrentChat.Panel2.SuspendLayout();
            chatsListAndСurrentChat.SuspendLayout();
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
            flowLayoutPanelChats.Location = new Point(0, 0);
            flowLayoutPanelChats.Name = "flowLayoutPanelChats";
            flowLayoutPanelChats.Size = new Size(278, 709);
            flowLayoutPanelChats.TabIndex = 0;
            flowLayoutPanelChats.WrapContents = false;
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
            Name = "MainWindow";
            Text = "Zentik";
            chatsListAndСurrentChat.Panel1.ResumeLayout(false);
            chatsListAndСurrentChat.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)chatsListAndСurrentChat).EndInit();
            chatsListAndСurrentChat.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)currentChatAndInfo).EndInit();
            currentChatAndInfo.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer chatsListAndСurrentChat;
        private SplitContainer currentChatAndInfo;
        private FlowLayoutPanel flowLayoutPanelChats;
    }
}
