using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace task9
{
    public partial class Form1 : Form
    {
        public Form1() { InitializeComponent(); }
        private void label1_Click(object sender, EventArgs e) { }
        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.')) e.Handled = true;
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1)) e.Handled = true;
        }
        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.')) e.Handled = true;
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1)) e.Handled = true;
        }
        private void Registration_Click(object sender, EventArgs e)
        {
            var line = string.Join("\t|\t", textBox1.Text, textBox2.Text, textBox3.Text, dateTimePicker1.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text);
            File.AppendAllText("Clients.txt", line);
            File.AppendAllText("Clients.txt", "\n");
            MessageBox.Show("\n\tInformation has been saved successfully!\t\n");
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            dateTimePicker1.Value = System.DateTime.Today;
        }
        DataTable table = new DataTable();
        private void Form1_Load(object sender, EventArgs e)
        {
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("Surname", typeof(string));
            table.Columns.Add("ID", typeof(string));
            table.Columns.Add("Date of birth", typeof(string));
            table.Columns.Add("Email ID", typeof(string));
            table.Columns.Add("Mobile number", typeof(string));
            table.Columns.Add("Zip code", typeof(string));
            table.Columns.Add("Weblink", typeof(string));
            dataGridView1.DataSource = table;
        }
        private void Find_Click(object sender, EventArgs e)
        {
            string[] lines = File.ReadAllLines("Clients.txt");
            string[] values;
            for (int i = 0; i < lines.Length; i++)
            {
                values = lines[i].ToString().Split('|');
                string[] row = new string[values.Length];
                for (int j = 0; j < values.Length; j++) row[j] = values[j].Trim();
                table.Rows.Add(row);
            }
        }
    }
}