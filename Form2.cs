using System;
using System.Data;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;

namespace WindowsFormsApp20
{
    public partial class Form2 : Form
    {
        public string connectionString = Properties.Settings.Default.connection_string;
        public Form2()
        {
            InitializeComponent();
            textBox1.Text = Properties.Settings.Default.connection_string;
            this.Text = "Таблица: \"Накладная\"";
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            LoadDataIntoDataGridView();
        }

        private void LoadDataIntoDataGridView()
        {
            string query = "SELECT * FROM NAKLADNAYA";

            try
            {
                using (FbConnection connection = new FbConnection(textBox1.Text))
                {
                    connection.Open();

                    using (FbDataAdapter adapter = new FbDataAdapter(query, connection))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridView1.DataSource = dataTable;
                        dataGridView1.AutoResizeColumns();
                    }
                }
            }
            catch (FbException ex)
            {
                MessageBox.Show("Ошибка при загрузке данных: " + ex.Message);
            }
        }

        private void LoadDataIntoDataGridView2()
        {
            string query = "SELECT * FROM NAKLADNAYA_DATA";

            try
            {
                using (FbConnection connection = new FbConnection(textBox1.Text))
                {
                    connection.Open();

                    using (FbDataAdapter adapter = new FbDataAdapter(query, connection))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridView1.DataSource = dataTable;
                        dataGridView1.AutoResizeColumns();
                    }
                }
            }
            catch (FbException ex)
            {
                MessageBox.Show("Ошибка при загрузке данных: " + ex.Message);
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(dataGridView1.CurrentRow.Cells["KLADOVSHIK_ID"].Value.ToString());
            // Проверяем, что все необходимые поля заполнены
            if (!string.IsNullOrEmpty(dataGridView1.CurrentRow.Cells["NAKLADNAYA_ID"].Value.ToString()) && !string.IsNullOrEmpty(dataGridView1.CurrentRow.Cells["POSTAVSHIK_ID"].Value.ToString()) && !string.IsNullOrEmpty(dataGridView1.CurrentRow.Cells["KLADOVSHIK_ID"].Value.ToString()) && !string.IsNullOrEmpty(dataGridView1.CurrentRow.Cells["SKLAD_ID"].Value.ToString()) && !string.IsNullOrEmpty(dataGridView1.CurrentRow.Cells["N_DATE"].Value.ToString()))
            {
                string insertQuery = "INSERT INTO NAKLADNAYA VALUES (@value1, @value2, @value3, @value4, @value5)";

                try
                {
                    using (FbConnection connection = new FbConnection(textBox1.Text))
                    {
                        connection.Open();

                        using (FbCommand command = new FbCommand(insertQuery, connection))
                        {
                            // Задаем параметры для запроса
                            command.Parameters.AddWithValue("@value1", dataGridView1.CurrentRow.Cells["NAKLADNAYA_ID"].Value);
                            command.Parameters.AddWithValue("@value2", dataGridView1.CurrentRow.Cells["POSTAVSHIK_ID"].Value);
                            command.Parameters.AddWithValue("@value3", dataGridView1.CurrentRow.Cells["KLADOVSHIK_ID"].Value);
                            command.Parameters.AddWithValue("@value4", dataGridView1.CurrentRow.Cells["SKLAD_ID"].Value);
                            command.Parameters.AddWithValue("@value5", dataGridView1.CurrentRow.Cells["N_DATE"].Value);

                            // Выполняем запрос
                            command.ExecuteNonQuery();

                            MessageBox.Show("Запись успешно добавлена", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // После добавления записи обновляем DataGridView
                            LoadDataIntoDataGridView();

                            // Очищаем текстовые поля после добавления записи
                        }
                    }
                }
                catch (FbException ex)
                {
                    MessageBox.Show("Ошибка добавления записи: " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, заполните все поля.");
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Получаем ID выбранной записи для удаления
                int selectedId = (int)dataGridView1.SelectedRows[0].Cells["NAKLADNAYA_ID"].Value;

                string deleteQuery = "DELETE FROM NAKLADNAYA WHERE NAKLADNAYA_ID = @id";
                try
                {
                    using (FbConnection connection = new FbConnection(textBox1.Text))
                    {
                        connection.Open();

                        using (FbCommand command = new FbCommand(deleteQuery, connection))
                        {
                            command.Parameters.AddWithValue("@id", selectedId);
                            command.ExecuteNonQuery();

                            MessageBox.Show("Запись успешно удалена", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadDataIntoDataGridView();
                        }
                    }
                }
                catch (FbException ex)
                {
                    MessageBox.Show("Ошибка удаления записи: " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Выберите запись для удаления.");
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(dataGridView1.CurrentRow.Cells["KLADOVSHIK_ID"].Value.ToString());
            // Проверяем, что все необходимые поля заполнены
            if (dataGridView1.SelectedRows.Count > 0)
            {
                if (!string.IsNullOrEmpty(dataGridView1.CurrentRow.Cells["NAKLADNAYA_ID"].Value.ToString()) && !string.IsNullOrEmpty(dataGridView1.CurrentRow.Cells["POSTAVSHIK_ID"].Value.ToString()) && !string.IsNullOrEmpty(dataGridView1.CurrentRow.Cells["KLADOVSHIK_ID"].Value.ToString()) && !string.IsNullOrEmpty(dataGridView1.CurrentRow.Cells["SKLAD_ID"].Value.ToString()) && !string.IsNullOrEmpty(dataGridView1.CurrentRow.Cells["N_DATE"].Value.ToString()))
                {
                    string insertQuery = "UPDATE NAKLADNAYA SET NAKLADNAYA_ID = @value1, POSTAVSHIK_ID = @value2, KLADOVSHIK_ID = @value3, SKLAD_ID = @value4, N_DATE = @value5 WHERE NAKLADNAYA_ID = @value1";

                    try
                    {
                        using (FbConnection connection = new FbConnection(textBox1.Text))
                        {
                            connection.Open();

                            using (FbCommand command = new FbCommand(insertQuery, connection))
                            {
                                // Задаем параметры для запроса
                                command.Parameters.AddWithValue("@value1", dataGridView1.CurrentRow.Cells["NAKLADNAYA_ID"].Value);
                                command.Parameters.AddWithValue("@value2", dataGridView1.CurrentRow.Cells["POSTAVSHIK_ID"].Value);
                                command.Parameters.AddWithValue("@value3", dataGridView1.CurrentRow.Cells["KLADOVSHIK_ID"].Value);
                                command.Parameters.AddWithValue("@value4", dataGridView1.CurrentRow.Cells["SKLAD_ID"].Value);
                                command.Parameters.AddWithValue("@value5", dataGridView1.CurrentRow.Cells["N_DATE"].Value);

                                // Выполняем запрос
                                command.ExecuteNonQuery();

                                MessageBox.Show("Запись успешно добавлена", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // После добавления записи обновляем DataGridView
                                LoadDataIntoDataGridView();

                                // Очищаем текстовые поля после добавления записи
                            }
                        }
                    }
                    catch (FbException ex)
                    {
                        MessageBox.Show("Ошибка добавления записи: " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Пожалуйста, заполните все поля.");
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, заполните все поля.");
            }
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            LoadDataIntoDataGridView();
            button1.Show();
            button3.Show();
            button5.Show();
            this.Text = "Таблица: \"Накладная\"";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Close();
            // Application.Exit();
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

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            LoadDataIntoDataGridView2();
            button1.Hide();
            button3.Hide();
            button5.Hide();
            this.Text = "Запрос: \"Учет обслуживания поставщика кладовщиком на складе в определенную дату\"";
        }
    }
}