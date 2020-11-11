using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Excercise1
{
    public partial class DesignationDetails : Form
    {
        public DesignationDetails()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cs = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:/Users/Satish/Documents/db_EMS.accdb";
            OleDbConnection con = new OleDbConnection(cs);
            con.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into tbl_Designation values("+id.Text+",'"+desig.Text+"')";
            cmd.ExecuteNonQuery();
            MessageBox.Show("Inserted succecfully");
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            id.Text = "";
            desig.Text = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Employee emp = new Employee();
            emp.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string cs = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:/Users/Satish/Documents/db_EMS.accdb";
            OleDbConnection con = new OleDbConnection(cs);
            con.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = con;
            cmd.CommandText = "Delete from tbl_Designation where id="+id.Text;
            cmd.ExecuteNonQuery();
            MessageBox.Show("Deleted succecfully");
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string cs = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:/Users/Satish/Documents/db_EMS.accdb";
            OleDbConnection con = new OleDbConnection(cs);
            con.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = con;
            cmd.CommandText = "Update tbl_Designation set Designation='"+desig.Text+"'where id=" + id.Text;
            cmd.ExecuteNonQuery();
            MessageBox.Show("Updated succecfully");
            con.Close();
        }
    }
}
