using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;

namespace WindowsFormsApp20
{
    public partial class Form0 : Form
    {
        public string connectionString = Properties.Settings.Default.connection_string;
        public Form0()
        {
            InitializeComponent();
            textBox1.Text = Properties.Settings.Default.connection_string;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                using (FbConnection connection = new FbConnection(textBox1.Text))
                {
                    connection.Open();
                    MessageBox.Show("Соединение успешно", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (FbException ex)
            {
                MessageBox.Show("Ошибка соединения: " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1= new Form1();
            form1.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form0_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            form5.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();
            form6.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form7 form7 = new Form7();
            form7.Show();
        }
    }
}
