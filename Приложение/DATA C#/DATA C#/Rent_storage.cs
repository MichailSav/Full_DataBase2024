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
    public partial class Rent_storage : Form
    {
        public Rent_storage()
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

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
        public static void CreateTrigger(string connectionString)
        {
            string createTriggerSQL = @"
            CREATE TRIGGER set_default_rent_dates
            BEFORE INSERT ON Rent_device
            FOR EACH ROW
            BEGIN
            SELECT
            CASE
            WHEN NEW.Rent_from IS NULL THEN date('now')
            ELSE NEW.Rent_from
            END INTO NEW.Rent_from;
            SELECT
            CASE
            WHEN NEW.Rent_to_up IS NULL THEN date('now', '+1 year')
            ELSE NEW.Rent_to_up
            END INTO NEW.Rent_to_up;
            END
        ";

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (var command = new SQLiteCommand(createTriggerSQL, connection))
                {
                    try
                    {
                        command.ExecuteNonQuery();
                        Console.WriteLine("Триггер успешно создан!");
                    }
                    catch (SQLiteException ex)
                    {
                        Console.WriteLine($"Ошибка при создании триггера: {ex.Message}");
                    }
                }
            }
        }
        


        private void Product_Load()
        {
            db = DataBase.GetInstance();
            SQLiteConnection conn1 = db.GetConnection();
            string query1 = "SELECT Products.Product_name FROM Products";
            SQLiteCommand cmd1 = new SQLiteCommand(query1, conn1);
            SQLiteDataReader reader1 = cmd1.ExecuteReader();
            while (reader1.Read())
            {
                string data = reader1.GetString(0);
                Product_ComboBox1.Items.Add(data);
            }
        }

        private void DataLoad()
        {
            var db = DataBase.GetInstance();
            var conn = db.GetConnection();

            if (conn != null && conn.State == ConnectionState.Open)
            {
                string query = @"
            SELECT
                Rent_storage.ID_stor as ID_stor,
                Renters.Name as renter_name,
                Products.Product_name AS name_product,
                Rent_storage.Rent_from AS rent_from,
                Rent_storage.Rent_to_up AS rent_to_up
            FROM Rent_storage
            LEFT JOIN Renters
                ON Renters.ID = Rent_storage.Renter
            LEFT JOIN Products 
                ON Products.ID_product = Rent_storage.Product;
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

                            string ID = reader["ID_stor"]?.ToString() ?? "";
                            string renterName = reader["renter_name"]?.ToString() ?? "";
                            string productName = reader["name_product"]?.ToString() ?? "";

                            DateTime rentFrom;
                            DateTime rentTo;

                            bool fromParsed = DateTime.TryParse(rentFromStr, out rentFrom);
                            bool toParsed = DateTime.TryParse(rentToStr, out rentTo);

                            int rowIndex = dataGridView1.Rows.Add(
                                ID,
                                renterName,
                                productName,
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
            Traid_ComboBox2.Items.Clear();

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
                                                Traid_ComboBox2.Items.Add(renterName);
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

        private void Rent_storage_Load(object sender, EventArgs e)
        {
            LoadRentersWithPositions();
            Product_Load();

            DataLoad();
        }

        private void Redact_Click(object sender, EventArgs e)
        {
            if (
                string.IsNullOrEmpty(Traid_ComboBox2.Text) ||
                string.IsNullOrEmpty(Product_ComboBox1.Text) ||
                string.IsNullOrEmpty(guna2TextBox3.Text) ||
                string.IsNullOrEmpty(guna2TextBox4.Text))
            {
                MessageBox.Show("Заполните редактируемые поля!");
            }
            else if (!Regex.IsMatch(Traid_ComboBox2.Text, "^[а-яА-Я -]+$"))
            {
                MessageBox.Show("Заполните данные о продавце.");
            }
            else if (!Regex.IsMatch(Product_ComboBox1.Text, "^[а-яА-Я .-]+$"))
            {
                MessageBox.Show("Заполните данные о товаре.");
            }
            else if (!DateTime.TryParseExact(guna2TextBox3.Text, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime fromDate))
            {
                MessageBox.Show("Заполните информацию о сроке аренды в формате ДД.ММ.ГГГГ.");
            }
            else if (!DateTime.TryParseExact(guna2TextBox4.Text, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime untilDate))
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
                        string id = selectedRow.Cells["ID_stor"].Value.ToString(); // Получение ID_stor


                        // Получение экземпляра базы данных и соединения
                        var db = DataBase.GetInstance();
                        using (var conn = db.GetConnection())
                        {
                            // SQL запрос для обновления данных
                            string query = @"
                         UPDATE Rent_storage
                         SET
                         Renter = (SELECT ID FROM Renters WHERE Name = @renter_name),
                         Product = (SELECT ID_product FROM Products WHERE Product_name = @product_name),
                         Rent_from = @Rent_from,
                         Rent_to_up = @Rent_to_up
                         WHERE
                         ID_stor = @id;
                         ";
                            using (SQLiteCommand command = new SQLiteCommand(query, conn))
                            {
                                // Добавление параметров
                                command.Parameters.AddWithValue("@id", id);
                                command.Parameters.AddWithValue("@renter_name", Traid_ComboBox2.Text); // переименовать параметр
                                command.Parameters.AddWithValue("@product_name", Product_ComboBox1.Text); // переименовать параметр
                                command.Parameters.AddWithValue("@Rent_from", fromDate.ToString("dd.MM.yyyy"));
                                command.Parameters.AddWithValue("@Rent_to_up", untilDate.ToString("dd.MM.yyyy"));

                                // Выполнение запроса
                                command.ExecuteNonQuery();
                                MessageBox.Show("Запись успешно изменена!");
                                DataLoad();
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
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    db = DataBase.GetInstance();
                    SQLiteConnection conn = db.GetConnection();
                    string id = dataGridView1.SelectedRows[0].Cells["ID_stor"].Value.ToString();

                    // Диалоговое окно "Да/Нет"
                    DialogResult result = MessageBox.Show("Вы действительно хотите удалить запись?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        string sql = "DELETE FROM Rent_storage WHERE ID_stor = @id";
                        SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                        dataGridView1.Refresh();
                        MessageBox.Show("Запись удалена из базы!");
                        DataLoad();
                    }
                }
                else
                {
                    MessageBox.Show("Выберите запись для удаления!");
                }

            }
        }

        private void Traid_ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedRenterName = Traid_ComboBox2.Text;
            if (string.IsNullOrEmpty(selectedRenterName))
            {
                return; // Если продавец не выбран, ничего не делаем
            }

            db = DataBase.GetInstance();
            using (SQLiteConnection conn = db.GetConnection())
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    int renterId;

                    // 1. Получаем ID продавца
                    string selectRenterQuery = "SELECT ID FROM Renters WHERE Name = @renterName";
                    using (SQLiteCommand selectRenterCommand = new SQLiteCommand(selectRenterQuery, conn))
                    {
                        selectRenterCommand.Parameters.AddWithValue("@renterName", selectedRenterName);
                        try
                        {
                            object result = selectRenterCommand.ExecuteScalar();
                            if (result == null)
                            {
                                return;
                            }
                            renterId = Convert.ToInt32(result);
                        }
                        catch (SQLiteException ex)
                        {
                            MessageBox.Show($"Ошибка при получении ID продавца: {ex.Message}");
                            return;
                        }
                    }

                    // 2. Получаем продукты, принадлежащие продавцу
                    string selectProductsQuery = @"
                    SELECT Product_name
                    FROM Products
                    WHERE Renter = @renterId
                    ";
                    using (SQLiteCommand selectProductsCommand = new SQLiteCommand(selectProductsQuery, conn))
                    {
                        selectProductsCommand.Parameters.AddWithValue("@renterId", renterId);
                        try
                        {
                            using (SQLiteDataReader reader = selectProductsCommand.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    string productName = reader["Product_name"].ToString();
                                    Product_ComboBox1.Items.Add(productName); // Заполняем ComboBox
                                }
                            }
                        }
                        catch (SQLiteException ex)
                        {
                            MessageBox.Show($"Ошибка при получении продуктов: {ex.Message}");
                            return;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Ошибка подключения к БД.");
                }
            }
        }

        private void Product_ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ide = Product_ComboBox1.Text;
            db = DataBase.GetInstance();
            SQLiteConnection conn1 = db.GetConnection();

            string query2 = "SELECT ID_product FROM Products = @ide)";
            SQLiteCommand cmd2 = new SQLiteCommand(query2, conn1);
            cmd2.Parameters.AddWithValue("@ide", ide);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            Traid_ComboBox2.SelectedIndex = -1; //Очищаем поля, если строка не выбрана
            Product_ComboBox1.SelectedIndex = -1;
            guna2TextBox3.Clear();
            guna2TextBox4.Clear();


            if (dataGridView1.SelectedRows.Count > 0)
            {
                db = DataBase.GetInstance();
                SQLiteConnection conn = db.GetConnection();
                id = dataGridView1.SelectedRows[0].Cells["ID_stor"].Value.ToString();
                string query = "SELECT Renter, Product, Rent_from, Rent_to_up FROM Rent_storage WHERE ID_stor = @id";
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                SQLiteDataReader reader = cmd.ExecuteReader();

                int selectedRowIndex = e.RowIndex;
                DataGridViewRow selectedDGVRow = dataGridView1.Rows[selectedRowIndex];
                Traid_ComboBox2.Text = selectedDGVRow.Cells[1].Value.ToString();
                Product_ComboBox1.Text = selectedDGVRow.Cells[2].Value.ToString();

                if (reader.Read())
                {
                    Traid_ComboBox2.Text = reader["Renter"].ToString();
                    Product_ComboBox1.Text = reader["Product"].ToString();
                    guna2TextBox3.Text = reader["Rent_from"].ToString();
                    guna2TextBox4.Text = reader["Rent_to_up"].ToString();            
                }
                else
                {
                    MessageBox.Show("Запись не найдена!"); //Сообщение об ошибке, если запись не найдена
                }
                reader.Close(); // Закрываем reader
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                db = DataBase.GetInstance();
                SQLiteConnection conn = db.GetConnection();
                string id = dataGridView1.SelectedRows[0].Cells["ID_stor"].Value.ToString();

                // Диалоговое окно "Да/Нет"
                DialogResult result = MessageBox.Show("Вы действительно хотите удалить запись?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    string sql = "UPDATE Rent_storage SET Renter = null, Product = null, Rent_from = null, Rent_to_up = null WHERE ID_stor = @id";
                    SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                    dataGridView1.Refresh();
                    MessageBox.Show("Запись удалена из базы!");
                    DataLoad();
                }
            }
            else
            {
                MessageBox.Show("Выберите запись для удаления!");
            }
        }

        private void NewStorageButton1_Click(object sender, EventArgs e)
        {
            string ID_stor = guna2TextBox2.Text;

            if (string.IsNullOrEmpty(ID_stor))
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
                        string query = "INSERT INTO Rent_storage (ID_stor) VALUES (@ID_stor)";
                        SQLiteCommand command = new SQLiteCommand(query, conn);
                        command.Parameters.AddWithValue("@ID_stor", ID_stor);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Запись добавлена в базу!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка при добавлении записи: " + ex.Message);
                    }
                }
            }

            DataLoad();
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
            guna2TextBox1.Clear();
            guna2TextBox6.Clear();
            guna2TextBox5.Clear();
        }

        private void guna2TextBox5_TextChanged(object sender, EventArgs e)
        {
            string filter = guna2TextBox5.Text;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["ID_product"].Value != null && row.Cells["ID_product"].Value.ToString().ToLower().Contains(filter.ToLower()))
                {
                    row.Visible = true;
                }
                else
                {
                    row.Visible = false;
                }
            }
        }

        private void guna2TextBox6_TextChanged(object sender, EventArgs e)
        {
            string filter = guna2TextBox6.Text;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["ID_stor"].Value != null && row.Cells["ID_stor"].Value.ToString().ToLower().Contains(filter.ToLower()))
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
