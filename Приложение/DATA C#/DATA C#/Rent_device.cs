using Guna.UI2.WinForms;
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
    public partial class Rent_device : Form
    {
        public Rent_device()
        {
            InitializeComponent();
        }
        private DataBase db;
        string id;
        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            this.Close(); //Закрытие диологовое окно
        }

        private void guna2CircleButton1_MouseEnter(object sender, EventArgs e)
        {
            guna2CircleButton1.ForeColor = Color.Red;
        }

        private void guna2CircleButton1_MouseLeave(object sender, EventArgs e)
        {
            guna2CircleButton1.ForeColor = Color.White;
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
        private void LoadData()
        {
            var db = DataBase.GetInstance();
            var conn = db.GetConnection();

            if (conn != null && conn.State == ConnectionState.Open)
            {
                string query = @"
           SELECT 
            Rent_device.ID_device as Id,
            Rent_device.Name_device as name,
            Renters.Name as renter_name,
            Rent_device.Rent_from as rent_from,
            Rent_device.Rent_to_up as rent_to_up
          FROM Rent_device
          LEFT JOIN Renters
          ON Renters.ID = Rent_device.Renters
        ";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        dataGridView1.Rows.Clear();
                        while (reader.Read())
                        {
                            string rentFromStr = reader["rent_from"]?.ToString() ?? "";
                            string rentToStr = reader["rent_to_up"]?.ToString() ?? "";

                            string idDevice = reader["Id"]?.ToString() ?? "";
                            string nameDevice = reader["name"]?.ToString() ?? "";
                            string renterName = reader["renter_name"]?.ToString() ?? "";


                            DateTime rentFrom;
                            DateTime rentTo;

                            bool fromParsed = DateTime.TryParse(rentFromStr, out rentFrom);
                            bool toParsed = DateTime.TryParse(rentToStr, out rentTo);


                            int rowIndex = dataGridView1.Rows.Add(
                                idDevice,
                                nameDevice,
                                renterName,
                                fromParsed ? rentFrom.ToShortDateString() : "",
                                toParsed ? rentTo.ToShortDateString() : ""
                            );

                            if (fromParsed && toParsed && rentTo < DateTime.Now)
                            {
                                dataGridView1.Rows[rowIndex].DefaultCellStyle.BackColor = Color.Red;
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

        private void LoadRentersWithPositions()
        {
            Trade_ComboBox2.Items.Clear();

            db = DataBase.GetInstance();
            using (SQLiteConnection conn = db.GetConnection())
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    string selectRentersQuery = "SELECT ID, Name FROM Renters";
                    using (SQLiteCommand selectRentersCommand = new SQLiteCommand(selectRentersQuery, conn))
                    {
                        try
                        {
                            using (SQLiteDataReader reader = selectRentersCommand.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    int renterId = Convert.ToInt32(reader["ID"]);
                                    string renterName = reader["Name"].ToString();

                                    // Проверка, есть ли аренда у продавца в Rent_position
                                    string checkRentPositionQuery = "SELECT COUNT(*) FROM Rent_position WHERE Renters = @renterId";
                                    using (SQLiteCommand checkRentPositionCommand = new SQLiteCommand(checkRentPositionQuery, conn))
                                    {
                                        checkRentPositionCommand.Parameters.AddWithValue("@renterId", renterId);
                                        try
                                        {
                                            int rentCount = Convert.ToInt32(checkRentPositionCommand.ExecuteScalar());
                                            if (rentCount > 0)
                                            {
                                                Trade_ComboBox2.Items.Add(renterName);
                                            }
                                        }
                                        catch (SQLiteException ex)
                                        {
                                            MessageBox.Show($"Ошибка проверки аренды: {ex.Message}");
                                            continue;
                                        }
                                    }
                                }
                            }
                        }
                        catch (SQLiteException ex)
                        {
                            MessageBox.Show($"Ошибка при получении продавцов: {ex.Message}");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Ошибка подключения к БД.");
                }
            }
        }

        private void Rent_device_Load(object sender, EventArgs e)
        {
            LoadRentersWithPositions();
            //Trade_Load();
            LoadData();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            string Name_device = Name_ComboBox1.Text;

            if (string.IsNullOrEmpty(Name_device))
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
                        string query = "INSERT INTO Rent_device (Name_device) VALUES (@Name_device)";
                        SQLiteCommand command = new SQLiteCommand(query, conn);
                        command.Parameters.AddWithValue("@Name_device", Name_device);
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


        private void Redact_Click(object sender, EventArgs e)
        {
            if (
                string.IsNullOrEmpty(Trade_ComboBox2.Text) ||
                string.IsNullOrEmpty(guna2TextBox6.Text) ||
                string.IsNullOrEmpty(guna2TextBox5.Text)
            )
            {
                MessageBox.Show("Заполните редактируемые поля!");
            }
            else if (!Regex.IsMatch(Trade_ComboBox2.Text, "^[а-яА-Я -]+$"))
            {
                MessageBox.Show("Заполните имя продовца.");
            }
            else if (!DateTime.TryParseExact(guna2TextBox6.Text, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime fromDate))
            {
                MessageBox.Show("Заполните информацию о сроке аренды в формате ДД.ММ.ГГГГ.");
            }
            else if (!DateTime.TryParseExact(guna2TextBox5.Text, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime untilDate))
            {
                MessageBox.Show("Заполните информацию о сроке аренды в формате ДД.ММ.ГГГГ.");
            }
            else
            {
                // Запрос согласия на внесение изменений
                DialogResult result = MessageBox.Show("Вы уверены, что хотите внести изменения?", "Подтверждение", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    // Проверка, выбрана ли строка в DataGridView
                    if (dataGridView1.SelectedRows.Count > 0)
                    {
                        // Получение выбранной строки из DataGridView
                        DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                        string id = selectedRow.Cells["ID_device"].Value.ToString();
                        string nameDevice = selectedRow.Cells["Name_device"].Value.ToString();

                        // Получение экземпляра базы данных и соединения
                        var db = DataBase.GetInstance();
                        using (var conn = db.GetConnection())
                        {
                            // SQL запрос для обновления данных
                            string query = @"
                            UPDATE Rent_device
                            SET
                            Renters = (SELECT ID FROM Renters WHERE Name = @Renters),
                            Rent_from = @Rent_from,
                            Rent_to_up = @Rent_to
                            WHERE
                            ID_device = @id;
                             ";

                            using (SQLiteCommand command = new SQLiteCommand(query, conn))
                            {
                                // Добавление параметров
                                command.Parameters.AddWithValue("@id", id);
                                command.Parameters.AddWithValue("@Name_device", nameDevice);
                                command.Parameters.AddWithValue("@Renters", Trade_ComboBox2.Text);
                                command.Parameters.AddWithValue("@Rent_from", fromDate.ToString("dd.MM.yyyy"));
                                command.Parameters.AddWithValue("@Rent_to", untilDate.ToString("dd.MM.yyyy"));

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
                string id = dataGridView1.SelectedRows[0].Cells["ID_device"].Value.ToString();

                // Диалоговое окно "Да/Нет"
                DialogResult result = MessageBox.Show("Вы действительно хотите очистить запись?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    string sql = "UPDATE Rent_device SET Renters = null, Rent_from = null, Rent_to_up = null WHERE ID_device = @id";
                    SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                    dataGridView1.Refresh();
                    MessageBox.Show("Запись очишена!");
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
            Name_TextBox1.Clear();
            Trade_ComboBox2.SelectedIndex = -1;
            guna2TextBox6.Clear();
            guna2TextBox5.Clear();

            if (dataGridView1.SelectedRows.Count > 0)
            {
                db = DataBase.GetInstance();
                SQLiteConnection conn = db.GetConnection();
                id = dataGridView1.SelectedRows[0].Cells["ID_device"].Value.ToString();
                string query = "SELECT Name_device, Renters, Rent_from, Rent_to_up FROM Rent_device WHERE ID_device = @id";
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                SQLiteDataReader reader = cmd.ExecuteReader();

                int selectedRowIndex = e.RowIndex;
                DataGridViewRow selectedDGVRow = dataGridView1.Rows[selectedRowIndex];
                Trade_ComboBox2.Text = selectedDGVRow.Cells[2].Value.ToString();

                if (reader.Read())
                {
                    // Заполняем текстовые поля
                    Name_TextBox1.Text = reader["Name_device"].ToString();
                    //Trade_ComboBox2.Text = reader["Renters"].ToString();
                    guna2TextBox6.Text = reader["Rent_from"].ToString();
                    guna2TextBox5.Text = reader["Rent_to_up"].ToString();
                }
                reader.Close(); // Закрываем reader
            }
        }

        private void Del_Button1_Click(object sender, EventArgs e)
        {
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    db = DataBase.GetInstance();
                    SQLiteConnection conn = db.GetConnection();
                    string id = dataGridView1.SelectedRows[0].Cells["ID_device"].Value.ToString();

                    // Диалоговое окно "Да/Нет"
                    DialogResult result = MessageBox.Show("Вы действительно хотите удалить оборудование?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        string sql = "DELETE FROM Rent_device WHERE ID_device = @id";
                        SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                        dataGridView1.Refresh();
                        MessageBox.Show("Оборудование удалена из базы!");
                        LoadData();
                    }
                }
                else
                {
                    MessageBox.Show("Выберите оборудование для удаления!");
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
                       row.Cells["Rent_to_up"].Value is string toStr)
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
            guna2TextBox3.Clear();
            guna2TextBox1.Clear();
        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {
            string filter = guna2TextBox3.Text;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["Name_device"].Value != null && row.Cells["Name_device"].Value.ToString().ToLower().Contains(filter.ToLower()))
                {
                    row.Visible = true;
                }
                else
                {
                    row.Visible = false;
                }
            }
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            string filter = guna2TextBox1.Text;
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
