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
    public partial class DisplayProjectLeader : Form
    {
        OleDbConnection con = new OleDbConnection();

        public DisplayProjectLeader()
        {
            InitializeComponent();
            con.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:/Users/Satish/Documents/db_EMS.accdb";
        }

        private void manager_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = con;
                var query = "select * from tbl_EmpDetails where ReportingTo=(select DesignationId from tbl_EmpDetails where Name = '" + manager.Text.ToString()+ "')";
                cmd.CommandText =query;
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DisplayProjectLeader_Load(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                OleDbCommand cmd1 = new OleDbCommand();
                cmd1.Connection = con;
                cmd1.CommandText = "select Name from tbl_EmpDetails where DesignationId=(select ID from tbl_Designation where Designation='MANAGER')";
                OleDbDataReader reader = cmd1.ExecuteReader();
                while (reader.Read())
                {
                    manager.Items.Add(reader[0].ToString());
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
       
        }
    }
}
