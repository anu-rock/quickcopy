namespace QuickCopy
{
    partial class AddContent
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddContent));
            this.systemHotkey1 = new CodeProject.SystemHotkey.SystemHotkey(this.components);
            this.systemHotkey2 = new CodeProject.SystemHotkey.SystemHotkey(this.components);
            this.systemHotkey3 = new CodeProject.SystemHotkey.SystemHotkey(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.lblContent = new System.Windows.Forms.Label();
            this.txtContent = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.chkPassword = new System.Windows.Forms.CheckBox();
            this.txtTag = new System.Windows.Forms.TextBox();
            this.lblTag = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // systemHotkey1
            // 
            this.systemHotkey1.Shortcut = System.Windows.Forms.Shortcut.CtrlF1;
            this.systemHotkey1.Pressed += new System.EventHandler(this.systemHotkey1_Pressed);
            // 
            // systemHotkey2
            // 
            this.systemHotkey2.Shortcut = System.Windows.Forms.Shortcut.CtrlF2;
            this.systemHotkey2.Pressed += new System.EventHandler(this.systemHotkey2_Pressed);
            // 
            // systemHotkey3
            // 
            this.systemHotkey3.Shortcut = System.Windows.Forms.Shortcut.CtrlF3;
            this.systemHotkey3.Pressed += new System.EventHandler(this.systemHotkey3_Pressed);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.BalloonTipText = "Hi there! Double-click me to start. Right-click to see the menu.";
            this.notifyIcon1.BalloonTipTitle = "QuickCopy";
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "QuickCopy";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.BalloonTipClicked += new System.EventHandler(this.notifyIcon1_BalloonTipClicked);
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            this.contextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip1_ItemClicked);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // lblContent
            // 
            this.lblContent.AutoSize = true;
            this.lblContent.Location = new System.Drawing.Point(9, 13);
            this.lblContent.Name = "lblContent";
            this.lblContent.Size = new System.Drawing.Size(150, 13);
            this.lblContent.TabIndex = 5;
            this.lblContent.Text = "What are you thinking to add?";
            // 
            // txtContent
            // 
            this.txtContent.Location = new System.Drawing.Point(12, 40);
            this.txtContent.Name = "txtContent";
            this.txtContent.Size = new System.Drawing.Size(272, 20);
            this.txtContent.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(101, 93);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(95, 25);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Add It";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // chkPassword
            // 
            this.chkPassword.AutoSize = true;
            this.chkPassword.Location = new System.Drawing.Point(12, 67);
            this.chkPassword.Name = "chkPassword";
            this.chkPassword.Size = new System.Drawing.Size(107, 17);
            this.chkPassword.TabIndex = 1;
            this.chkPassword.Text = "Is is a password?";
            this.chkPassword.UseVisualStyleBackColor = true;
            this.chkPassword.CheckedChanged += new System.EventHandler(this.chkPassword_CheckedChanged);
            // 
            // txtTag
            // 
            this.txtTag.Location = new System.Drawing.Point(184, 64);
            this.txtTag.MaxLength = 50;
            this.txtTag.Name = "txtTag";
            this.txtTag.Size = new System.Drawing.Size(100, 20);
            this.txtTag.TabIndex = 2;
            this.txtTag.Visible = false;
            // 
            // lblTag
            // 
            this.lblTag.AutoSize = true;
            this.lblTag.Location = new System.Drawing.Point(146, 67);
            this.lblTag.Name = "lblTag";
            this.lblTag.Size = new System.Drawing.Size(32, 13);
            this.lblTag.TabIndex = 4;
            this.lblTag.Text = "Tag :";
            this.lblTag.Visible = false;
            // 
            // AddContent
            // 
            this.AcceptButton = this.btnAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(296, 127);
            this.Controls.Add(this.lblTag);
            this.Controls.Add(this.txtTag);
            this.Controls.Add(this.chkPassword);
            this.Controls.Add(this.txtContent);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblContent);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "AddContent";
            this.Text = "Add Content";
            this.Load += new System.EventHandler(this.AddContent_Load);
            this.Resize += new System.EventHandler(this.AddContent_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Label lblContent;
        private System.Windows.Forms.TextBox txtContent;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.CheckBox chkPassword;
        private System.Windows.Forms.TextBox txtTag;
        private System.Windows.Forms.Label lblTag;
    }
}

