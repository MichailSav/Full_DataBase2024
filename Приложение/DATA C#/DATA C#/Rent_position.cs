using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace DATA_C_
{
    public partial class Rent_position : Form
    {
        public Rent_position()
        {
            InitializeComponent();
        }
        private DataBase db;
        string id;
        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        Point lastpoint;
        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            lastpoint = new Point(e.X, e.Y);
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)// Возможность передвигать диологовое окно
            {
                this.Left += e.X - lastpoint.X;
                this.Top += e.Y - lastpoint.Y;
            }
        }

        private void guna2CircleButton1_MouseEnter(object sender, EventArgs e)
        {
            guna2CircleButton1.ForeColor = Color.Red;
        }

        private void guna2CircleButton1_MouseLeave(object sender, EventArgs e)
        {
            guna2CircleButton1.ForeColor = Color.White;
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadData()
        {
            var db = DataBase.GetInstance();
            var conn = db.GetConnection();

            if (conn != null && conn.State == ConnectionState.Open)
            {
                string query = @"
                SELECT 
                Rent_position.Num_position as num_position,
                Human_Resources_Department.Full_Name as lesser_name,
                Renters.Name as renter_name,
                Rent_position.Rent_from as rent_from,
                Rent_position.Rent_up_to as rent_to
                FROM Rent_position
                LEFT JOIN Human_Resources_Department 
                ON Human_Resources_Department.ID_workers = Rent_position.Lessers 
                LEFT JOIN Renters 
                ON Renters.ID = Rent_position.Renters;
                ";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        dataGridView1.Rows.Clear();
                        while (reader.Read())
                        {
                            string numPosition = reader["num_position"]?.ToString() ?? "";
                            string lesserName = reader["lesser_name"]?.ToString() ?? "";
                            string renterName = reader["renter_name"]?.ToString() ?? "";
                            string rentFromStr = reader["rent_from"]?.ToString() ?? "";
                            string rentToStr = reader["rent_to"]?.ToString() ?? "";

                            DateTime rentFrom;
                            DateTime rentTo;

                            bool fromParsed = DateTime.TryParse(rentFromStr, out rentFrom);
                            bool toParsed = DateTime.TryParse(rentToStr, out rentTo);


                            int rowIndex = dataGridView1.Rows.Add(
                               numPosition,
                                lesserName,
                                renterName,
                                fromParsed ? rentFrom.ToShortDateString() : "",
                                toParsed ? rentTo.ToShortDateString() : ""
                             );


                            if (string.IsNullOrWhiteSpace(lesserName) && string.IsNullOrWhiteSpace(renterName))
                            {
                                dataGridView1.Rows[rowIndex].DefaultCellStyle.BackColor = Color.White;
                            }
                            else if (string.IsNullOrWhiteSpace(lesserName) || string.IsNullOrWhiteSpace(renterName))
                            {
                                dataGridView1.Rows[rowIndex].DefaultCellStyle.BackColor = Color.Orange; // Подсветка оранжевым
                            }
                            else if (fromParsed && toParsed && rentTo < DateTime.Now)
                            {
                                dataGridView1.Rows[rowIndex].DefaultCellStyle.BackColor = Color.Red; // Подсветка красным если срок истек
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Ошибка подключения к БД.");
            }
        }

        private void Name_Load()
        {
            db = DataBase.GetInstance();
            SQLiteConnection conn1 = db.GetConnection();
            string query1 = "SELECT Renters.Name FROM Renters";
            SQLiteCommand cmd1 = new SQLiteCommand(query1, conn1);
            SQLiteDataReader reader1 = cmd1.ExecuteReader();
            while (reader1.Read())
            {
                string data = reader1.GetString(0);
                Trade_ComboBox2.Items.Add(data);
            }
        }

        private void Lesser_Load()
        {
            SQLiteConnection conn2 = db.GetConnection();
            string query2 = "SELECT Human_Resources_Department.Full_Name FROM Human_Resources_Department WHERE Profession = 'Арендодатель'";
            SQLiteCommand cmd2 = new SQLiteCommand(query2, conn2);
            SQLiteDataReader reader2 = cmd2.ExecuteReader();
            while (reader2.Read())
            {
                string data = reader2.GetString(0);
                lesser_ComboBox1.Items.Add(data);
            }
        }

       

        private void Rent_position_Load(object sender, EventArgs e)
        {
            Name_Load();
            Lesser_Load();

            LoadData();
        }


        private void Redact_Click(object sender, EventArgs e)
        {
            if (
                string.IsNullOrEmpty(Trade_ComboBox2.Text) ||
                string.IsNullOrEmpty(lesser_ComboBox1.Text) ||
                string.IsNullOrEmpty(from_TextBox8.Text) ||
                string.IsNullOrEmpty(untill_TextBox7.Text))
            {
                MessageBox.Show("Заполните редактируемые поля!");
            }
            else if (!Regex.IsMatch(Trade_ComboBox2.Text, "^[а-яА-Я -]+$"))
            {
                MessageBox.Show("Заполните имя арендателя.");
            }
            else if (!Regex.IsMatch(lesser_ComboBox1.Text, "^[а-яА-Я -]+$"))
            {
                MessageBox.Show("Заполните имя арендодателя");
            }
            else if (!DateTime.TryParseExact(from_TextBox8.Text, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime fromDate))
            {
                MessageBox.Show("Заполните информацию о сроке аренды в формате ДД.ММ.ГГГГ.");
            }
            else if (!DateTime.TryParseExact(untill_TextBox7.Text, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime untilDate))
            {
                MessageBox.Show("Заполните информацию о сроке аренды в формате ДД.ММ.ГГГГ.");
            }
            else if (fromDate > DateTime.Now.Date)
            {
                MessageBox.Show("Дата начала срока аренды не может быть в будущем.");
                return;
            }
            else if (untilDate <= fromDate)
            {
                MessageBox.Show("Дата окончания срока аренды должна быть больше даты начала.");
                return;
            }
            else
            {
                DialogResult result = MessageBox.Show("Вы уверены, что хотите внести изменения?", "Подтверждение", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    if (dataGridView1.SelectedRows.Count > 0)
                    {
                        DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                        string numPosition = selectedRow.Cells["Num_position"].Value.ToString(); // Получаем Num_position

                        // Получение экземпляра базы данных и соединения
                        var db = DataBase.GetInstance();
                        using (var conn = db.GetConnection())
                        {
                            // SQL запрос для обновления данных
                            string query = @"
                        UPDATE Rent_position
                        SET
                        Lessers = (SELECT ID_workers FROM Human_Resources_Department WHERE Full_Name = @lesser_name),
                        Renters = (SELECT ID FROM Renters WHERE Name = @renter_name),
                        Rent_from = @rent_from,
                        Rent_up_to = @rent_to
                        WHERE
                        Num_position = @num_position;
                      ";

                            using (SQLiteCommand command = new SQLiteCommand(query, conn))
                            {
                                // Добавление параметров с правильными названиями
                                command.Parameters.AddWithValue("@num_position", numPosition);
                                command.Parameters.AddWithValue("@renter_name", Trade_ComboBox2.Text);
                                command.Parameters.AddWithValue("@lesser_name", lesser_ComboBox1.Text);
                                command.Parameters.AddWithValue("@rent_from", fromDate.ToString("dd.MM.yyyy"));
                                command.Parameters.AddWithValue("@rent_to", untilDate.ToString("dd.MM.yyyy"));

                                // Выполнение запроса
                                command.ExecuteNonQuery();
                                MessageBox.Show("Запись успешно изменена!");
                                LoadData();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Выберите строку для редактирования.");
                    }
                }
            }
        }

        private void Del_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                db = DataBase.GetInstance();
                SQLiteConnection conn = db.GetConnection();
                string id = dataGridView1.SelectedRows[0].Cells["Num_position"].Value.ToString();

                // Диалоговое окно "Да/Нет"
                DialogResult result = MessageBox.Show("Вы действительно хотите удалить запись?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    string sql = "UPDATE Rent_position SET Lessers = null, Renters = null, Rent_from = null, Rent_up_to = null WHERE Num_position = @id";
                    SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                    dataGridView1.Refresh();
                    MessageBox.Show("Запись удалена из базы!");
                    LoadData();
                }
            }
            else
            {
                MessageBox.Show("Выберите запись для удаления!");
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            from_TextBox8.Clear();
            untill_TextBox7.Clear();
            Trade_ComboBox2.SelectedIndex = -1;
            lesser_ComboBox1.SelectedIndex = -1;

            if (dataGridView1.SelectedRows.Count > 0)
            {
                db = DataBase.GetInstance();
                SQLiteConnection conn = db.GetConnection();

                string id = dataGridView1.SelectedRows[0].Cells["Num_position"].Value?.ToString();

                if (string.IsNullOrEmpty(id))
                {
                    MessageBox.Show("Значение 'Num_position' не найдено.");
                    return;
                }


                string query = "SELECT Lessers, Renters, Rent_from, Rent_up_to FROM Rent_position WHERE Num_position = @id";
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                SQLiteDataReader reader = cmd.ExecuteReader();

                int selectedRowIndex = e.RowIndex;
                DataGridViewRow selectedDGVRow = dataGridView1.Rows[selectedRowIndex];
                Trade_ComboBox2.Text = selectedDGVRow.Cells[2].Value.ToString();
                lesser_ComboBox1.Text = selectedDGVRow.Cells[1].Value.ToString();

                if (reader.Read())
                {
                    from_TextBox8.Text = reader["Rent_from"].ToString();
                    untill_TextBox7.Text = reader["Rent_up_to"].ToString();
                }
                else
                {
                    MessageBox.Show("Запись с указанным ID не найдена.");
                }
                reader.Close();
            }
        }


        private void Trade_ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ide1 = Trade_ComboBox2.Text;
            db = DataBase.GetInstance();
            SQLiteConnection conn1 = db.GetConnection();
            
            string query1 = "SELECT ID FROM Renters WHERE Name = @ide)";
            SQLiteCommand cmd1 = new SQLiteCommand(query1, conn1);
            cmd1.Parameters.AddWithValue("@ide", ide1);
        }

        private void lesser_ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ide2 = lesser_ComboBox1.Text;
            db = DataBase.GetInstance();
            SQLiteConnection conn1 = db.GetConnection();
            
            string query2 = "SELECT ID_workers FROM Human_Resources_Department WHERE Profession = @ide)";
            SQLiteCommand cmd2 = new SQLiteCommand(query2, conn1);
            cmd2.Parameters.AddWithValue("@ide", ide2);
        }

        private void ADD_Button1_Click(object sender, EventArgs e)
        {
            string Num_position = guna2TextBox5.Text;

            if (string.IsNullOrEmpty(Num_position))
            {
                MessageBox.Show("Заполните все поля.");
            }
            else
            {
                DialogResult result = MessageBox.Show("Вы уверены, что хотите добавить оборудование?", "Подтверждение", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        db = DataBase.GetInstance();
                        SQLiteConnection conn = db.GetConnection();
                        string query = "INSERT INTO Rent_position (Num_position) VALUES (@Num_position)";
                        SQLiteCommand command = new SQLiteCommand(query, conn);
                        command.Parameters.AddWithValue("@Num_position", Num_position);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Запись добавлена в базу!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка при добавлении записи: " + ex.Message);
                    }
                }
            }
            LoadData();
        }
    

        private void DEL_Button2_Click(object sender, EventArgs e)
        {
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    db = DataBase.GetInstance();
                    SQLiteConnection conn = db.GetConnection();
                    string id = dataGridView1.SelectedRows[0].Cells["Num_position"].Value.ToString();

                    // Диалоговое окно "Да/Нет"
                    DialogResult result = MessageBox.Show("Вы действительно хотите удалить запись?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        string sql = "DELETE FROM Rent_position WHERE Num_position = @id";
                        SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                        dataGridView1.Refresh();
                        MessageBox.Show("Запись удалена из базы!");
                        LoadData();
                    }
                }
                else
                {
                    MessageBox.Show("Выберите запись для удаления!");
                }

            }
        }

        private void Filter_Button1_Click(object sender, EventArgs e)
        {
            FilterData();
        }

        private void FilterData()
        {
            string fromDateStr = OT_TextBox1.Text;
            string toDateStr = DO_TextBox2.Text;

            if (DateTime.TryParseExact(fromDateStr, "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime fromDate) &&
                DateTime.TryParseExact(toDateStr, "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime toDate))
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.IsNewRow) continue; // Пропускаем строку для нового ввода


                    if (row.Cells["Rent_from"].Value is string fromStr &&
                       row.Cells["Column1"].Value is string toStr)
                    {


                        if (DateTime.TryParse(fromStr, out DateTime rowFromDate) && DateTime.TryParse(toStr, out DateTime rowToDate))
                        {
                            row.Visible = rowFromDate >= fromDate && rowToDate <= toDate;
                        }
                        else
                        {
                            row.Visible = false;
                        }
                    }

                    else
                    {
                        row.Visible = false;
                    }
                }
            }
            else if (!string.IsNullOrEmpty(fromDateStr) || !string.IsNullOrEmpty(toDateStr)) //Обработка частичного ввода
            {
                MessageBox.Show("Некорректный формат даты. Пожалуйста, используйте формат dd.MM.yyyy.");
            }
            else
            {
                // Если даты пустые, отображаем все строки
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    row.Visible = true;
                }
            }
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            OT_TextBox1.Clear();
            DO_TextBox2.Clear();
            guna2TextBox6.Clear();
            guna2TextBox3.Clear();
            guna2TextBox2.Clear();
        }

        private void guna2TextBox6_TextChanged(object sender, EventArgs e)
        {
            string filter = guna2TextBox6.Text;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["Num_position"].Value != null && row.Cells["Num_position"].Value.ToString().ToLower().Contains(filter.ToLower()))
                {
                    row.Visible = true;
                }
                else
                {
                    row.Visible = false;
                }
            }
        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {
            string filter = guna2TextBox3.Text;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["ID_lessers"].Value != null && row.Cells["ID_lessers"].Value.ToString().ToLower().Contains(filter.ToLower()))
                {
                    row.Visible = true;
                }
                else
                {
                    row.Visible = false;
                }
            }
        }

        private void guna2TextBox2_TextChanged_1(object sender, EventArgs e)
        {
            string filter = guna2TextBox2.Text;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["ID_renters"].Value != null && row.Cells["ID_renters"].Value.ToString().ToLower().Contains(filter.ToLower()))
                {
                    row.Visible = true;
                }
                else
                {
                    row.Visible = false;
                }
            }
        }
    }
}
