using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace DATA_C_
{
    public partial class Products : Form
    {
        public Products()
        {
            InitializeComponent();
        }
        private DataBase db;
        string id;
        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
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
            this.Close(); //Закрытие диологовое окно
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
        Products.ID_product as ID,
        Products.Product_name as product_name,
        Renters.Name as renter_name,
        Лицензии.Lisenssee AS license,
        Products.Valid_from AS val_from,
        Products.Valid_untill AS val_untill
        FROM Products
        LEFT JOIN Renters
        ON Renters.ID = Products.Renter
        LEFT JOIN Лицензии
        ON Лицензии.ID = Products.License";

                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        try
                        {
                            using (var reader = cmd.ExecuteReader())
                            {
                                dataGridView1.Rows.Clear();
                                while (reader.Read())
                                {
                                    string rentFromStr = reader["val_from"]?.ToString() ?? "";
                                    string rentToStr = reader["val_untill"]?.ToString() ?? "";
                                    string ID = reader["ID"]?.ToString() ?? "";
                                    string Product_name = reader["renter_name"]?.ToString() ?? "";
                                    string Renter = reader["product_name"]?.ToString() ?? "";
                                    string License = reader["license"]?.ToString() ?? "";

                                    DateTime rentFrom;
                                    DateTime rentTo;

                                    bool fromParsed = DateTime.TryParse(rentFromStr, out rentFrom);
                                    bool toParsed = DateTime.TryParse(rentToStr, out rentTo);

                                    int rowIndex = dataGridView1.Rows.Add(
                                      ID,
                                      Product_name,
                                      Renter,
                                      License,
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
                        catch (SQLiteException ex)
                        {
                            MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Ошибка подключения к БД.");
                }
            }
        }

        private void Products_Load(object sender, EventArgs e)
        {
            Traid_Load();
            Licen_Load();

            LoadData();
        }

        private void Traid_Load()
        {
            db = DataBase.GetInstance();
            SQLiteConnection conn1 = db.GetConnection();
            string query1 = "SELECT Renters.Name FROM Renters";
            SQLiteCommand cmd1 = new SQLiteCommand(query1, conn1);
            SQLiteDataReader reader1 = cmd1.ExecuteReader();
            while (reader1.Read())
            {
                string data = reader1.GetString(0);
                Traid_ComboBox1.Items.Add(data);
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



        private void Licen_ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ide1 = Licen_ComboBox1.Text;
            db = DataBase.GetInstance();
            SQLiteConnection conn1 = db.GetConnection();
            string query1 = "SELECT ID FROM Лицензии WHERE Lisenssee = @ide)";
            SQLiteCommand cmd1 = new SQLiteCommand(query1, conn1);
            cmd1.Parameters.AddWithValue("@ide", ide1);
        }
        private void Traid_ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ide1 = Traid_ComboBox1.Text;
            db = DataBase.GetInstance();
            SQLiteConnection conn1 = db.GetConnection();
            string query1 = "SELECT ID FROM Renters WHERE Name = @ide)";
            SQLiteCommand cmd1 = new SQLiteCommand(query1, conn1);
            cmd1.Parameters.AddWithValue("@ide", ide1);
        }




        private void Add_Click(object sender, EventArgs e)
        {
            string name = Name.Text;
            string license = Licen_ComboBox1.Text;
            string renterName = Traid_ComboBox1.Text;
            string from = From.Text;
            string untill = Untill.Text;

            if (string.IsNullOrEmpty(name) ||
                string.IsNullOrEmpty(license) ||
                string.IsNullOrEmpty(renterName) ||
                string.IsNullOrEmpty(from) ||
                string.IsNullOrEmpty(untill))
            {
                MessageBox.Show("Заполните все поля.");
                return;
            }
            else if (!Regex.IsMatch(name, "^[а-яА-Я -]+$"))
            {
                MessageBox.Show("Заполните название товара.");
                return;
            }
            else if (!Regex.IsMatch(license, "^[а-яА-Я -]+$"))
            {
                MessageBox.Show("Заполните данные о лицензии.");
                return;
            }
            else if (!Regex.IsMatch(renterName, "^[а-яА-Я -]+$"))
            {
                MessageBox.Show("Заполните имя продавца.");
                return;
            }
            else if (!DateTime.TryParseExact(from, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime fromDate))
            {
                MessageBox.Show("Заполните информацию о сроке годности в формате ДД.ММ.ГГГГ.");
                return;
            }
            else if (!DateTime.TryParseExact(untill, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime untilDate))
            {
                MessageBox.Show("Заполните информацию о сроке аренды в формате ДД.ММ.ГГГГ.");
                return;
            }
            else if (fromDate > DateTime.Now.Date)
            {
                MessageBox.Show("Дата начала срока годности не может быть в будущем.");
                return;
            }
            else if (untilDate <= fromDate)
            {
                MessageBox.Show("Дата окончания срока годности должна быть больше даты начала.");
                return;
            }
            else
            {
                db = DataBase.GetInstance();
                using (SQLiteConnection connAdd = db.GetConnection())
                {
                    int renterId;
                    int licenId;
                    int renterLicenseId = -1;
                    DateTime licenFromDate = DateTime.MinValue;
                    DateTime licenToDate = DateTime.MaxValue;


                    // 1. Получаем ID, лицензию и сроки действия лицензии из таблицы Renters
                    string selectRenterQuery = "SELECT ID, License, licen_from, licen_to_up FROM Renters WHERE Name = @renterName";
                    using (SQLiteCommand selectRenterCommand = new SQLiteCommand(selectRenterQuery, connAdd))
                    {
                        selectRenterCommand.Parameters.AddWithValue("@renterName", renterName);
                        try
                        {
                            using (SQLiteDataReader reader = selectRenterCommand.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    renterId = Convert.ToInt32(reader["ID"]);
                                    if (!reader.IsDBNull(reader.GetOrdinal("License")))
                                    {
                                        renterLicenseId = Convert.ToInt32(reader["License"]);

                                    }
                                    if (!reader.IsDBNull(reader.GetOrdinal("licen_from")))
                                    {
                                        if (DateTime.TryParseExact(reader["licen_from"].ToString(), "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime licenFrom))
                                        {
                                            licenFromDate = licenFrom;
                                        }
                                    }

                                    if (!reader.IsDBNull(reader.GetOrdinal("licen_to_up")))
                                    {
                                        if (DateTime.TryParseExact(reader["licen_to_up"].ToString(), "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime licenTo))
                                        {
                                            licenToDate = licenTo;
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show($"Арендатор с именем '{renterName}' не найден.");
                                    return;
                                }
                            }
                        }
                        catch (SQLiteException ex)
                        {
                            MessageBox.Show($"Ошибка при получении ID арендатора: {ex.Message}");
                            return;
                        }
                    }
                    // 2. Проверяем срок действия лицензии
                    if (renterLicenseId == -1)
                    {
                        MessageBox.Show($"У арендатора '{renterName}' не указана лицензия.");
                        return;
                    }
                    if (DateTime.Now < licenFromDate)
                    {
                        MessageBox.Show($"Срок действия лицензии арендатора '{renterName}' еще не наступил. ({licenFromDate.ToString("dd.MM.yyyy")})");
                        return;
                    }
                    if (DateTime.Now > licenToDate)
                    {
                        MessageBox.Show($"Срок действия лицензии арендатора '{renterName}' истек. ({licenToDate.ToString("dd.MM.yyyy")})");
                        return;
                    }

                    // 3. Получаем ID лицензии
                    string selectLicenseQuery = "SELECT ID FROM Лицензии WHERE Lisenssee = @lic";
                    using (SQLiteCommand selectLicenseCommand = new SQLiteCommand(selectLicenseQuery, connAdd))
                    {
                        selectLicenseCommand.Parameters.AddWithValue("@lic", license);
                        try
                        {
                            object licenseResult = selectLicenseCommand.ExecuteScalar();
                            if (licenseResult == null)
                            {
                                MessageBox.Show($"Лицензия с именем '{license}' не найдена.");
                                return;
                            }
                            licenId = Convert.ToInt32(licenseResult);
                        }
                        catch (SQLiteException ex)
                        {
                            MessageBox.Show($"Ошибка при получении ID лицензии: {ex.Message}");
                            return;
                        }
                    }
                    // 4. Проверяем, что лицензия продавца совпадает с выбранной лицензией
                    if (renterLicenseId != licenId)
                    {
                        MessageBox.Show($"У арендатора '{renterName}' нет лицензии '{license}'.");
                        return;
                    }


                    // 5. Добавляем запись в таблицу Products
                    string insertQuery = @"
                INSERT INTO Products (Product_name, Renter, License, Valid_from, Valid_untill)
                VALUES (@name, @renterId, @licenId, @from, @untill);
            ";
                    using (SQLiteCommand insertCommand = new SQLiteCommand(insertQuery, connAdd))
                    {
                        insertCommand.Parameters.AddWithValue("@name", name);
                        insertCommand.Parameters.AddWithValue("@renterId", renterId);
                        insertCommand.Parameters.AddWithValue("@licenId", licenId);
                        insertCommand.Parameters.AddWithValue("@from", fromDate.ToString("dd.MM.yyyy"));
                        insertCommand.Parameters.AddWithValue("@untill", untilDate.ToString("dd.MM.yyyy"));
                        try
                        {
                            insertCommand.ExecuteNonQuery();
                            MessageBox.Show("Запись добавлена в базу!");
                            LoadData();
                        }
                        catch (SQLiteException ex)
                        {
                            MessageBox.Show($"Ошибка при добавлении записи: {ex.Message}");
                        }
                    }
                }
            }
        }


        private void Redact_Click_1(object sender, EventArgs e)
        {
            string name = Name.Text;
            string license = Licen_ComboBox1.Text;
            string renterName = Traid_ComboBox1.Text;
            string from = From.Text;
            string untill = Untill.Text;

            if (string.IsNullOrEmpty(name) ||
                string.IsNullOrEmpty(license) ||
                string.IsNullOrEmpty(renterName) ||
                string.IsNullOrEmpty(from) ||
                string.IsNullOrEmpty(untill))
            {
                MessageBox.Show("Заполните редактируемые поля!");
                return;
            }
            else if (!Regex.IsMatch(name, "^[а-яА-Я -]+$"))
            {
                MessageBox.Show("Заполните название товара.");
                return;
            }
            else if (!Regex.IsMatch(license, "^[а-яА-Я -]+$"))
            {
                MessageBox.Show("Заполните данные лицензии.");
                return;
            }
            else if (!Regex.IsMatch(renterName, "^[а-яА-Я -]+$"))
            {
                MessageBox.Show("Заполните имя продавца.");
                return;
            }
            else if (!DateTime.TryParseExact(from, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime fromDate))
            {
                MessageBox.Show("Заполните информацию о сроке годности в формате ДД.ММ.ГГГГ.");
                return;
            }
            else if (!DateTime.TryParseExact(untill, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime untilDate))
            {
                MessageBox.Show("Заполните информацию о сроке годности в формате ДД.ММ.ГГГГ.");
                return;
            }
            else if (fromDate > DateTime.Now.Date)
            {
                MessageBox.Show("Дата начала срока годности не может быть в будущем.");
                return;
            }
            else if (untilDate <= fromDate)
            {
                MessageBox.Show("Дата окончания срока годности должна быть больше даты начала.");
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
                        string id = selectedRow.Cells["ID_product"].Value.ToString();
                        db = DataBase.GetInstance();

                        using (SQLiteConnection connRed = db.GetConnection())
                        {
                            int renterId;
                            int licenId;
                            int renterLicenseId = -1;
                            DateTime licenFromDate = DateTime.MinValue;
                            DateTime licenToDate = DateTime.MaxValue;

                            // 1. Получаем ID, лицензию и сроки действия лицензии из таблицы Renters
                            string selectRenterQuery = "SELECT ID, License, licen_from, licen_to_up FROM Renters WHERE Name = @renterName";
                            using (SQLiteCommand selectRenterCommand = new SQLiteCommand(selectRenterQuery, connRed))
                            {
                                selectRenterCommand.Parameters.AddWithValue("@renterName", renterName);
                                try
                                {
                                    using (SQLiteDataReader reader = selectRenterCommand.ExecuteReader())
                                    {
                                        if (reader.Read())
                                        {
                                            renterId = Convert.ToInt32(reader["ID"]);
                                            if (!reader.IsDBNull(reader.GetOrdinal("License")))
                                            {
                                                renterLicenseId = Convert.ToInt32(reader["License"]);
                                            }
                                            if (!reader.IsDBNull(reader.GetOrdinal("licen_from")))
                                            {
                                                if (DateTime.TryParseExact(reader["licen_from"].ToString(), "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime licenFrom))
                                                {
                                                    licenFromDate = licenFrom;
                                                }
                                            }

                                            if (!reader.IsDBNull(reader.GetOrdinal("licen_to_up")))
                                            {
                                                if (DateTime.TryParseExact(reader["licen_to_up"].ToString(), "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime licenTo))
                                                {
                                                    licenToDate = licenTo;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show($"Продавец с именем '{renterName}' не найден.");
                                            return;
                                        }
                                    }
                                }
                                catch (SQLiteException ex)
                                {
                                    MessageBox.Show($"Ошибка при получении ID продавца: {ex.Message}");
                                    return;
                                }
                            }

                            // 2. Проверяем срок действия лицензии
                            if (renterLicenseId == -1)
                            {
                                MessageBox.Show($"У продавца '{renterName}' не указана лицензия.");
                                return;
                            }
                            if (DateTime.Now < licenFromDate)
                            {
                                MessageBox.Show($"Срок действия лицензии продавца '{renterName}' еще не наступил. ({licenFromDate.ToString("dd.MM.yyyy")})");
                                return;
                            }
                            if (DateTime.Now > licenToDate)
                            {
                                MessageBox.Show($"Срок действия лицензии продавца '{renterName}' истек. ({licenToDate.ToString("dd.MM.yyyy")})");
                                return;
                            }
                            // 3. Получаем ID лицензии
                            string selectLicenseQuery = "SELECT ID FROM Лицензии WHERE Lisenssee = @lic";
                            using (SQLiteCommand selectLicenseCommand = new SQLiteCommand(selectLicenseQuery, connRed))
                            {
                                selectLicenseCommand.Parameters.AddWithValue("@lic", license);
                                try
                                {
                                    object licenseResult = selectLicenseCommand.ExecuteScalar();
                                    if (licenseResult == null)
                                    {
                                        MessageBox.Show($"Лицензия с именем '{license}' не найдена.");
                                        return;
                                    }
                                    licenId = Convert.ToInt32(licenseResult);
                                }
                                catch (SQLiteException ex)
                                {
                                    MessageBox.Show($"Ошибка при получении лицензии: {ex.Message}");
                                    return;
                                }
                            }
                            // 4. Проверяем, что лицензия продавца совпадает с выбранной лицензией
                            if (renterLicenseId != licenId)
                            {
                                MessageBox.Show($"У продавца '{renterName}' нет лицензии '{license}'.");
                                return;
                            }

                            // 5. Обновляем запись в таблице Products
                            string query = "UPDATE Products SET Product_name = @name, Renter = @renterId, License = @license, Valid_from = @from, Valid_untill = @untill WHERE ID_product = @id";
                            using (SQLiteCommand command = new SQLiteCommand(query, connRed))
                            {
                                command.Parameters.AddWithValue("@id", id);
                                command.Parameters.AddWithValue("@name", name);
                                command.Parameters.AddWithValue("@renterId", renterId);
                                command.Parameters.AddWithValue("@license", licenId);
                                command.Parameters.AddWithValue("@from", fromDate.ToString("dd.MM.yyyy"));
                                command.Parameters.AddWithValue("@untill", untilDate.ToString("dd.MM.yyyy"));
                                try
                                {
                                    command.ExecuteNonQuery();
                                    MessageBox.Show("Запись успешно изменена!");
                                    LoadData();
                                }
                                catch (SQLiteException ex)
                                {
                                    MessageBox.Show($"Ошибка при изменении записи: {ex.Message}");
                                }
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

        private void Del_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                db = DataBase.GetInstance();
                SQLiteConnection conn = db.GetConnection();
                string id = dataGridView1.SelectedRows[0].Cells["ID_product"].Value.ToString();

                // Диалоговое окно "Да/Нет"
                DialogResult result = MessageBox.Show("Вы действительно хотите удалить запись?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    string sql = "DELETE FROM Products WHERE ID_product = @id";
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
            Name.Clear();
            Licen_ComboBox1.SelectedIndex = -1; //Очищаем поля, если строка не выбрана
            Traid_ComboBox1.SelectedIndex = -1;
            From.Clear();
            Untill.Clear();

            if (dataGridView1.SelectedRows.Count > 0)
            {
                db = DataBase.GetInstance();
                SQLiteConnection conn = db.GetConnection();
                id = dataGridView1.SelectedRows[0].Cells["ID_product"].Value.ToString();
                string query = "SELECT Product_name, Renter, License, Valid_from, Valid_untill FROM Products WHERE ID_product = @id";
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                SQLiteDataReader reader = cmd.ExecuteReader();

                int selectedRowIndex = e.RowIndex;
                DataGridViewRow selectedDGVRow = dataGridView1.Rows[selectedRowIndex];
                Traid_ComboBox1.Text = selectedDGVRow.Cells[1].Value.ToString();
                Licen_ComboBox1.Text = selectedDGVRow.Cells[3].Value.ToString();

                if (reader.Read())
                {
                    Name.Text = reader["Product_name"].ToString();
                    Licen_ComboBox1.Text = reader["License"].ToString();
                    Traid_ComboBox1.Text = reader["Renter"].ToString();
                    From.Text = reader["Valid_from"].ToString();
                    Untill.Text = reader["Valid_untill"].ToString();

                }
                else
                {
                    MessageBox.Show("Запись не найдена!"); //Сообщение об ошибке, если запись не найдена
                }
                reader.Close(); // Закрываем reader
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
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


                    if (row.Cells["Valid_from"].Value is string fromStr &&
                       row.Cells["Valid_untill"].Value is string toStr)
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
            guna2TextBox2.Clear();

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {
            string filter = guna2TextBox2.Text;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["Product_name"].Value != null && row.Cells["Product_name"].Value.ToString().ToLower().Contains(filter.ToLower()))
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
                if (row.Cells["ID_renter"].Value != null && row.Cells["ID_renter"].Value.ToString().ToLower().Contains(filter.ToLower()))
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