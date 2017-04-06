using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
using CPSystemHotkey;

namespace QuickCopy
{
    public partial class AddContent : Form
    {
        private SQLiteConnection db;
        private Dictionary<string, string> dictTagContent = new Dictionary<string, string>();
        // Adding hotkeys support for top 3 entries in the menu
        private CodeProject.SystemHotkey.SystemHotkey systemHotkey1;
        private CodeProject.SystemHotkey.SystemHotkey systemHotkey2;
        private CodeProject.SystemHotkey.SystemHotkey systemHotkey3;

        public AddContent()
        {
            InitializeComponent();
            CenterToScreen();
            this.KeyPreview = true;
            //SQLiteConnection.CreateFile("content.sqlite");
            SQLiteConnectionStringBuilder csb = new SQLiteConnectionStringBuilder();
            csb.DataSource = "content.sqlite";
            db = new SQLiteConnection(csb.ConnectionString);
            //db.Open();
            //SQLiteCommand cmd = db.CreateCommand();
            //cmd.CommandText = "CREATE TABLE Content(content_id integer primary key autoincrement, content longtext, content_tag varchar(50), is_password int)";
            //cmd.ExecuteNonQuery();
            //db.Close();
        }

        private void AddContent_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == WindowState)
                Hide();
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void notifyIcon1_BalloonTipClicked(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtContent.Text.Equals(""))
            {
                MessageBox.Show("Content field cannot be empty");
                return;
            }
            else
            {
                if (dictTagContent.ContainsValue(txtContent.Text))
                {
                    MessageBox.Show("This content already exists");
                    return;
                }
                if (chkPassword.Checked == true)
                {
                    if (txtTag.Text.Equals(""))
                    {
                        MessageBox.Show("Tag field cannot be empty");
                        return;
                    }
                }
                db.Open();
                SQLiteCommand cmd = db.CreateCommand();
                if (chkPassword.Checked == true)
                    cmd.CommandText = "INSERT INTO Content(content, content_tag, is_password) VALUES('" + txtContent.Text + "', '" + txtTag.Text + "', 1)";
                else
                    cmd.CommandText = "INSERT INTO Content(content, content_tag, is_password) VALUES('" + txtContent.Text + "', '" + txtContent.Text + "', 0)";
                cmd.ExecuteNonQuery();
                db.Close();

                PopulateContextMenu();
                txtContent.Text = "";
                txtTag.Text = "";
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            //PopulateContextMenu();
        }

        private void PopulateContextMenu()
        {
            /* Clear the context menu and tag-content dictionary */
            contextMenuStrip1.Items.Clear();
            dictTagContent.Clear();

            /* Populate the context menu */
            db.Open();
            SQLiteCommand cmd = db.CreateCommand();
            cmd.CommandText = "SELECT * FROM Content";
            SQLiteDataReader dr = default(SQLiteDataReader);
            dr = cmd.ExecuteReader();
            int i = 0;
            while (dr.Read())
            {
                dictTagContent.Add(dr.GetString(2), dr.GetString(1));
                contextMenuStrip1.Items.Add(dr.GetString(2));
                if (dr.GetInt32(3) == 1)
                    contextMenuStrip1.Items[i].ForeColor = Color.Red;
                i++;
            }
            dr.Close();
            db.Close();
            contextMenuStrip1.Items.Add(new System.Windows.Forms.ToolStripSeparator());
            //contextMenuStrip1.Items.Add("Reorganize");
            contextMenuStrip1.Items.Add("About");
            contextMenuStrip1.Items.Add("Exit");
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            Copy2Clip(e.ClickedItem);
        }

        private void Copy2Clip(ToolStripItem item)
        {
            //if (item.Text.Equals("Reorganize"))
            //{
            //    Reorganize r = new Reorganize();
            //    r.Show();
            //}
            if (item.Text.Equals("About"))
            {
                System.Reflection.Assembly asm = System.Reflection.Assembly.GetExecutingAssembly();
                notifyIcon1.ShowBalloonTip(300, "QuickCopy", "v" + asm.GetName().Version + "\n(C) 2010 Anurag Bhandari", ToolTipIcon.Info);
            }
            else if (item.Text.Equals("Exit"))
                this.Close();
            else
            {
                try
                {
                    Clipboard.SetText(dictTagContent[item.Text]);
                }
                catch (Exception ex)
                {
                    Clipboard.SetText(":-X");
                }
            }
        }

        private void AddContent_Load(object sender, EventArgs e)
        {
            //contextMenuStrip1.Items.Add(new System.Windows.Forms.ToolStripSeparator());
            ////contextMenuStrip1.Items.Add("Reorganize");
            //contextMenuStrip1.Items.Add("About");
            //contextMenuStrip1.Items.Add("Exit");
            WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
            PopulateContextMenu();
            notifyIcon1.ShowBalloonTip(300);
        }

        private void chkPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPassword.Checked == true)
            {
                lblTag.Visible = true;
                txtTag.Visible = true;
                txtContent.UseSystemPasswordChar = true;
            }
            else
            {
                lblTag.Visible = false;
                txtTag.Visible = false;
                txtContent.UseSystemPasswordChar = false;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // Hide the window
            if (keyData == Keys.Escape)
            {
                Hide();
                return true;
            }
            // Open the Query Editor
            else if (keyData == (Keys.Control | Keys.Q))
            {
                MessageBox.Show("The Query Editor is only for experts. Use it at your own discretion! Remember, you may corrupt the database.");
                QueryEditor qe = new QueryEditor(db);
                qe.Show();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void systemHotkey1_Pressed(object sender, System.EventArgs e)
        {
            Copy2Clip(contextMenuStrip1.Items[0]);
        }

        private void systemHotkey2_Pressed(object sender, System.EventArgs e)
        {
            Copy2Clip(contextMenuStrip1.Items[1]);
        }

        private void systemHotkey3_Pressed(object sender, System.EventArgs e)
        {
            Copy2Clip(contextMenuStrip1.Items[2]);
        }
    }
}