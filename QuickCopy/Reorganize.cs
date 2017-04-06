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
    public partial class Reorganize : Form
    {
        private SQLiteConnection db;

        public Reorganize()
        {
            InitializeComponent();
            CenterToScreen();
            this.KeyPreview = true;
            SQLiteConnectionStringBuilder csb = new SQLiteConnectionStringBuilder();
            csb.DataSource = "content.sqlite";
            db = new SQLiteConnection(csb.ConnectionString);
        }

        private void Reorganize_Load(object sender, EventArgs e)
        {
            /* Populate the grid */
            db.Open();
            SQLiteCommand cmd = db.CreateCommand();
            cmd.CommandText = "SELECT content_tag as 'Tag', content as 'Content' FROM Content";
            SQLiteDataAdapter da = new SQLiteDataAdapter();
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            db.Close();
        }
    }
}