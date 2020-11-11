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
    public partial class Employee : Form
    {
        public Employee()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cs = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:/Users/Satish/Documents/db_EMS.accdb";
            OleDbConnection con = new OleDbConnection(cs);
            con.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into tbl_EmpDetails values("+empid.Text+",'"+name.Text+"','"+contact.Text+"',"+deg.Text+","+report.Text+")";
            cmd.ExecuteNonQuery();
            MessageBox.Show("Inserted succecfully");
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            empid.Text = "";
            name.Text = "";
            contact.Text = "";
            deg.Text = "";
            report.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string cs = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:/Users/Satish/Documents/db_EMS.accdb";
            OleDbConnection con = new OleDbConnection(cs);
            con.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = con;
            cmd.CommandText = "Delete from tbl_EmpDetails where id=" +empid.Text;
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
            cmd.CommandText = "Update tbl_EmpDetails set Name='"+name.Text+"',ContactNumber="+contact.Text+",DesignationId="+deg.Text+",ReportinTo="+report.Text+" where id="+empid.Text;
            cmd.ExecuteNonQuery();
            MessageBox.Show("Updated succecfully");
            con.Close();
        }
    }
}
