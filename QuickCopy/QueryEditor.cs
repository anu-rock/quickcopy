using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;

namespace QuickCopy
{
    public partial class QueryEditor : Form
    {
        SQLiteConnection db;

        public QueryEditor(SQLiteConnection conn)
        {
            InitializeComponent();
            CenterToScreen();
            this.KeyPreview = true;
            db = conn;
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            if (txtQuery.Text.Equals(""))
            {
                MessageBox.Show("Query cannot be empty.");
                return;
            }
            else
            {
                db.Open();
                SQLiteCommand cmd = db.CreateCommand();
                cmd.CommandText = txtQuery.Text;
                try
                {
                    cmd.ExecuteNonQuery();
                    db.Close();
                    MessageBox.Show("Query executed successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Query could not be executed successfully. Only DML queries allowed.");
                    MessageBox.Show(ex.Message);
                    db.Close();
                }
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}