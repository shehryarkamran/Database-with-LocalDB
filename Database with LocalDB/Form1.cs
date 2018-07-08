using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient; //sql db library

//sql database connectivity with form 

namespace Database_with_LocalDB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Visualprogramming\Database with LocalDB\Database with LocalDB\Database.mdf;Integrated Security=True");
        SqlCommand command = new SqlCommand();
        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.Columns.Add("id", "Student ID");
            dataGridView1.Columns.Add("std_name", "Student Name");
            dataGridView1.Columns.Add("department", "Student Dept");
        }
        //insert btn
        private void button1_Click(object sender, EventArgs e)
        {
            connect.Open();
            command = new SqlCommand("Insert Into Student (id, std_name, department) values  ('" +int.Parse( textBox1.Text) + "','" + textBox2.Text + "','" + textBox3.Text + "')", connect);
            command.ExecuteReader();
            MessageBox.Show("inserted ....");
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            connect.Close();
        }
        //update btn
        private void button2_Click(object sender, EventArgs e)
        {
            connect.Open();
            command = new SqlCommand("UPDATE Student set Std_Name = '" + textBox2.Text + "', Department = '" + textBox3.Text + "' where ID =" + int.Parse(textBox1.Text), connect);
            command.ExecuteReader();
            MessageBox.Show("updated ....");
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            connect.Close();
        }
        //delete btn
        private void button3_Click(object sender, EventArgs e)
        {
            connect.Open();
            command = new SqlCommand("DELETE FROM Student where (Id = '" +int.Parse( textBox1.Text) + "')", connect);
            command.ExecuteReader();
            MessageBox.Show("Deleted ....");
            connect.Close();
        }
        //retrive btn
        private void button4_Click(object sender, EventArgs e)
        {
            connect.Open();
            dataGridView1.Rows.Clear();
            command = new SqlCommand("select * from Student", connect);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["Id"].Value = reader[0].ToString();
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["Std_Name"].Value = reader[1].ToString();
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["Department"].Value = reader[2].ToString();
            }
            connect.Close();

        }
    }
}
