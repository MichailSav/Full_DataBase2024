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
using System.Management;


namespace DATA_C_
{
    public partial class Renters : Form
    {
        public Renters()
        {
            InitializeComponent();
        }
        private DataBase db;
        string id;
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
            using (var conn = db.GetConnection())
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    string query = @"
                SELECT 
                    Renters.ID,
                    Renters.Name,
                    Renters.Passport_series,
                    Renters.Passport_number,
                    Лицензии.Lisenssee AS License,
                    Renters.licen_to_up,
                    Renters.licen_from
                FROM Renters
                LEFT JOIN Лицензии
                ON Лицензии.ID = Renters.License";

                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        try
                        {
                            using (var reader = cmd.ExecuteReader())
                            {
                                dataGridView1.Rows.Clear();
                                while (reader.Read())
                                {
                                    //Обработка потенциальных null значений
                                    string id = reader["ID"].ToString();
                                    string name = reader["Name"].ToString();
                                    string passportSeries = reader["Passport_series"].ToString();
                                    string passportNumber = reader["Passport_number"].ToString();
                                    string license = reader["License"].ToString();
                                    string licFromStr = reader["licen_from"].ToString(); // Вместо ?? ""
                                    string licToStr = reader["licen_to_up"].ToString(); // Вместо ?? ""


                                    DateTime licFrom;
                                    DateTime licTo;
                                    bool fromParsed = DateTime.TryParse(licFromStr, out licFrom);
                                    bool toParsed = DateTime.TryParse(licToStr, out licTo);
                                    //Обработка потенциальных null значений
                                    int rowIndex = dataGridView1.Rows.Add(
                                       id,
                                       name,
                                       passportSeries,
                                       passportNumber,
                                       license,
                                       fromParsed ? licFrom.ToShortDateString() : "",
                                       toParsed ? licTo.ToShortDateString() : ""
                                   );

                                    // Проверка, наступило ли время действия лицензии
                                    if (licFrom > DateTime.Now)
                                    {
                                        dataGridView1.Rows[rowIndex].DefaultCellStyle.BackColor = Color.LightGray; // Серый цвет
                                    }
                                    else if (licTo < DateTime.Now)
                                    {
                                        dataGridView1.Rows[rowIndex].DefaultCellStyle.BackColor = Color.Red; // Красный цвет
                                    }
                                }
                            }
                        }
                        catch (SQLiteException ex)
                        {
                            MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Произошла ошибка: {ex.Message}");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Ошибка подключения к БД.");
                }
            }
        }

        private void Licen_Load()
        {
            db = DataBase.GetInstance();
            SQLiteConnection conn1 = db.GetConnection();
            string query1 = "SELECT Лицензии.Lisenssee FROM Лицензии";
            SQLiteCommand cmd1 = new SQLiteCommand(query1, conn1);
            SQLiteDataReader reader1 = cmd1.ExecuteReader();
            while (reader1.Read())
            {
                string data = reader1.GetString(0);
                Licen_ComboBox1.Items.Add(data);
            }
        }

        private void Renters_Load(object sender, EventArgs e)
        {
            Licen_Load();

            LoadData();
        }


        private void Add_Click(object sender, EventArgs e)
        {
            string name = Name_TextBox1.Text;
            string seria = guna2TextBox3.Text;
            string numbers = guna2TextBox4.Text;
            string Licen = Licen_ComboBox1.Text;
            string lic_from = От_TextBox2.Text;
            string lic_up_to = До_TextBox5.Text;


            if (string.IsNullOrEmpty(name) ||
                string.IsNullOrEmpty(seria) ||
                string.IsNullOrEmpty(numbers) ||
                string.IsNullOrEmpty(Licen) ||
                string.IsNullOrEmpty(lic_from) ||
                string.IsNullOrEmpty(lic_up_to))
            {
                MessageBox.Show("Заполните все поля.");
            }
            else if (!Regex.IsMatch(seria, "^[а-яА-Я0-9 .-]+$"))
            {
                MessageBox.Show("Заполните серию пспорта.");
            }
            else if (!Regex.IsMatch(name, "^[а-яА-Я -]+$"))
            {
                MessageBox.Show("Заполните ФИО.");
            }
            else if (!Regex.IsMatch(numbers, "^[0-9 .()+-]+$"))
            {
                MessageBox.Show("Заполните номер паспорта.");
            }
            else if (!Regex.IsMatch(Licen, "^[а-яА-Я0-9 .-]+$"))
            {
                MessageBox.Show("Заполните данные о лицензии.");
            }
            else if (!DateTime.TryParseExact(lic_from, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime fromDate))
            {
                MessageBox.Show("Заполните информацию о сроке действия лицензии в формате ДД.ММ.ГГГГ.");
                return;
            }
            else if (!DateTime.TryParseExact(lic_up_to, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime untillDate))
            {
                MessageBox.Show("Заполните информацию о сроке действия лицензии в формате ДД.ММ.ГГГГ.");
                return;
            }
            else
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "Image files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            byte[] imageBytes;
                            using (FileStream fs = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
                            {
                                imageBytes = new byte[fs.Length];
                                fs.Read(imageBytes, 0, (int)fs.Length);
                            }

                            using (SQLiteConnection connAdd = db.GetConnection())
                            {
                                int licenId;
                                string selectQuery2 = "SELECT ID FROM Лицензии WHERE Lisenssee = @lic";
                                using (SQLiteCommand selectCommand2 = new SQLiteCommand(selectQuery2, connAdd))
                                {
                                    selectCommand2.Parameters.AddWithValue("@lic", Licen);
                                    try
                                    {
                                        object result = selectCommand2.ExecuteScalar();
                                        if (result == null)
                                        {
                                            MessageBox.Show($"Лицензия с именем '{Licen}' не найден.");
                                            return;
                                        }
                                        licenId = Convert.ToInt32(result);
                                    }
                                    catch (SQLiteException ex)
                                    {
                                        MessageBox.Show($"Ошибка при получении ID лицензии: {ex.Message}");
                                        return;
                                    }
                                }

                                db = DataBase.GetInstance();
                                SQLiteConnection conn = db.GetConnection();
                                string query = "INSERT INTO Renters (Name, Passport_series, Passport_number, Photo, License, licen_from, licen_to_up) VALUES (@name, @seria, @numbers, @image, @Licen, @lic_from, @lic_up_to)";
                                SQLiteCommand command = new SQLiteCommand(query, conn);
                                command.Parameters.AddWithValue("@name", name);
                                command.Parameters.AddWithValue("@seria", seria);
                                command.Parameters.AddWithValue("@numbers", numbers);
                                command.Parameters.AddWithValue("@image", imageBytes);

                                command.Parameters.AddWithValue("@Licen", licenId);
                                command.Parameters.AddWithValue("@lic_from", lic_from);
                                command.Parameters.AddWithValue("@lic_up_to", lic_up_to);
                                command.ExecuteNonQuery();
                                MessageBox.Show("Запись добавлена в базу!");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ошибка при добавлении записи: " + ex.Message);
                        }
                    }
                }
                LoadData();
            }
        }

        private void Redact_Click(object sender, EventArgs e)
        {
            string license = Licen_ComboBox1.Text;

            if (string.IsNullOrEmpty(Name_TextBox1.Text) ||
                string.IsNullOrEmpty(guna2TextBox3.Text) ||
                string.IsNullOrEmpty(Licen_ComboBox1.Text) ||
                string.IsNullOrEmpty(От_TextBox2.Text) ||
                string.IsNullOrEmpty(До_TextBox5.Text) ||
                string.IsNullOrEmpty(guna2TextBox4.Text))
            {
                MessageBox.Show("Заполните редактируемые поля!");
            }
            else if (!Regex.IsMatch(Name_TextBox1.Text, "^[а-яА-Я -]+$"))
            {
                MessageBox.Show("Заполните данные ФИО правильно.");
            }
            else if (!Regex.IsMatch(guna2TextBox3.Text, "^[0-9 .-]+$"))
            {
                MessageBox.Show("Заполните серию паспорта.");
            }
            else if (!Regex.IsMatch(guna2TextBox4.Text, "^[0-9 .]+$"))
            {
                MessageBox.Show("Заполните номер паспорта.");
            }
            else if (!Regex.IsMatch(Licen_ComboBox1.Text, "^[а-яА-Я -]+$"))
            {
                MessageBox.Show("Заполните данные о лицензии.");
            }
            else if (!DateTime.TryParseExact(От_TextBox2.Text, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime fromDate))
            {
                MessageBox.Show("Заполните информацию о сроке действия лицензии в формате ДД.ММ.ГГГГ.");
                return;
            }
            else if (!DateTime.TryParseExact(До_TextBox5.Text, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime untillDate))
            {
                MessageBox.Show("Заполните информацию о сроке действия лицензии в формате ДД.ММ.ГГГГ.");
                return;
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
                        string id = selectedRow.Cells["ID_rent"].Value.ToString();

                        // Получение экземпляра базы данных и соединения
                        db = DataBase.GetInstance();
                        SQLiteConnection conn = db.GetConnection();
                        using (SQLiteConnection connAdd = db.GetConnection())
                        {
                            int licenId;
                            string selectQuery2 = "SELECT ID FROM Лицензии WHERE Lisenssee = @lic";
                            using (SQLiteCommand selectCommand = new SQLiteCommand(selectQuery2, connAdd))
                            {
                                selectCommand.Parameters.AddWithValue("@lic", license);
                                try
                                {
                                    object result1 = selectCommand.ExecuteScalar();
                                    if (result1 == null)
                                    {
                                        MessageBox.Show($"Лицензии с названием '{license}' не найдена.");
                                        return;
                                    }
                                    licenId = Convert.ToInt32(result1);
                                }
                                catch (SQLiteException ex)
                                {
                                    MessageBox.Show($"Ошибка при получении лицензии: {ex.Message}");
                                    return;
                                }
                            }

                            // SQL запрос для обновления данных
                            string query = "UPDATE Renters SET Name = @name, Passport_series = @ser, Passport_number = @num, License = @lic, licen_from = @from, licen_to_up = @untill WHERE ID = @id";
                            SQLiteCommand command = new SQLiteCommand(query, conn);

                            // Добавление параметров
                            command.Parameters.AddWithValue("@id", id);
                            command.Parameters.AddWithValue("@name", Name_TextBox1.Text);
                            command.Parameters.AddWithValue("@ser", guna2TextBox3.Text);
                            command.Parameters.AddWithValue("@num", guna2TextBox4.Text);
                            command.Parameters.AddWithValue("@lic", licenId);
                            command.Parameters.AddWithValue("@from", От_TextBox2.Text);
                            command.Parameters.AddWithValue("@untill", До_TextBox5.Text);

                            // Выполнение запроса
                            command.ExecuteNonQuery();
                            MessageBox.Show("Запись успешно изменена!");
                            LoadData();
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
                try
                {
                    db = DataBase.GetInstance();
                    using (SQLiteConnection conn = db.GetConnection())
                    {
                        if (conn != null && conn.State == ConnectionState.Open)
                        {
                            string id = dataGridView1.SelectedRows[0].Cells["ID_rent"].Value.ToString();

                            if (int.TryParse(id, out int parsedId)) // Важная проверка!
                            {
                                DialogResult result = MessageBox.Show("Вы действительно хотите удалить запись?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (result == DialogResult.Yes)
                                {
                                    // Обновляем Rent_device
                                    string updateQuery = "UPDATE Rent_device SET Rent_from = NULL, Rent_to_up = NULL WHERE Renters = @id";
                                    using (SQLiteCommand updateCmd = new SQLiteCommand(updateQuery, conn))
                                    {
                                        updateCmd.Parameters.AddWithValue("@id", parsedId);
                                        updateCmd.ExecuteNonQuery();
                                    }
                                    //Обновляем Rent_position
                                    string updateQuery2 = "UPDATE Rent_position SET Rent_from = NULL, Rent_up_to = NULL WHERE Renters = @id";
                                    using (SQLiteCommand updateCmd = new SQLiteCommand(updateQuery2, conn))
                                    {
                                        updateCmd.Parameters.AddWithValue("@id", parsedId);
                                        updateCmd.ExecuteNonQuery();
                                    }
                                    //Обновляем Rent_storage
                                    string updateQuery3 = "UPDATE Rent_storage SET Rent_from = NULL, Rent_to_up = NULL, Product = NULL WHERE Renter = @id";
                                    using (SQLiteCommand updateCmd = new SQLiteCommand(updateQuery3, conn))
                                    {
                                        updateCmd.Parameters.AddWithValue("@id", parsedId);
                                        updateCmd.ExecuteNonQuery();
                                    }
                                    //Обновляем Product
                                    string updateQuery4 = "DELETE FROM Products WHERE Renter = @id";
                                    using (SQLiteCommand updateCmd = new SQLiteCommand(updateQuery4, conn))
                                    {
                                        updateCmd.Parameters.AddWithValue("@id", parsedId);
                                        updateCmd.ExecuteNonQuery();
                                    }

                                    // Удаляем запись из Renters
                                    string deleteQuery = "DELETE FROM Renters WHERE ID = @id";
                                    using (SQLiteCommand deleteCmd = new SQLiteCommand(deleteQuery, conn))
                                    {
                                        deleteCmd.Parameters.AddWithValue("@id", parsedId);
                                        deleteCmd.ExecuteNonQuery();
                                    }

                                    MessageBox.Show("Запись удалена из базы!");
                                    LoadData();  // Перезагружаем данные для обновления отображения
                                }
                            }
                            else
                            {
                                MessageBox.Show("Некорректный ID.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Ошибка подключения к базе данных.");
                        }
                    }
                }
                catch (SQLiteException ex)
                {
                    MessageBox.Show($"Ошибка при удалении: {ex.Message}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Произошла ошибка: {ex.Message}"); // Более общая обработка исключений
                }
            }
            else
            {
                MessageBox.Show("Выберите запись для удаления!");
            }
        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {

        }


        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Name_TextBox1.Clear();
            guna2TextBox3.Clear();
            guna2TextBox4.Clear();
            Licen_ComboBox1.SelectedIndex = -1;
            От_TextBox2.Clear();
            До_TextBox5.Clear();

            if (dataGridView1.SelectedRows.Count > 0)
            {
                db = DataBase.GetInstance();
                SQLiteConnection conn = db.GetConnection();
                id = dataGridView1.SelectedRows[0].Cells["ID_rent"].Value.ToString();
                string query = "SELECT Photo, Name, Passport_series, Passport_number, License, licen_from, licen_to_up FROM Renters WHERE ID = @id";
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                SQLiteDataReader reader = cmd.ExecuteReader();

                int selectedRowIndex = e.RowIndex;
                DataGridViewRow selectedDGVRow = dataGridView1.Rows[selectedRowIndex];
                Licen_ComboBox1.Text = selectedDGVRow.Cells[4].Value.ToString();

                if (reader.Read())
                {
                    // Заполняем текстовые поля
                    Name_TextBox1.Text = reader["Name"].ToString();
                    guna2TextBox3.Text = reader["Passport_series"].ToString();
                    guna2TextBox4.Text = reader["Passport_number"].ToString();
                    От_TextBox2.Text = reader["licen_from"].ToString();
                    До_TextBox5.Text = reader["licen_to_up"].ToString();

                    object photoObject = reader["Photo"]; // Получаем значение как объект
                    if (photoObject != DBNull.Value) // Проверяем на DBNull.Value
                    {
                        byte[] pht = (byte[])photoObject; // Преобразуем только если не NULL
                        MemoryStream ms = new MemoryStream(pht);
                        pictureBox1.Image = System.Drawing.Image.FromStream(ms);
                        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                        pictureBox1.Refresh();
                    }
                    else
                    {
                        pictureBox1.Image = null; // Или установите какое-то изображение по умолчанию
                        MessageBox.Show("Изображение отсутствует для этой записи."); // Информируем пользователя
                    }
                }
                reader.Close(); // Закрываем reader
            }
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            string filter = guna2TextBox1.Text;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["Name"].Value != null && row.Cells["Name"].Value.ToString().ToLower().Contains(filter.ToLower()))
                {
                    row.Visible = true;
                }
                else
                {
                    row.Visible = false;
                }
            }
        }

        private void Licen_ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ide1 = Licen_ComboBox1.Text;
            db = DataBase.GetInstance();
            SQLiteConnection conn1 = db.GetConnection();
            string query1 = "SELECT ID FROM Лицензии WHERE Lisenssee = @ide)";
            SQLiteCommand cmd1 = new SQLiteCommand(query1, conn1);
            cmd1.Parameters.AddWithValue("@ide", ide1);
        }
    }
}
